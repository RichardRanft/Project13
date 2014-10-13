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
// PlayGui is the main TSControl through which the game is viewed.
// The PlayGui also contains the hud controls.
//-----------------------------------------------------------------------------

exec("./sidebars/sidebars.cs");

function PlayGui::onWake(%this)
{    
    if (!isObject(%this.decalMan))
    {
        %this.decalMan = new DecalManager();
        if (isObject(MissionCleanup))
            MissionCleanup.add(%this.decalMan);
    }
    // Turn off any shell sounds...
    // sfxStop( ... );
    leftPane.onAdd();
    rightPane.onAdd();
    bottomPane.onAdd();

    $enableDirectInput = "1";
    activateDirectInput();

    // Message hud dialog
    if ( isObject( MainChatHud ) )
    {
        Canvas.pushDialog( MainChatHud );
        chatHud.attach(HudMessageVector);
    }      

    // just update the action map here
    moveMap.push();

    // hack city - these controls are floating around and need to be clamped
    if ( isFunction( "refreshCenterTextCtrl" ) )
        schedule(0, 0, "refreshCenterTextCtrl");
    if ( isFunction( "refreshBottomTextCtrl" ) )
        schedule(0, 0, "refreshBottomTextCtrl");
}

function PlayGui::onSleep(%this)
{
    if ( isObject( MainChatHud ) )
        Canvas.popDialog( MainChatHud );

    // pop the keymaps
    moveMap.pop();
}

function PlayGui::clearHud( %this )
{
    Canvas.popDialog( MainChatHud );

    while ( %this.getCount() > 0 )
        %this.getObject( 0 ).delete();
}

function PlayGui::onResize(%this, %pos, %ext)
{
    //echo(" -- PlayGui::onResize("@%this@", "@%pos@", "@%ext@")");
    %newWidth = getWord(%ext, 0);
    %newHeight = getWord(%ext, 1);
    leftPane.onResize(%newWidth, %newHeight);
    rightPane.onResize(%newWidth, %newHeight);
    bottomPane.onResize(%newWidth, %newHeight);
}

// onMouseDown is called when the left mouse
// button is clicked in the scene
// %pos is the screen (pixel) coordinates of the mouse click
// %start is the world coordinates of the camera
// %ray is a vector through the viewing 
// frustum corresponding to the clicked pixel
function PlayGui::onMouseDown(%this, %pos, %start, %ray)
{
    // If we're in building placement mode ask the server to create a building for
    // us at the point that we clicked.
    if (%this.placingBuilding)
    {
        // Clear the building placement flag first.
        %this.placingBuilding = false;
        // Request a building at the clicked coordinates from the server.
        commandToServer('createBuilding', %pos, %start, %ray);
    }
    else
    {
        // Ask the server to let us attack a target at the clicked position.
        commandToServer('checkTarget', %pos, %start, %ray);
    }
}

// onRightMouseDown is called when the right mouse
// button is clicked in the scene
// %pos is the screen (pixel) coordinates of the mouse click
// %start is the world coordinates of the camera
// %ray is a vector through the viewing 
// frustum corresponding to the clicked pixel
function PlayGui::onRightMouseDown(%this, %pos, %start, %ray)
{   
    commandToServer('movePlayer', %pos, %start, %ray);
}

//-----------------------------------------------------------------------------
// Rollout panels for controls

function leftPane::onAdd(%this)
{
    echo(" -- leftPane added");
    %this.position = (12 - getWord(%this.extent, 0)) SPC getWord(%this.position, 1);
    %x = getWord(%this.position, 0);
    %y = getWord(%this.position, 1);
    if(isObject(%this.paneTween))
        %this.paneTween.delete();
    %this.paneTween = UITwillex.to(250, %this, "position:0 "@%y);
    leftPaneMouse.pane = %this;
    %this.calcButtonGrid();
    %this.clear();
    for(%i = 0; %i < 10; %i++)
    {
        // add some test buttons
        %btnName = "L" @ %i + 1;
        if( %i == 0 )
            %this.addButton("Test Save", "testCharSave", "");
        else
            %this.addButton(%btnName, "", "");
    }
    %this.setContentAlignment("left", "center");
}

function leftPane::onResize(%this, %width, %height)
{
    echo(" -- leftPane::onResize("@%this@", "@%width@", "@%height@")");
    %this.position = (12 - getWord(%this.extent, 0)) SPC getWord(%this.position, 1);
    %x = getWord(%this.position, 0);
    %y = getWord(%this.position, 1);
    if(isObject(%this.paneTween))
        %this.paneTween.delete();
    %this.paneTween = UITwillex.to(250, %this, "position:0 "@%y);
    leftPaneMouse.pane = %this;
}

function leftPane::onRemove(%this)
{
    if(isObject(%this.paneTween))
        %this.paneTween.delete();
}

function leftPaneMouse::onMouseUp(%this)
{
    %this.pane.selectWindow();
    if(%this.extended == false)
    {
        %this.pane.paneTween.forward();
        %this.pane.paneTween.play();
        %this.extended = true;
    }
    else
    {
        %this.pane.paneTween.reverse();
        %this.pane.paneTween.play();
        %this.extended = false;
    }
}

