//-----------------------------------------------------------------------------
// Copyright (c) 2013 Roostertail Games
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

// Load GUI profiles.
exec("./guiProfiles.cs");

// Load Inventory scripts.
exec( "./scripts/Inventory.cs" );
exec( "./Inventory.gui" );
exec( "./scripts/InventoryGui.cs" );
exec( "./scripts/verticalScrollContainer.cs" );
exec( "./scripts/inventoryGridContainer.cs" );
exec( "./scripts/inventoryEventManager.cs" );

function PlayerInventory::create( %this )
{    
    // Load the preferences.
    %this.loadPreferences();
    
    %this.UI = InventoryGui;
    
    // initialize event manager
    initializeInventoryEventManager();
}

//-----------------------------------------------------------------------------

function PlayerInventory::destroy( %this )
{
    destroyInventoryEventManager();
    echo ( " @@@ PlayerInventory::destroy()");
    %this.savePreferences();
}

//-----------------------------------------------------------------------------

function PlayerInventory::loadPreferences( %this )
{
    // Load the default preferences.
    exec( "./scripts/inventoryPreferences.cs" );
    
    // Load the last session preferences if available.
    if ( isFile("preferences.cs") )
        exec( "preferences.cs" );
    if ( !$PlayerMoneyLoaded )
        $PlayerMoney = $pref::Inventory::default::playerMoney;
}

//-----------------------------------------------------------------------------

function PlayerInventory::savePreferences( %this )
{
    // Export only the Inventory preferences.
    export("$pref::PlayerInventory::*", "preferences.cs", false );
}

function PlayerInventory::createDraggingControl(%this, %sprite, %spritePosition, %mousePosition, %size)
{
    InventoryDialog.noCashCtrl.text = "";
    // Create the drag and drop control.
    %dragControl = new GuiDragAndDropControl()
    {
        Profile = "GuiDragAndDropProfile";
        Position = %spritePosition;
        Extent = %size;
        deleteOnMouseUp = true;
    };

    // And the sprite to display.
    %spritePane = new GuiBitmapCtrl()
    {
        Extent = %size;
        Profile = "InventoryDefaultProfile";
        bitmap = %sprite.bitmap;
        data = %sprite.data;
        parentCell = %sprite.parentCell;
    };
    //%spritePane.Frame = %sprite.Frame;
    %spritePane.frameNumber = %sprite.frameNumber;
    %spritePane.spriteClass = %sprite.class;

    // Place the guis.
    InventoryDialog.add(%dragControl);
    %dragControl.add(%spritePane);

    // Figure the position to place the control relative to the mouse.
    %xOffset = getWord(%mousePosition, 0) - getWord(%spritePosition, 0);
    %yOffset = getWord(%mousePosition, 1) - getWord(%spritePosition, 1);

    %dragControl.startDragging(%xOffset, %yOffset);
}

