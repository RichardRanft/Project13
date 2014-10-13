//-----------------------------------------------------------------------------
// Copyright (c) 2014 Roostertail Games
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

//OPEN GAME LICENSE Version 1.0a
//
//The following text is the property of Wizards of the Coast, Inc. and is Copyright 
//2000 Wizards of the Coast, Inc ("Wizards"). All Rights Reserved.

//1. Definitions: 
//(a)"Contributors" means the copyright and/or trademark owners who have contributed 
//Open Game Content; 
//(b)"Derivative Material" means copyrighted material including derivative works and 
//translations (including into other computer languages), potation, modification, correction, addition, 
//extension, upgrade, improvement, compilation, abridgment or other form in which an existing work may be 
//recast, transformed or adapted; 
//(c) "Distribute" means to reproduce, license, rent, lease, sell, broadcast, publicly display, transmit 
//or otherwise distribute; 
//(d)"Open Game Content" means the game mechanic and includes the methods, procedures, processes and 
//routines to the extent such content does not embody the Product Identity and is an enhancement over the 
//prior art and any additional content clearly identified as Open Game Content by the Contributor, and means 
//any work covered by this License, including translations and derivative works under copyright law, but 
//specifically excludes Product Identity. 
//(e) "Product Identity" means product and product line names, logos and identifying marks including trade 
//dress; artifacts; creatures characters; stories, storylines, plots, thematic elements, dialogue, incidents, 
//language, artwork, symbols, designs, depictions, likenesses, formats, poses, concepts, themes and graphic, 
//photographic and other visual or audio representations; names and descriptions of characters, spells, 
//enchantments, personalities, teams, personas, likenesses and special abilities; places, locations, 
//environments, creatures, equipment, magical or supernatural abilities or effects, logos, symbols, 
//or graphic designs; and any other trademark or registered trademark clearly identified as Product identity 
//by the owner of the Product Identity, and which specifically excludes the Open Game Content; 
//(f) "Trademark" means the logos, names, mark, sign, motto, designs that are used by a Contributor to identify 
//itself or its products or the associated products contributed to the Open Game License by the Contributor 
//(g) "Use", "Used" or "Using" means to use, Distribute, copy, edit, format, modify, translate and otherwise 
//create Derivative Material of Open Game Content. 
//(h) "You" or "Your" means the licensee in terms of this agreement.

//2. The License: This License applies to any Open Game Content that contains a notice indicating that the Open Game 
//Content may only be Used under and in terms of this License. You must affix such a notice to any Open Game Content 
//that you Use. No terms may be added to or subtracted from this License except as described by the License itself. 
//No other terms or conditions may be applied to any Open Game Content distributed using this License.
//
//3.Offer and Acceptance: By Using the Open Game Content You indicate Your acceptance of the terms of this License.
//
//4. Grant and Consideration: In consideration for agreeing to use this License, the Contributors grant You a perpetual, 
//worldwide, royalty-free, non-exclusive license with the exact terms of this License to Use, the Open Game Content.
//
//5.Representation of Authority to Contribute: If You are contributing original material as Open Game Content, You 
//represent that Your Contributions are Your original creation and/or You have sufficient rights to grant the rights 
//conveyed by this License.
//
//6.Notice of License Copyright: You must update the COPYRIGHT NOTICE portion of this License to include the exact 
//text of the COPYRIGHT NOTICE of any Open Game Content You are copying, modifying or distributing, and You must add 
//the title, the copyright date, and the copyright holder's name to the COPYRIGHT NOTICE of any original Open Game 
//Content you Distribute.
//
//7. Use of Product Identity: You agree not to Use any Product Identity, including as an indication as to compatibility, 
//except as expressly licensed in another, independent Agreement with the owner of each element of that Product Identity. 
//You agree not to indicate compatibility or co-adaptability with any Trademark or Registered Trademark in conjunction 
//with a work containing Open Game Content except as expressly licensed in another, independent Agreement with the owner 
//of such Trademark or Registered Trademark. The use of any Product Identity in Open Game Content does not constitute a 
//challenge to the ownership of that Product Identity. The owner of any Product Identity used in Open Game Content shall 
//retain all rights, title and interest in and to that Product Identity.
//
//8. Identification: If you distribute Open Game Content You must clearly indicate which portions of the work that you 
//are distributing are Open Game Content.
//
//9. Updating the License: Wizards or its designated Agents may publish updated versions of this License. You may use 
//any authorized version of this License to copy, modify and distribute any Open Game Content originally distributed under 
//any version of this License.
//
//10. Copy of this License: You MUST include a copy of this License with every copy of the Open Game Content You Distribute.
//
//11. Use of Contributor Credits: You may not market or advertise the Open Game Content using the name of any Contributor 
//unless You have written permission from the Contributor to do so.
//
//12 Inability to Comply: If it is impossible for You to comply with any of the terms of this License with respect to some 
//or all of the Open Game Content due to statute, judicial order, or governmental regulation then You may not Use any Open 
//Game Material so affected.
//
//13 Termination: This License will terminate automatically if You fail to comply with all terms herein and fail to cure 
//such breach within 30 days of becoming aware of the breach. All sublicenses shall survive the termination of this License.
//
//14 Reformation: If any provision of this License is held to be unenforceable, such provision shall be reformed only to the 
//extent necessary to make it enforceable.
//
//15 COPYRIGHT NOTICE
//Open Game License v 1.0 Copyright 2000, Wizards of the Coast, Inc.