//function leftPaneMouse::onMouseEnter(%this)
//{
    //%this.pane.paneTween.forward();
    //%this.pane.paneTween.play();
//}
//
//function leftPaneMouse::onMouseLeave(%this)
//{
    //%this.pane.paneTween.reverse();
    //%this.pane.paneTween.play();
//}

function rightPane::onAdd(%this)
{
    %this.position = (getWord(PlayGui.extent, 0) - 12) SPC getWord(%this.position, 1);
    %x = getWord(PlayGui.extent, 0) - getWord(%this.extent, 0);
    %y = getWord(%this.position, 1);
    if(isObject(%this.paneTween))
        %this.paneTween.delete();
    %this.paneTween = UITwillex.to(250, %this, "position:"@%x@" "@%y);
    rightPaneMouse.pane = %this;
    %this.calcButtonGrid();
    %this.clear();
    for(%i = 0; %i < 10; %i++)
    {
        // add some test buttons
        %btnName = "R" @ %i + 1;
        %this.addButton(%btnName, "", "");
    }
    %this.setContentAlignment("right", "center");
}

function rightPane::onResize(%this, %width, %height)
{
    %this = %this.getId();
    %this.position = (getWord(PlayGui.extent, 0) - 12) SPC getWord(%this.position, 1);
    %x = getWord(PlayGui.extent, 0) - getWord(%this.extent, 0);
    %y = getWord(%this.position, 1);
    if(isObject(%this.paneTween))
        %this.paneTween.delete();
    %this.paneTween = UITwillex.to(250, %this, "position:"@%x@" "@%y);
    rightPaneMouse.pane = %this;
}

function rightPane::onRemove(%this)
{
    if(isObject(%this.paneTween))
        %this.paneTween.delete();
}

function rightPaneMouse::onMouseUp(%this)
{
    %this.pane.selectWindow();
    if(%this.extended == false)
    {
        %this.pane.paneTween.forward();
        %this.pane.paneTween.play();
        %this.extended = true;
    }
    else
    {
        %this.pane.paneTween.reverse();
        %this.pane.paneTween.play();
        %this.extended = false;
    }
}

//function rightPaneMouse::onMouseEnter(%this)
//{
    //%this.pane.paneTween.forward();
    //%this.pane.paneTween.play();
//}
//
//function rightPaneMouse::onMouseLeave(%this)
//{
    //%this.pane.paneTween.reverse();
    //%this.pane.paneTween.play();
//}

function bottomPane::onAdd(%this)
{
    %this.position = "\""@(getWord(PlayGui.extent, 0) /2) - (getWord(%this.extent, 0) / 2) SPC getWord(PlayGui.extent, 0) - 12@"\"";
    %x = getWord(%this.position, 0);
    %y = getWord(PlayGui.extent, 1) - getWord(%this.extent, 1);
    if(isObject(%this.paneTween))
        %this.paneTween.delete();
    %this.paneTween = UITwillex.to(250, %this, "position:"@%x@" "@%y);
    bottomPaneMouse.pane = %this;
    %this.calcButtonGrid();
    %this.clear();
    for(%i = 0; %i < 10; %i++)
    {
        // add some test buttons
        %btnName = "B" @ %i + 1;
        %this.addButton(%btnName, "", "");
    }
    %this.setContentAlignment("center", "bottom");
}

function bottomPane::onResize(%this, %width, %height)
{
    %this = %this.getId();
    %paneWidth = getWord(%this.extent, 0);
    %xPos = (%width / 2) - (%paneWidth / 2);
    %this.position = %xPos SPC (%height - 12);
    %x = getWord(%this.position, 0);
    %y = %height - getWord(%this.extent, 1);
    if(isObject(%this.paneTween))
        %this.paneTween.delete();
    %this.paneTween = UITwillex.to(250, %this, "position:"@%x@" "@%y);
    bottomPaneMouse.pane = %this;
}

function bottomPane::onRemove(%this)
{
    if(isObject(%this.paneTween))
        %this.paneTween.delete();
}

function bottomPaneMouse::onMouseUp(%this)
{
    %this.pane.selectWindow();
    if(%this.extended == false)
    {
        %this.pane.paneTween.forward();
        %this.pane.paneTween.play();
        %this.extended = true;
    }
    else
    {
        %this.pane.paneTween.reverse();
        %this.pane.paneTween.play();
        %this.extended = false;
    }
}

//function bottomPaneMouse::onMouseEnter(%this)
//{
    //%this.pane.paneTween.forward();
    //%this.pane.paneTween.play();
//}
//
//function bottomPaneMouse::onMouseLeave(%this)
//{
    //%this.pane.paneTween.reverse();
    //%this.pane.paneTween.play();
//}

function refreshBottomTextCtrl()
{
    BottomPrintText.position = "0 0";
}

function refreshCenterTextCtrl()
{
    CenterPrintText.position = "0 0";
}
