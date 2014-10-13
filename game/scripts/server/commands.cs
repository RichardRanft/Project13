//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Misc server commands avialable to clients
//-----------------------------------------------------------------------------

$RayScale = 2000;

function serverCmdSuicide(%client)
{
   if (isObject(%client.player))
      %client.player.kill("Suicide");
}

function serverCmdPlayCel(%client,%anim)
{
   if (isObject(%client.player))
      %client.player.playCelAnimation(%anim);
}

function serverCmdTestAnimation(%client, %anim)
{
   if (isObject(%client.player))
      %client.player.playTestAnimation(%anim);
}

function serverCmdPlayDeath(%client)
{
   if (isObject(%client.player))
      %client.player.playDeathAnimation();
}

// ----------------------------------------------------------------------------
// Throw/Toss
// ----------------------------------------------------------------------------

function serverCmdThrow(%client, %data)
{
   %player = %client.player;
   if(!isObject(%player) || %player.getState() $= "Dead" || !$Game::Running)
      return;
   switch$ (%data)
   {
      case "Weapon":
         %item = (%player.getMountedImage($WeaponSlot) == 0) ? "" : %player.getMountedImage($WeaponSlot).item;
         if (%item !$="")
            %player.throw(%item);
      case "Ammo":
         %weapon = (%player.getMountedImage($WeaponSlot) == 0) ? "" : %player.getMountedImage($WeaponSlot);
         if (%weapon !$= "")
         {
            if(%weapon.ammo !$= "")
               %player.throw(%weapon.ammo);
         }
      default:
         if(%player.hasInventory(%data.getName()))
            %player.throw(%data);
   }
}

// ----------------------------------------------------------------------------
// Force game end and cycle
// Probably don't want this in a final game without some checks.  Anyone could
// restart a game.
// ----------------------------------------------------------------------------

function serverCmdFinishGame()
{
   cycleGame();
}

// ----------------------------------------------------------------------------
// Cycle weapons
// ----------------------------------------------------------------------------

function serverCmdCycleWeapon(%client, %direction)
{
   %client.getControlObject().cycleWeapon(%direction);
}

// ----------------------------------------------------------------------------
// Unmount current weapon
// ----------------------------------------------------------------------------

function serverCmdUnmountWeapon(%client)
{
   %client.getControlObject().unmountImage($WeaponSlot);
}

// ----------------------------------------------------------------------------
// Weapon reloading
// ----------------------------------------------------------------------------

function serverCmdReloadWeapon(%client)
{
   %player = %client.getControlObject();
   %image = %player.getMountedImage($WeaponSlot);
   
   // Don't reload if the weapon's full.
   if (%player.getInventory(%image.ammo) == %image.ammo.maxInventory)
      return;
      
   if (%image > 0)
      %image.clearAmmoClip(%player, $WeaponSlot);
}

// ----------------------------------------------------------------------------
// Camera commands
// ----------------------------------------------------------------------------

function serverCmdorbitCam(%client)
{
   %client.camera.setOrbitObject(%client.player, mDegToRad(20) @ "0 0", 0, 5.5, 5.5);
   %client.camera.camDist = 5.5;
   %client.camera.controlMode = "OrbitObject";
}
function serverCmdoverheadCam(%client)
{
   %client.camera.position = VectorAdd(%client.player.position, "0 0 30");
   %client.camera.lookAt(%client.player.position);
   %client.camera.controlMode = "Overhead"; 
}

function serverCmdtoggleCamMode(%client)
{
   if(%client.camera.controlMode $= "Overhead")
   {
      %client.camera.setOrbitObject(%client.player, mDegToRad(20) @ "0 0", 0, 5.5, 5.5);
      %client.camera.camDist = 5.5;
      %client.camera.controlMode = "OrbitObject";
   }
   else if(%client.camera.controlMode $= "OrbitObject")
   {
      %client.camera.controlMode = "Overhead"; 
      %client.camera.position = VectorAdd(%client.player.position, "0 0 30");
      %client.camera.lookAt(%client.player.position);
   }
}

function serverCmdadjustCamera(%client, %adjustment)
{
   if(%client.camera.controlMode $= "OrbitObject")
   {
      if(%adjustment == 1)
         %n = %client.camera.camDist + 0.5;
      else
         %n = %client.camera.camDist - 0.5;
      
      if(%n < 0.5)
         %n = 0.5;
         
      if(%n > 15)
         %n = 15.0;
         
      %client.camera.setOrbitObject(%client.player, %client.camera.getRotation(), 
        0, %n, %n);
      %client.camera.camDist = %n;
   }
   if(%client.camera.controlMode $= "Overhead")
   {
      %client.camera.position = VectorAdd(%client.camera.position, "0 0 " @ %adjustment);
   }
}

function serverCmdplayerOnReachDest(%client)
{
    commandToClient(%client, 'clearMoveDecal', %client);
}

function serverCmdmovePlayer(%client, %pos, %start, %ray)
{
    echo(" -- " @ %client @ ":" @ %client.player @ " moving");

    // Get access to the AI player we control
    %ai = %client.player;

    %ray = VectorScale(%ray, $RayScale);
    %end = VectorAdd(%start, %ray);

    // We want to allow the AI Player to walk on TSStatics, Interiors, Terrain, etc., so 
    // I broadened the search mask selection.
    %searchMasks = $TypeMasks::TerrainObjectType | $TypeMasks::StaticTSObjectType | 
        $TypeMasks::InteriorObjectType | $TypeMasks::ShapeBaseObjectType | 
        $TypeMasks::StaticObjectType;

    // search!
    %scanTarg = ContainerRayCast( %start, %end, %searchMasks);

    // If the terrain object was found in the scan
    if( %scanTarg )
    {
        commandToClient(%client, 'clearMoveDecal');
        %pos = getWords(%scanTarg, 1, 3);
        // Get the normal of the location we clicked on
        %norm = getWords(%scanTarg, 4, 6);

        // Set the destination for the AI player to
        // make him move
        %ai.setMoveDestination( %pos );
        commandToClient(%client, 'addMoveDecal', %client, %scanTarg, moveTo_decal.getId());
    }
}

function serverCmdcheckTarget(%client, %pos, %start, %ray)
{
   %player = %client.player;
   
   %ray = VectorScale(%ray, $RayScale);
   %end = VectorAdd(%start, %ray);

   // Only care about players this time
   %searchMasks = $TypeMasks::PlayerObjectType;

   // Search!
   %scanTarg = ContainerRayCast( %start, %end, %searchMasks);

   // If an enemy AI object was found in the scan
   if( %scanTarg )
   {
      // Get the enemy ID
      %target = firstWord(%scanTarg);
      if(%player != %target)
      {
         // Cause our AI object to aim at the target
         // offset (0, 0, 1) so you don't aim at the target's feet
         %player.setAimObject(%target, "0 0 1");
         
         // Tell our AI object to fire its weapon
         %player.setImageTrigger(0, 1);
      }
      else
      {
         serverCmdstopAttack(%client);
      }
   }
   else
   {
      serverCmdstopAttack(%client);
   }
}

function serverCmdstopAttack(%client)
{
    // If no valid target was found, or left mouse
    // clicked again on terrain, stop firing and aiming
    %unit = %client.player;
    %unit.setAimObject(0);
    %unit.schedule(150, "setImageTrigger", 0, 0);
}

function serverCmdregisterPlayer(%client, %d20PlayerObject)
{
    echo(" -- registering player " @ %d20PlayerObject @ " to client " @%client);
    %client.PlayerObj = %d20PlayerObject;
}
