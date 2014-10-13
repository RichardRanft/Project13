//-----------------------------------------------------------------------------
// Copyright (c) 2013 GarageGames, LLC
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

$platformFontType = ($platform $= "windows") ? "lucida console" : "monaco";
$platformFontSize = ($platform $= "ios") ? 18 : 12;

//-----------------------------------------------------------------------------

if(!isObject(GrabCursor)) new GuiCursor(GrabCursor)
{
    hotSpot = "4 4";
    renderOffset = "0 0";
    bitmapName = "./images/defaultCursor.png";
};

//---------------------------------------------------------------------------------------------
// GuiDefaultProfile is a special profile that all other profiles inherit defaults from. It
// must exist.
//---------------------------------------------------------------------------------------------
if(!isObject(InventoryDefaultProfile)) new GuiControlProfile (InventoryDefaultProfile)
{
    tab = false;
    canKeyFocus = false;
    hasBitmapArray = false;
    mouseOverSelected = false;

    // fill color
    opaque = false;
    fillColor = "211 211 211";
    fillColorHL = "244 244 244";
    fillColorNA = "244 244 244";

    // border color
    border = 0;
    borderColor   = "100 100 100 255";
    borderColorHL = "128 128 128";
    borderColorNA = "64 64 64";

    // font
    fontType = $platformFontType;
    fontSize = $platformFontSize;

    fontColor = "0 0 0";
    fontColorHL = "32 100 100";
    fontColorNA = "0 0 0";
    fontColorSEL= "10 10 10";

    // bitmap information
    bitmap = "./images/window.png";
    bitmapBase = "";
    textOffset = "0 0";

    // used by guiTextControl
    modal = true;
    justify = "left";
    autoSizeWidth = false;
    autoSizeHeight = false;
    returnTab = false;
    numbersOnly = false;
    cursorColor = "0 0 0 255";

    // sounds
    soundButtonDown = $ButtonSound.fileName;
    soundButtonOver = "";
};

// ----------------------------------------------------------------------------

if (!isObject(InventoryTransparentProfile)) new GuiControlProfile (InventoryTransparentProfile : InventoryDefaultProfile)
{
    opaque = false;
    border = false;
};

// ----------------------------------------------------------------------------

if(!isObject(InventorySolidProfile)) new GuiControlProfile (InventorySolidProfile)
{
   opaque = true;
   border = true;
};

// ----------------------------------------------------------------------------

if (!isObject(InventoryToolTipProfile)) new GuiControlProfile (InventoryToolTipProfile : InventoryDefaultProfile)
{
    fillColor = "246 220 165 255";
    
    fontType = $platformFontType;
    fontSize = $platformFontSize;
};

// ----------------------------------------------------------------------------

if (!isObject(InventoryPopupMenuItemBorder)) new GuiControlProfile (InventoryPopupMenuItemBorder : InventoryDefaultProfile)
{
    bitmap = "./images/scroll.png";
    hasBitmapArray = true;
};

// ----------------------------------------------------------------------------

if (!isObject(InventoryPopUpMenuDefault)) new GuiControlProfile (InventoryPopUpMenuDefault)
{
    tab = false;
    canKeyFocus = false;
    hasBitmapArray = false;
    mouseOverSelected = false;

    // fill color
    opaque = false;
    fillColor = "255 255 255 192";
    fillColorHL = "255 0 0 192";
    fillColorNA = "0 0 255 255";

    // border color
    border = 1;
    borderColor    = "100 100 100 255";
    borderColorHL = "0 128 0 255";
    borderColorNA = "0 226 226 52";

    // font
    fontType = $platformFontType;
    fontSize = $platformFontSize;

    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    fontColorNA = "0 0 0 255";
    fontColorSEL= "255 255 255 255";

    // bitmap information
    bitmap = "./images/scroll.png";
    hasBitmapArray = true;
    bitmapBase = "";
    textOffset = "0 0";

    // used by guiTextControl
    modal = true;
    justify = "left";
    autoSizeWidth = false;
    autoSizeHeight = false;
    returnTab = false;
    numbersOnly = false;
    cursorColor = "0 0 0 255";

    profileForChildren = InventoryPopupMenuItemBorder;
    // sounds
    soundButtonDown = "";
    soundButtonOver = "";
};

// ----------------------------------------------------------------------------

if (!isObject(InventoryPopUpMenuProfile)) new GuiControlProfile (InventoryPopUpMenuProfile : InventoryPopUpMenuDefault)
{
    textOffset = "6 3";
    justify = "center";
    bitmap = "./images/dropDown.png";
    hasBitmapArray = true;
    border = -3;
    profileForChildren = InventoryPopUpMenuDefault;
    opaque = true;
};