// ----------------------------------------------------------------------------
// D20Game
// ----------------------------------------------------------------------------
// Depends on methods found in gameCore.cs.  Those added here are specific to
// this game type and/or over-ride the "default" game functionaliy.
//
// The desired Game Type must be added to each mission's LevelInfo object.
//   - gameType = "D20";
// If this information is missing then the GameCore will default to DeathMatch.
// ----------------------------------------------------------------------------

function D20Game::onMissionLoaded(%game)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> D20Game::onMissionLoaded");

   $Server::MissionType = "D20";
   parent::onMissionLoaded(%game);
}

function D20Game::initGameVars(%game)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> D20Game::initGameVars");

   //-----------------------------------------------------------------------------
   // What kind of "player" is spawned is either controlled directly by the
   // SpawnSphere or it defaults back to the values set here. This also controls
   // which SimGroups to attempt to select the spawn sphere's from by walking down
   // the list of SpawnGroups till it finds a valid spawn object.
   // These override the values set in core/scripts/server/spawn.cs
   //-----------------------------------------------------------------------------
   
   // Leave $Game::defaultPlayerClass and $Game::defaultPlayerDataBlock as empty strings ("")
   // to spawn a the $Game::defaultCameraClass as the control object.
   $Game::defaultPlayerClass = "AiPlayer";
   $Game::defaultPlayerDataBlock = "SoldierPlayer";
   $Game::defaultPlayerSpawnGroups = "PlayerSpawnPoints PlayerDropPoints";

   //-----------------------------------------------------------------------------
   // What kind of "camera" is spawned is either controlled directly by the
   // SpawnSphere or it defaults back to the values set here. This also controls
   // which SimGroups to attempt to select the spawn sphere's from by walking down
   // the list of SpawnGroups till it finds a valid spawn object.
   // These override the values set in core/scripts/server/spawn.cs
   //-----------------------------------------------------------------------------
   $Game::defaultCameraClass = "Camera";
   $Game::defaultCameraDataBlock = "Observer";
   $Game::defaultCameraSpawnGroups = "CameraSpawnPoints PlayerSpawnPoints PlayerDropPoints";

   // Set the gameplay parameters
   %game.duration = 30 * 60;
   %game.endgameScore = 20;
   %game.endgamePause = 10;
   %game.allowCycling = false;   // Is mission cycling allowed?
}

function D20Game::startGame(%game)
{
   echo (%game @"\c4 -> "@ %game.class @" -> D20Game::startGame");

   parent::startGame(%game);
}

function D20Game::endGame(%game)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> D20Game::endGame");

   parent::endGame(%game);
}

function D20Game::onGameDurationEnd(%game)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> D20Game::onGameDurationEnd");

   parent::onGameDurationEnd(%game);
}

function D20Game::onClientEnterGame(%game, %client)
{
   echo (%game @"\c4 -> "@ %game.class @" -> D20Game::onClientEnterGame");

   parent::onClientEnterGame(%game, %client);
}

function D20Game::onClientLeaveGame(%game, %client)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> D20Game::onClientLeaveGame");

   parent::onClientLeaveGame(%game, %client);

}

