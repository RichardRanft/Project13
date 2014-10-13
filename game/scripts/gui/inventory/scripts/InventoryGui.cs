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

// Example Store GUI - the store inventory is in a vertical scroll container on 
// the left and the player inventory is in a grid container on the right.  The
// grid container could be paged pretty easily.

// For drag-and-drop management the infrastructure gets trickier.  Each type of
// container has to have a handler for dropped objects.  The vertical scroll
// container should probably insert items where dropped unless the item is in
// inventory; then it should simply increment the item count.  This might cause
// items not displayed because of a 0 item count to re-appear.
// The grid container should place the dropped object in the cell over which it
// was dropped.  If dropped on an occupied cell, we can do a few things: slide it
// to the next "nearest" available cell, or drop in the cell but shift the item
// already there to the next "nearest" available cell, or drop our item and pick 
// up the item that is there.  The last option is my favorite but is trickier 
// because mouse button states and drag-drop states have to be fooled into not
// dropping the newly-picked-up item immediately.

/// <summary>
/// Catch all in case there's something that catches drag and drops beneath us.
/// </summary>
/// <param name="control"> The control that was dropped.</param>
/// <param name="position"> The position the control was dropped at.</param>
function InventoryDialog::onControlDropped( %this, %control, %position )
{
    // check contained controls.  If any of them handle dropped controls then
    // let them do it.
    if ( %this.storePane.pointInControl( %position.x, %position.y ) )
        %this.storePane.onControlDropped( %control, %position );
    if ( %this.inventoryPane.pointInControl( %position.x, %position.y ) )
        %this.inventoryPane.onControlDropped( %control, %position );
}

function InventoryDialog::deleteObject(%this, %obj)
{
    if (%obj $= "" || !isObject(%obj))
        return;
    %childCount = %obj.getCount();
    for(%i = 0; %i < %childCount; %i++)
    {
        %obj.getObject(%i).delete();
    }
    %obj.delete();
}

function InventoryDialog::onDialogPush(%this)
{
}

function InventoryDialog::onDialogPop(%this)
{
}

function InventoryDialog::onWake(%this)
{
    if ( !%this.initialized )
        %this.initialize();
    %this.populateStorePane();
}

function InventoryDialog::onSleep(%this)
{
}

function InventoryDialog::initialize(%this)
{
    // set up store inventory
    %newInv = new ScriptObject()
    {
        class="InventoryObject";
    };
    PlayerInventory.storeInventory = %newInv;
    // for my basic store item I'm using a format as follows:
    // asset label cost stock objectTag
    // asset: the asset of the image to display
    // label: the name of the object to display
    // cost: the item cost
    // stock: the number of the item available in the store, -1 is infinite
    // objectTag: a tag that can be used to link our store object with a game object.
    PlayerInventory.storeInventory.addInventoryItem("scripts/gui/assets/images/Planetoid.png Rocks 10 5 Rock01");
    PlayerInventory.storeInventory.addInventoryItem("scripts/gui/assets/images/TD_Bones_01.png Skulls 8 5 Skull01");
    PlayerInventory.storeInventory.addInventoryItem("scripts/gui/assets/images/brick_01.png Food 25 10 Brick01");
    PlayerInventory.storeInventory.addInventoryItem("scripts/gui/assets/images/TD_Crystal_blue.png Water 5 -1 Water01");
    PlayerInventory.storeInventory.addInventoryItem("scripts/gui/assets/images/TD_Crystal_red.png Knife 50 5 Knife01");
    // set up store container
    PlayerInventory.storeContainer = createVerticalScrollContainer();
    %this.storePane = new GuiControl()
    {
        Name="InventoryStorePane";
        class="storeContainerClass";
        Profile="InventoryDefaultProfile";
        HorizSizing="right";
        VertSizing="bottom";
        Position="0 0";
        Extent="240 768";
        MinExtent="240 320";
        Visible="1";
    };
    %this.addGuiControl(%this.storePane);
    %this.storePane.add(PlayerInventory.storeContainer);
    PlayerInventory.storeContainer.resizeContainer();

    // set up container inventory
    %newInv = new ScriptObject()
    {
        class="InventoryObject";
    };
    PlayerInventory.containerInventory = %newInv;
    // set up inventory container
    %this.inventoryPane = new GuiControl()
    {
        Name="InventoryInventoryPane";
        class="inventoryContainerClass";
        Profile="InventoryDefaultProfile";
        HorizSizing="relative";
        VertSizing="relative";
        Position="250 0";
        Extent="774 650";
        MinExtent="240 320";
        Visible="1";
    };
    %this.addGuiControl(%this.inventoryPane);
    PlayerInventory.inventoryContainer = createInventoryGridContainer(%this.inventoryPane);
    PlayerInventory.inventoryContainer.fillFromTopLeft = true;
    %this.inventoryPane.add(PlayerInventory.inventoryContainer);
    PlayerInventory.inventoryContainer.resizeContainer();
    PlayerInventory.inventoryContainer.setCellBackground("scripts/gui/assets/gui/bagGrid.png", 64, 64);

    %infoPanePosX = %this.inventoryPane.Position.x;
    %infoPanePosY = %this.inventoryPane.Position.y;
    
    %infoPanePosY += %this.inventoryPane.Extent.y + 18;
    %infoPanePos = %infoPanePosX SPC %infoPanePosY;
    %this.infoPane = new GuiControl()
    {
        Name="InfoPane";
        Profile="InventoryDefaultProfile";
        HorizSizing="relative";
        VertSizing="relative";
        Position=%infoPanePos;
        Extent="774 50";
        MinExtent="10 10";
        Visible="1";
    };
    %this.addGuiControl(%this.infoPane);

    %noMoneyLabel = new GuiTextCtrl()
    {
        Profile="InventoryRedTextProfile";
        HorizSizing="relative";
        VertSizing="relative";
        Position="10 10";
        Extent="350 20";
        MinExtent="10 10";
        Visible="1";
        text = "";
    };
    %this.infoPane.addGuiControl(%noMoneyLabel);
    %this.noCashCtrl = %noMoneyLabel;

    %moneyLabel = new GuiTextCtrl()
    {
        Profile="InventoryDefaultProfile";
        HorizSizing="relative";
        VertSizing="relative";
        Position="10 30";
        Extent="100 20";
        MinExtent="10 10";
        Visible="1";
        text = "Current Cash: ";
    };
    %this.infoPane.addGuiControl(%moneyLabel);

    %currentCash = new GuiTextCtrl()
    {
        Profile="InventoryDefaultProfile";
        HorizSizing="relative";
        VertSizing="relative";
        Position=(%moneyLabel.Position.x + %moneyLabel.Extent.x) SPC "30";
        Extent="50 20";
        MinExtent="10 10";
        Visible="1";
        text = "";
    };
    %this.infoPane.addGuiControl(%currentCash);
    %this.currentCashCtrl = %currentCash;
    //if ( $PlayerMoney $= "" )
        //$PlayerMoney = 500;
    %this.currentCashCtrl.text = $PlayerMoney;

    %this.initialized = true;
}