//-----------------------------------------------------------------------------

if (!isObject(InventoryTextProfile)) new GuiControlProfile (InventoryTextProfile)
{
    border=false;

    // font
    fontType = $platformFontType;
    fontSize = $platformFontSize;

    fontColor = "white";

    modal = true;
    justify = "left";
    autoSizeWidth = false;
    autoSizeHeight = false;
    returnTab = false;
    numbersOnly = false;
    cursorColor = "0 0 0 255";
};

//-----------------------------------------------------------------------------

if (!isObject(InventoryRedTextProfile)) new GuiControlProfile (InventoryRedTextProfile : InventoryTextProfile)
{
    border=false;

    // font
    fontType = $platformFontType;
    fontSize = $platformFontSize;

    fontColor = "red";

    modal = true;
    justify = "left";
    autoSizeWidth = false;
    autoSizeHeight = false;
    returnTab = false;
    numbersOnly = false;
    cursorColor = "0 0 0 255";
};

//-----------------------------------------------------------------------------

if (!isObject(InventoryCheckBoxProfile)) new GuiControlProfile (InventoryCheckBoxProfile)
{
    opaque = false;
    fontColor = "white";
    fillColor = "232 232 232 255";
    fontColorHL = "white";
    border = false;
    borderColor = "0 0 0 255";
    fontType = $platformFontType;
    fontSize = $platformFontSize;
    fixedExtent = true;
    justify = "left";
    bitmap = "./images/checkBox.png";
    hasBitmapArray = true;
};

//-----------------------------------------------------------------------------

if(!isObject(InventoryConsoleProfile)) new GuiControlProfile (InventoryConsoleProfile)
{
    fontType = $platformFontType;
    fontSize = $platformFontSize * 1.1;
    fontColor = White;
    fontColorHL = LightSlateGray;
    fontColorNA = Red;
    fontColors[6] = "100 100 100";
    fontColors[7] = "100 100 0";
    fontColors[8] = "0 0 100";
    fontColors[9] = "0 100 0";
};

//-----------------------------------------------------------------------------

if (!isObject(InventoryTextEditProfile)) new GuiControlProfile (InventoryTextEditProfile)
{
    fontSize = $platformFontSize;
    opaque = false;
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "127 127 127 52";
    border = -2;
    bitmap = "./images/textEdit.png";
    borderColor = "40 40 40 10";
    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    fontColorNA = "0 0 0 52";
    fontColorSEL = "0 0 0 255";
    textOffset = "5 2";
    autoSizeWidth = false;
    autoSizeHeight = false;
    tab = false;
    canKeyFocus = true;
    returnTab = true;
};

//-----------------------------------------------------------------------------

if(!isObject(InventoryNumberEditProfile)) new GuiControlProfile (InventoryNumberEditProfile: InventoryTextEditProfile)
{
   numbersOnly = true;
};

//-----------------------------------------------------------------------------

if(!isObject(InventoryConsoleTextEditProfile)) new GuiControlProfile (InventoryConsoleTextEditProfile : InventoryTextEditProfile)
{
    fontType = $platformFontType;
    fontSize = $platformFontSize * 1.1;
};

//-----------------------------------------------------------------------------

if(!isObject(InventoryScrollProfile)) new GuiControlProfile (InventoryScrollProfile)
{
    opaque = true;
    fillColor = "255 255 255";
    border = 1;
    borderThickness = 2;
    bitmap = "./images/scrollBar.png";
    hasBitmapArray = true;
};

//-----------------------------------------------------------------------------

if(!isObject(InventoryScrollProfile)) new GuiControlProfile( InventoryScrollProfile : GuiScrollProfile )
{
    opaque = true;
    fillColor = "0 0 0 120";
    border = 3;
    borderThickness = 0;
    borderColor = "0 0 0";
};

//-----------------------------------------------------------------------------

if(!isObject(InventoryToolboxProfile)) new GuiControlProfile( InventoryToolboxProfile : GuiScrollProfile )
{
    opaque = true;
    fillColor = "255 255 255 220";
    border = 3;
    borderThickness = 0;
    borderColor = "0 0 0";
};

//-----------------------------------------------------------------------------

if(!isObject(InventoryWindowProfile)) new GuiControlProfile (InventoryWindowProfile : GuiDefaultProfile)
{
    // fill color
    opaque = false;
    fillColor = "0 0 0 92";

    // font
    fontType = $platformFontType;
    fontSize = $platformFontSize;
    fontColor = "255 255 255 255";
}; 