function D20Game::loadOut(%game, %player)
{
    //echo (%game @"\c4 -> "@ %game.class @" -> GameCore::loadOut");
    
    parent::loadOut(%game, %player);
    %client = %player.client;
    if ( !isObject(%client) )
    {
        echo(" !! Player " @ %player @ " is orphaned from his client!");
    }
    %client.inventory = new ScriptObject(){
        class = InventoryObject;
    };
    %contents = %client.inventory.getContents();
    echo(" -- Player currently has " @ %contents);
}

// Added this stage to creating a player so game types can override it easily.
// This is a good place to initiate team selection.
function D20Game::preparePlayer(%game, %client)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> D20Game::preparePlayer");

   // Find a spawn point for the player
   // This function currently relies on some helper functions defined in
   // core/scripts/spawn.cs. For custom spawn behaviors one can either
   // override the properties on the SpawnSphere's or directly override the
   // functions themselves.
   %playerSpawnPoint = pickPlayerSpawnPoint($Game::DefaultPlayerSpawnGroups);
   // Spawn a camera for this client using the found %spawnPoint
   //%client.spawnPlayer(%playerSpawnPoint);
   %game.spawnPlayer(%client, %playerSpawnPoint, false);
   commandToServer('overheadCam');

   // Starting equipment
   %game.loadOut(%client.player);
}

function D20Game::loadOut(%game, %player)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> D20Game::loadOut");

   %player.clearWeaponCycle();
   
   %player.setInventory(Ryder, 1);
   %player.setInventory(RyderClip, %player.maxInventory(RyderClip));
   %player.setInventory(RyderAmmo, %player.maxInventory(RyderAmmo));    // Start the gun loaded
   %player.addToWeaponCycle(Ryder);

   %player.setInventory(Lurker, 1);
   %player.setInventory(LurkerClip, %player.maxInventory(LurkerClip));
   %player.setInventory(LurkerAmmo, %player.maxInventory(LurkerAmmo));  // Start the gun loaded
   %player.addToWeaponCycle(Lurker);

   %player.setInventory(LurkerGrenadeLauncher, 1);
   %player.setInventory(LurkerGrenadeAmmo, %player.maxInventory(LurkerGrenadeAmmo));
   %player.addToWeaponCycle(LurkerGrenadeLauncher);

   %player.setInventory(ProxMine, %player.maxInventory(ProxMine));
   %player.addToWeaponCycle(ProxMine);

   %player.setInventory(DeployableTurret, %player.maxInventory(DeployableTurret));
   %player.addToWeaponCycle(DeployableTurret);
   
   if (%player.getDatablock().mainWeapon.image !$= "")
   {
      %player.mountImage(%player.getDatablock().mainWeapon.image, 0);
   }
   else
   {
      %player.mountImage(Ryder, 0);
   }
}