function InventoryDialog::populateStorePane(%this)
{
    PlayerInventory.storeContainer.clear();
    %contents = PlayerInventory.storeInventory.getContents();
    %itemCount = getRecordCount(%contents);
    for (%i = 0; %i < %itemCount; %i++)
    {
        %itemRecord = getRecord(%contents, %i);
        %image = getWord(%itemRecord, 0);
        %name = getWord(%itemRecord, 1);
        %price = getWord(%itemRecord, 2);
        %button = %this.createItemButton(%image, %name, %price);
        PlayerInventory.storeContainer.addButton(%button, PlayerInventory.storeInventory, "invButtonClick", %itemRecord SPC PlayerInventory.storeContainer.getID());
    }
    PlayerInventory.storeContainer.resizeContainer();
}

function InventoryDialog::createItemButton(%this, %itemImage, %itemName, %itemPrice)
{
    %button = new GuiControl()
    {
        Profile="InventoryDefaultProfile";
        class="InventoryFrameControl";
        HorizSizing="right";
        VertSizing="bottom";
        Position="0 0";
        Extent="190 60";
        MinExtent="100 60";
        Visible="1";
    };
    
    %buttonBitmap = new GuiButtonCtrl()
    {
        Profile="InventoryButtonProfile";
        HorizSizing="right";
        VertSizing="bottom";
        Position = "0 0";
        Extent="190 60";
        MinExtent="100 60";
        Visible="1";
    };
    %button.addGuiControl(%buttonBitmap);
    
    %itemSprite = new GuiBitmapCtrl()
    {
        Profile="InventoryDefaultProfile";
        HorizSizing="right";
        VertSizing="bottom";
        Position = "5 5";
        Extent="50 50";
        MinExtent="50 50";
        Visible="1";
        bitmap = %itemImage;
    };
    %button.addGuiControl(%itemSprite);

    %labelPos = (%itemSprite.Position.x + %itemSprite.Extent.x + 5) SPC "18";
    %itemLabel = new GuiTextCtrl()
    {
        canSaveDynamicFields="0";
        isContainer="0";
        Profile="InventoryDefaultProfile";
        HorizSizing="right";
        VertSizing="bottom";
        Position=%labelPos;
        Extent="84 23";
        MinExtent="8 2";
        canSave="1";
        Visible="1";
        Active="0";
        hovertime="1000";
        text=%itemName;
        maxLength="1024";
    };
    %button.addGuiControl(%itemLabel);

    %labelPos = (%itemLabel.Position.x + %itemLabel.Extent.x + 5) SPC "18";
    %itemPriceLabel = new GuiTextCtrl()
    {
        canSaveDynamicFields="0";
        isContainer="0";
        Profile="InventoryDefaultProfile";
        HorizSizing="right";
        VertSizing="bottom";
        Position=%labelPos;
        Extent="23 23";
        MinExtent="8 2";
        canSave="1";
        Visible="1";
        Active="0";
        hovertime="1000";
        text=%itemPrice;
        maxLength="1024";
    };
    %button.addGuiControl(%itemPriceLabel);
    
    return %button;
}


function storeContainerClass::onControlDropped(%this, %control, %position)
{
    %container = PlayerInventory.storeContainer;
    %dropPosition = Vector2Sub(%position, %container.getGlobalPosition());
    // code to sell item to store.  Add to store inventory, remove from 
    // player inventory, credit player with money.
    %source = getWord(%control.data, 5);
    if (%source !$= %container.getID())
        PlayerInventory.containerPlayerInventory.sellItem(%control.data);
}

function inventoryContainerClass::onControlDropped(%this, %control, %position)
{
    %container = InventoryDialog.inventoryPane;
    %dropPosition = Vector2Sub(%position, %container.getGlobalPosition());
}