//-----------------------------------------------------------------------------

if (!isObject(InventoryButtonProfile)) new GuiControlProfile (InventoryButtonProfile)
{
    opaque = true;
    border = -1;
    fontColor = "white";
    fontColorHL = "229 229 229 255";
    fixedExtent = true;
    justify = "center";
    canKeyFocus = false;
    fontType = $platformFontType;
    bitmap = "./images/smallButtonContainer.png";
};

//-----------------------------------------------------------------------------

if (!isObject(BlueButtonProfile)) new GuiControlProfile (BlueButtonProfile : GuiButtonProfile)
{
    fontSize = $platformFontSize;
    fontColor = "255 255 255 255";
    fontColorHL = "255 255 255 255";
    bitmap = "./images/blueButton.png";
};

//-----------------------------------------------------------------------------

if (!isObject(RedButtonProfile)) new GuiControlProfile (RedButtonProfile : GuiButtonProfile)
{
    fontSize = $platformFontSize;
    fontColor = "255 255 255 255";
    fontColorHL = "255 255 255 255";
    bitmap = "./images/redButton.png";
};

//-----------------------------------------------------------------------------

if (!isObject(GreenButtonProfile)) new GuiControlProfile (GreenButtonProfile : GuiButtonProfile)
{
    fontSize = $platformFontSize;
    fontColor = "255 255 255 255";
    fontColorHL = "255 255 255 255";
    bitmap = "./images/greenButton.png";
};

//-----------------------------------------------------------------------------

if (!isObject(InventoryRadioProfile)) new GuiControlProfile (InventoryRadioProfile : GuiDefaultProfile)
{
    fillColor = "232 232 232 255";
    fixedExtent = true;
    bitmap = "./images/radioButton.png";
    hasBitmapArray = true;
};

//-----------------------------------------------------------------------------

if (!isObject(InventorySliderProfile)) new GuiControlProfile (InventorySliderProfile)
{
    bitmap = "./images/slider.png";
    fontType = $platformFontType;
    fontSize = $platformFontSize;
    fontColor = "white";
};

//-----------------------------------------------------------------------------

if (!isObject(InventorySliderNoTextProfile)) new GuiControlProfile (InventorySliderNoTextProfile)
{
    bitmap = "./images/slider.png";
    fontColor = "white";
    fontSize = 1;
};

//-----------------------------------------------------------------------------

if (!isObject(InventorySpinnerProfile)) new GuiControlProfile (InventorySpinnerProfile)
{
    fontType = $platformFontType;
    fontSize = $platformFontSize;
    opaque = false;
    justify = "center";
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "127 127 127 52";
    numbersOnly = true;
    border = -2;
    bitmap = "./images/textEdit_noSides.png";
    borderColor = "40 40 40 10";
    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    fontColorNA = "0 0 0 52";
    fontColorSEL = "0 0 0 255";
    textOffset = "4 2";
    autoSizeWidth = false;
    autoSizeHeight = false;
    tab = false;
    canKeyFocus = true;
    returnTab = true;
};

//-----------------------------------------------------------------------------

if (!isObject(InventoryLightScrollProfile)) new GuiControlProfile (InventoryLightScrollProfile : GuiScrollProfile)
{
    opaque = false;
    fillColor = "212 216 220";
    border = 0;
    bitmap = "./images/scrollBar.png";
    hasBitmapArray = true;
};

//-----------------------------------------------------------------------------

if (!isObject(InventorySunkenContainerProfile)) new GuiControlProfile (InventorySunkenContainerProfile)
{
    opaque = false;
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "127 127 127 52";
    border = -2;
    bitmap = "core/art/gui/images/textEdit.png";
    borderColor = "40 40 40 10";
   hasBitmapArray = "0";
};


if (!isObject(GuiDragAndDropProfile)) new GuiControlProfile (GuiDragAndDropProfile : InventoryDefaultProfile)
{
};

if(!isObject(InventoryScrollProfile)) new GuiControlProfile (InventoryScrollProfile)
{
    opaque = true;
    fillColor = "255 255 255";
    border = 1;
    borderThickness = 2;
    bitmap = "core/art/gui/images/scrollBar.png";
    hasBitmapArray = true;
};

if (!isObject(InventoryTransparentScrollProfile)) new GuiControlProfile (InventoryTransparentScrollProfile : InventoryScrollProfile)
{
    opaque = false;
    border = false;
};