function D20Game::spawnPlayer(%game, %client, %spawnPoint, %noControl)
{
   //echo (%game @"\c4 -> "@ %game.class @" -> D20Game::spawnPlayer");

   if (isObject(%client.player))
   {
      // The client should not already have a player. Assigning
      // a new one could result in an uncontrolled player object.
      error("Attempting to create a player for a client that already has one!");
   }

   // Attempt to treat %spawnPoint as an object
   if (getWordCount(%spawnPoint) == 1 && isObject(%spawnPoint))
   {
      // Defaults
      if ($Game::SelectedPlayerClass !$= "")
      {
          echo(" -- $Game::SelectedPlayerClass = " @ $Game::SelectedPlayerClass);
          %spawnDataBlock  = $Game::SelectedPlayerClass;
      }
      else
          %spawnDataBlock  = $Game::DefaultPlayerDataBlock;
      %spawnClass      = $Game::DefaultPlayerClass;
      
      if( $LocalPlayer !$= "" )
        commandToServer('registerPlayer', $LocalPlayer);

      // Overrides by the %spawnPoint
      if (isDefined("%spawnPoint.spawnClass"))
      {
         %spawnClass = %spawnPoint.spawnClass;
         %spawnDataBlock = %spawnPoint.spawnDatablock;
      }
      else if (isDefined("%spawnPoint.spawnDatablock"))
      {
         // This may seem redundant given the above but it allows
         // the SpawnSphere to override the datablock without
         // overriding the default player class
         %spawnDataBlock = %spawnPoint.spawnDatablock;
      }
      if (%client.selectedDatablock !$= "")
      {
          echo(" -- Spawning using %client-specified datablock: " @ %client.selectedDatablock);
        %spawnDataBlock = %client.selectedDatablock;
      }

      %spawnProperties = %spawnPoint.spawnProperties;
      %spawnScript     = %spawnPoint.spawnScript;

      // Spawn with the engine's Sim::spawnObject() function
      %player = spawnObject(%spawnClass, %spawnDatablock, "",
                            %spawnProperties, %spawnScript);

      // If we have an object do some initial setup
      if (isObject(%player))
      {
         // Pick a location within the spawn sphere.
         %spawnLocation = GameCore::pickPointInSpawnSphere(%player, %spawnPoint);
         %player.setTransform(%spawnLocation);
         
      }
      else
      {
         // If we weren't able to create the player object then warn the user
         // When the player clicks OK in one of these message boxes, we will fall through
         // to the "if (!isObject(%player))" check below.
         if (isDefined("%spawnDatablock"))
         {
               MessageBoxOK("Spawn Player Failed",
                             "Unable to create a player with class " @ %spawnClass @
                             " and datablock " @ %spawnDatablock @ ".\n\nStarting as an Observer instead.",
                             "");
         }
         else
         {
               MessageBoxOK("Spawn Player Failed",
                              "Unable to create a player with class " @ %spawnClass @
                              ".\n\nStarting as an Observer instead.",
                              "");
         }
      }
   }
   else
   {
      
      // Create a default player
      %player = spawnObject($Game::DefaultPlayerClass, $Game::DefaultPlayerDataBlock);
      
      if (!%player.isMemberOfClass("Player"))
         warn("Trying to spawn a class that does not derive from Player.");

      // Treat %spawnPoint as a transform
      %player.setTransform(%spawnPoint);
   }

   // If we didn't actually create a player object then bail
   if (!isObject(%player))
   {
      // Make sure we at least have a camera
      %client.spawnCamera(%spawnPoint);

      return;
   }

   // Update the default camera to start with the player
   if (isObject(%client.camera) && !isDefined("%noControl"))
   {
      if (%player.getClassname() $= "Player")
         %client.camera.setTransform(%player.getEyeTransform());
      else
         %client.camera.setTransform(%player.getTransform());
   }

   // Add the player object to MissionCleanup so that it
   // won't get saved into the level files and will get
   // cleaned up properly
   MissionCleanup.add(%player);

   // Store the client object on the player object for
   // future reference
   %player.client = %client;
   
   // If the player's client has some owned turrets, make sure we let them
   // know that we're a friend too.
   if (%client.ownedTurrets)
   {
      for (%i=0; %i<%client.ownedTurrets.getCount(); %i++)
      {
         %turret = %client.ownedTurrets.getObject(%i);
         %turret.addToIgnoreList(%player);
      }
   }

   // Player setup...
   if (%player.isMethod("setShapeName"))
      %player.setShapeName(%client.playerName);

   if (%player.isMethod("setEnergyLevel"))
      %player.setEnergyLevel(%player.getDataBlock().maxEnergy);

   if (!isDefined("%client.skin"))
   {
      // Determine which character skins are not already in use
      %availableSkins = %player.getDatablock().availableSkins;             // TAB delimited list of skin names
      %count = ClientGroup.getCount();
      for (%cl = 0; %cl < %count; %cl++)
      {
         %other = ClientGroup.getObject(%cl);
         if (%other != %client)
         {
            %availableSkins = strreplace(%availableSkins, %other.skin, "");
            %availableSkins = strreplace(%availableSkins, "\t\t", "");     // remove empty fields
         }
      }

      // Choose a random, unique skin for this client
      %count = getFieldCount(%availableSkins);
      %client.skin = addTaggedString( getField(%availableSkins, getRandom(%count)) );
   }

   %player.setSkinName(%client.skin);

   // Give the client control of the player
   %client.player = %player;

   // Give the client control of the camera if in the editor
   if( $startWorldEditor )
   {
      %control = %client.camera;
      %control.mode = "Fly";
      EditorGui.syncCameraGui();
   }
   else
      %control = %player;

   // Allow the player/camera to receive move data from the GameConnection.  Without this
   // the user is unable to control the player/camera.
   if (!isDefined("%noControl"))
      %client.setControlObject(%control);
}
