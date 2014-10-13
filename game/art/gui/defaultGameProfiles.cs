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
// Override base controls
//GuiMenuButtonProfile.soundButtonOver = "AudioButtonOver";
//GuiMenuButtonProfile.soundButtonDown = "AudioButtonDown";
if( $Gui::fontCacheDirectory $= "")
{
   $Gui::fontCacheDirectory = expandFilename( "~/fonts" );
}

// ----------------------------------------------------------------------------
// GuiDefaultProfile is a special profile that all other profiles inherit
// defaults from. It must exist.
// ----------------------------------------------------------------------------

if( !isObject( GuiDefaultProfile ) )
new GuiControlProfile (GuiDefaultProfile)
{
   tab = false;
   canKeyFocus = false;
   hasBitmapArray = false;
   mouseOverSelected = false;

   // fill color
   opaque = false;
   fillColor = "242 241 240";
   fillColorHL ="228 228 235";
   fillColorSEL = "98 100 137";
   fillColorNA = "255 255 255 ";

   // border color
   border = 0;
   borderColor   = "100 100 100"; 
   borderColorHL = "50 50 50 50";
   borderColorNA = "75 75 75"; 

   // font
   fontType = "Arial";
   fontSize = 14;
   fontCharset = ANSI;

   fontColor = "0 0 0";
   fontColorHL = "0 0 0";
   fontColorNA = "0 0 0";
   fontColorSEL= "255 255 255";

   // bitmap information
   bitmap = "";
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
   //soundButtonDown = "";
   //soundButtonOver = "";
};

if( !isObject( GuiSolidDefaultProfile ) )
new GuiControlProfile (GuiSolidDefaultProfile : GuiDefaultProfile)
{
   opaque = true;
   border = true;
   category = "Core";
};

if( !isObject( GuiTransparentProfile ) )
new GuiControlProfile (GuiTransparentProfile : GuiDefaultProfile)
{
   opaque = false;
   border = false;
   category = "Core";
};

if( !isObject( GuiGroupBorderProfile ) )
new GuiControlProfile( GuiGroupBorderProfile : GuiDefaultProfile )
{
   border = false;
   opaque = false;
   hasBitmapArray = true;
   bitmap = "./images/group-border";
   category = "Core";
};

if( !isObject( GuiTabBorderProfile ) )
new GuiControlProfile( GuiTabBorderProfile : GuiDefaultProfile )
{
   border = true;
   opaque = false;
   hasBitmapArray = true;
   bitmap = "./images/tab-border";
   category = "Core";
};

if( !isObject( GuiToolTipProfile ) )
new GuiControlProfile (GuiToolTipProfile : GuiDefaultProfile)
{
   // fill color
   fillColor = "239 237 222";

   // border color
   borderColor   = "138 134 122";

   // font
   fontType = "Arial";
   fontSize = 14;
   fontColor = "0 0 0";

   category = "Core";
};

if( !isObject( GuiModelessDialogProfile ) )
new GuiControlProfile( GuiModelessDialogProfile : GuiDefaultProfile )
{
   modal = false;
   category = "Core";
};

if( !isObject( GuiFrameSetProfile ) )
new GuiControlProfile (GuiFrameSetProfile : GuiDefaultProfile)
{
   fillcolor = "255 255 255";
   borderColor = "246 245 244";
   border = 1;
   opaque = true;
   border = true;
   category = "Core";
};

if( !isObject( GuiWindowProfile ) )
new GuiControlProfile (GuiWindowProfile : GuiDefaultProfile)
{
   opaque = false;
   border = 2;
   fillColor = "242 241 240";
   fillColorHL = "221 221 221";
   fillColorNA = "200 200 200";
   fontColor = "50 50 50";
   fontColorHL = "0 0 0";
   bevelColorHL = "255 255 255";
   bevelColorLL = "0 0 0";
   text = "untitled";
   bitmap = "./images/window";
   textOffset = "8 4";
   hasBitmapArray = true;
   justify = "left";
   category = "Core";
};

if( !isObject( GuiInputCtrlProfile ) )
new GuiControlProfile( GuiInputCtrlProfile : GuiDefaultProfile )
{
   tab = true;
   canKeyFocus = true;
   category = "Core";
};

if( !isObject( GuiTextProfile ) )
new GuiControlProfile (GuiTextProfile : GuiDefaultProfile)
{
   justify = "left";
   fontColor = "20 20 20";
   category = "Core";
   fontColors[0] = "20 20 20 255";
};

if( !isObject( GuiTextRightProfile ) )
new GuiControlProfile (GuiTextRightProfile : GuiTextProfile)
{
   justify = "right";
   category = "Core";
};

if( !isObject( GuiAutoSizeTextProfile ) )
new GuiControlProfile (GuiAutoSizeTextProfile : GuiTextProfile)
{
   fontColor = "0 0 0";
   autoSizeWidth = true;
   autoSizeHeight = true;   
   category = "Core";
};

if( !isObject( GuiMediumTextProfile ) )
new GuiControlProfile( GuiMediumTextProfile : GuiTextProfile )
{
   fontSize = 24;
   category = "Core";
};

if( !isObject( GuiBigTextProfile ) )
new GuiControlProfile( GuiBigTextProfile : GuiTextProfile )
{
   fontSize = 36;
   category = "Core";
};

if( !isObject( GuiMLTextProfile ) )
new GuiControlProfile( GuiMLTextProfile : GuiDefaultProfile )
{
   fontColorLink = "100 100 100";
   fontColorLinkHL = "255 255 255";
   autoSizeWidth = true;
   autoSizeHeight = true;  
   border = false;
   category = "Core";
};

if( !isObject( GuiTextArrayProfile ) )
new GuiControlProfile( GuiTextArrayProfile : GuiTextProfile )
{
   fontColor = "50 50 50";
   fontColorHL = " 0 0 0";
   fontColorSEL = "0 0 0";
   fillColor ="200 200 200";
   fillColorHL = "228 228 235";
   fillColorSEL = "200 200 200";
   border = false;
   category = "Core";
};

if( !isObject( GuiTextEditProfile ) )
new GuiControlProfile( GuiTextEditProfile : GuiDefaultProfile )
{
   opaque = true;
   bitmap = "./images/textEdit";
   hasBitmapArray = true; 
   border = -2; // fix to display textEdit img
   //borderWidth = "1";  // fix to display textEdit img
   //borderColor = "100 100 100";
   fillColor = "242 241 240 0";
   fillColorHL = "255 255 255";
   fontColor = "0 0 0";
   fontColorHL = "255 255 255";
   fontColorSEL = "98 100 137";
   fontColorNA = "200 200 200";
   textOffset = "4 2";
   autoSizeWidth = false;
   autoSizeHeight = true;
   justify = "left";
   tab = true;
   canKeyFocus = true;   
   category = "Core";
};

if( !isObject( GuiProgressProfile ) )
new GuiControlProfile( GuiProgressProfile : GuiDefaultProfile )
{
   opaque = false;
   fillColor = "0 162 255 200";
   border = true;
   borderColor   = "50 50 50 200";
   category = "Core";
};

if( !isObject( GuiProgressBitmapProfile ) )
new GuiControlProfile( GuiProgressBitmapProfile : GuiDefaultProfile )
{
   border = false;
   hasBitmapArray = true;
   bitmap = "./images/loadingbar";
   category = "Core";
};

if( !isObject( GuiProgressTextProfile ) )
new GuiControlProfile( GuiProgressTextProfile : GuiTextProfile )
{
   fontSize = "14";
	fontType = "Arial";
   fontColor = "0 0 0";
   justify = "center";
   category = "Core";   
};

if( !isObject( GuiButtonProfile ) )
new GuiControlProfile( GuiButtonProfile : GuiDefaultProfile )
{
   opaque = true;
   border = true;
	 
   fontColor = "50 50 50";
   fontColorHL = "0 0 0";
	 fontColorNA = "200 200 200";
	 //fontColorSEL ="0 0 0";
   fixedExtent = false;
   justify = "center";
   canKeyFocus = false;
	bitmap = "./images/button";
   hasBitmapArray = false;
   category = "Core";
};

if( !isObject( GuiMenuButtonProfile ) )
new GuiControlProfile( GuiMenuButtonProfile : GuiDefaultProfile )
{
   opaque = true;
   border = false;
   fontSize = 18;
   fontType = "Arial Bold";
   fontColor = "50 50 50";
   fontColorHL = "0 0 0";
   fontColorNA = "200 200 200";
   //fontColorSEL ="0 0 0";
   fixedExtent = false;
   justify = "center";
   canKeyFocus = false;
	bitmap = "./images/selector-button";
   hasBitmapArray = false;
   category = "Core";
};

if( !isObject( GuiButtonTabProfile ) )
new GuiControlProfile( GuiButtonTabProfile )
{
   opaque = true;
   border = true;
   fontColor = "50 50 50";
   fontColorHL = "0 0 0";
   fontColorNA = "0 0 0";
   fixedExtent = false;
   justify = "center";
   canKeyFocus = false;
   bitmap = "./images/buttontab";
   category = "Core";
};

if( !isObject( GuiCheckBoxProfile ) )
new GuiControlProfile( GuiCheckBoxProfile : GuiDefaultProfile )
{
   opaque = false;
   fillColor = "232 232 232";
   border = false;
   borderColor = "100 100 100";
   fontSize = 14;
   fontColor = "20 20 20";
   fontColorHL = "80 80 80";
	fontColorNA = "200 200 200";
   fixedExtent = true;
   justify = "left";
   bitmap = "./images/checkbox";
   hasBitmapArray = true;
   category = "Core";
};

if( !isObject( GuiScrollProfile ) )
new GuiControlProfile( GuiScrollProfile : GuiDefaultProfile )
{
   opaque = true;
   fillcolor = "255 255 255";
   fontColor = "0 0 0";
   fontColorHL = "150 150 150";
   //borderColor = GuiDefaultProfile.borderColor;
   border = true;
   bitmap = "./images/scrollBar";
   hasBitmapArray = true;
   category = "Core";
};

if( !isObject( GuiOverlayProfile ) )
new GuiControlProfile( GuiOverlayProfile : GuiDefaultProfile )
{
   opaque = true;
   fillcolor = "255 255 255";
   fontColor = "0 0 0";
   fontColorHL = "255 255 255";
	fillColor = "0 0 0 100";
   category = "Core";
};

if( !isObject( GuiSliderProfile ) )
new GuiControlProfile( GuiSliderProfile : GuiDefaultProfile )
{
   bitmap = "./images/slider";
   category = "Core";
};

if( !isObject( GuiSliderBoxProfile ) )
new GuiControlProfile( GuiSliderBoxProfile : GuiDefaultProfile )
{
   bitmap = "./images/slider-w-box";
   category = "Core";
};

// ----------------------------------------------------------------------------
// TODO: Revisit Popupmenu
// ----------------------------------------------------------------------------

if( !isObject( GuiPopupMenuItemBorder ) )
new GuiControlProfile( GuiPopupMenuItemBorder : GuiButtonProfile )
{
   opaque = true;
   border = true;
   fontColor = "0 0 0";
   fontColorHL = "0 0 0";
   fontColorNA = "255 255 255";
   fixedExtent = false;
   justify = "center";
   canKeyFocus = false;
   bitmap = "./images/button";
   category = "Core";
};

if( !isObject( GuiPopUpMenuDefault ) )
new GuiControlProfile( GuiPopUpMenuDefault : GuiDefaultProfile )
{
   opaque = true;
   mouseOverSelected = true;
   textOffset = "3 3";
   border = 0;
   borderThickness = 0;
   fixedExtent = true;
   bitmap = "./images/scrollbar";
   hasBitmapArray = true;
   profileForChildren = GuiPopupMenuItemBorder;
   fillColor = "242 241 240 ";//"255 255 255";//100
   fillColorHL = "228 228 235 ";//"204 203 202";
   fillColorSEL = "98 100 137 ";//"204 203 202";
   // font color is black
   fontColorHL = "0 0 0 ";//"0 0 0";
   fontColorSEL = "255 255 255";//"0 0 0";
   borderColor = "100 100 100";
   category = "Core";
};

if( !isObject( GuiPopUpMenuProfile ) )
new GuiControlProfile( GuiPopUpMenuProfile : GuiPopUpMenuDefault )
{
   textOffset         = "6 4";
   bitmap             = "./images/dropDown";
   hasBitmapArray     = true;
   border             = 1;
   profileForChildren = GuiPopUpMenuDefault;
   category = "Core";
};

if( !isObject( GuiTabBookProfile ) )
new GuiControlProfile( GuiTabBookProfile : GuiDefaultProfile )
{
   fillColorHL = "100 100 100";
   fillColorNA = "150 150 150";
   fontColor = "30 30 30";
   fontColorHL = "0 0 0";
   fontColorNA = "50 50 50";
   fontType = "Arial";
   fontSize = 14;
   justify = "center";
   bitmap = "./images/tab";
   tabWidth = 64;
   tabHeight = 24;
   tabPosition = "Top";
   tabRotation = "Horizontal";
   textOffset = "0 -3";
   tab = true;
   cankeyfocus = true;
   category = "Core";
};

if( !isObject( GuiTabPageProfile ) )
new GuiControlProfile( GuiTabPageProfile : GuiDefaultProfile )
{
   fontType = "Arial";
   fontSize = 10;
   justify = "center";
   bitmap = "./images/tab";
   opaque = true;
   border = false;
   hasBitmapArray = true;
   fillColor = "240 239 238";
   category = "Core";
};

if( !isObject( GuiConsoleProfile ) )
new GuiControlProfile( GuiConsoleProfile : GuiDefaultProfile )
{
   fontType = ($platform $= "macos") ? "Monaco" : "Lucida Console";
   fontSize = ($platform $= "macos") ? 13 : 12;
   fontColor = "255 255 255";
   fontColorHL = "0 255 255";
   fontColorNA = "255 0 0";
   fontColors[6] = "100 100 100";
   fontColors[7] = "100 100 0";
   fontColors[8] = "0 0 100";
   fontColors[9] = "0 100 0";
   category = "Core";
};

if( !isObject( GuiConsoleTextProfile ) )
new GuiControlProfile( GuiConsoleTextProfile : GuiTextProfile )
{   
   fontColor = "0 0 0";
   autoSizeWidth = true;
   autoSizeHeight = true;   
   textOffset = "2 2";
   opaque = true;   
   fillColor = "255 255 255";
   border = true;
   borderThickness = 1;
   borderColor = "0 0 0";
   category = "Core";
};

$ConsoleDefaultFillColor = "0 0 0 175";

if( !isObject( ConsoleScrollProfile ) )
new GuiControlProfile( ConsoleScrollProfile : GuiScrollProfile )
{
	opaque = true;
	fillColor = $ConsoleDefaultFillColor;
	border = 1;
	//borderThickness = 0;
	borderColor = "0 0 0";
   category = "Core";
};

if( !isObject( ConsoleTextEditProfile ) )
new GuiControlProfile( ConsoleTextEditProfile : GuiTextEditProfile )
{
   fillColor = "242 241 240 255";
   fillColorHL = "255 255 255";   
   category = "Core";
};

//-----------------------------------------------------------------------------
// Center and bottom print
//-----------------------------------------------------------------------------

if( !isObject( CenterPrintProfile ) )
new GuiControlProfile ( CenterPrintProfile : GuiDefaultProfile )
{
   opaque = false;
   fillColor = "128 128 128";
   fontColor = "0 255 0";
   border = true;
   borderColor = "0 255 0";
   category = "Core";
};

if( !isObject( CenterPrintTextProfile ) )
new GuiControlProfile ( CenterPrintTextProfile : GuiDefaultProfile )
{
   opaque = false;
   fontType = "Arial";
   fontSize = 12;
   fontColor = "0 255 0";
   category = "Core";
};

// ----------------------------------------------------------------------------
// Radio button control
// ----------------------------------------------------------------------------

if( !isObject( GuiRadioProfile ) )
new GuiControlProfile( GuiRadioProfile : GuiDefaultProfile )
{
   fontSize = 14;
   fillColor = "232 232 232";
   fontColor = "20 20 20";
   fontColorHL = "80 80 80";
   fixedExtent = true;
   bitmap = "./images/radioButton";
   hasBitmapArray = true;
   category = "Core";
};

//-----------------------------------------------------------------------------
// Chat Hud profiles


singleton GuiControlProfile (ChatHudEditProfile)
{
   opaque = false;
   fillColor = "255 255 255";
   fillColorHL = "128 128 128";
   border = false;
   borderThickness = 0;
   borderColor = "40 231 240";
   fontColor = "40 231 240";
   fontColorHL = "40 231 240";
   fontColorNA = "128 128 128";
   textOffset = "0 2";
   autoSizeWidth = false;
   autoSizeHeight = true;
   tab = true;
   canKeyFocus = true;
};

singleton GuiControlProfile (ChatHudTextProfile)
{
   opaque = false;
   fillColor = "255 255 255";
   fillColorHL = "128 128 128";
   border = false;
   borderThickness = 0;
   borderColor = "40 231 240";
   fontColor = "40 231 240";
   fontColorHL = "40 231 240";
   fontColorNA = "128 128 128";
   textOffset = "0 0";
   autoSizeWidth = true;
   autoSizeHeight = true;
   tab = true;
   canKeyFocus = true;
};

singleton GuiControlProfile ("ChatHudMessageProfile")
{
   fontType = "Arial";
   fontSize = 16;
   fontColor = "44 172 181";      // default color (death msgs, scoring, inventory)
   fontColors[1] = "4 235 105";   // client join/drop, tournament mode
   fontColors[2] = "219 200 128"; // gameplay, admin/voting, pack/deployable
   fontColors[3] = "77 253 95";   // team chat, spam protection message, client tasks
   fontColors[4] = "40 231 240";  // global chat
   fontColors[5] = "200 200 50 200";  // used in single player game
   // WARNING! Colors 6-9 are reserved for name coloring
   autoSizeWidth = true;
   autoSizeHeight = true;
};

singleton GuiControlProfile ("ChatHudScrollProfile")
{
   opaque = false;
   borderThickness = 0;
   borderColor = "0 255 0";
   bitmap = "core/art/gui/images/scrollBar";
   hasBitmapArray = true;
};


//-----------------------------------------------------------------------------
// Core Hud profiles

singleton GuiControlProfile ("HudScrollProfile")
{
   opaque = false;
   border = true;
   borderColor = "0 255 0";
   bitmap = "core/art/gui/images/scrollBar";
   hasBitmapArray = true;
};

singleton GuiControlProfile ("HudTextProfile")
{
   opaque = false;
   fillColor = "128 128 128";
   fontColor = "0 255 0";
   border = true;
   borderColor = "0 255 0";
};

singleton GuiControlProfile ("ChatHudBorderProfile")
{
   bitmap = "core/art/gui/images/chatHudBorderArray";
   hasBitmapArray = true;
   opaque = false;
};


//-----------------------------------------------------------------------------
// Center and bottom print

singleton GuiControlProfile ("CenterPrintProfile")
{
   opaque = false;
   fillColor = "128 128 128";
   fontColor = "0 255 0";
   border = true;
   borderColor = "0 255 0";
};

singleton GuiControlProfile ("CenterPrintTextProfile")
{
   opaque = false;
   fontType = "Arial";
   fontSize = 12;
   fontColor = "0 255 0";
};

// -----------------------------------------------------------------------------
// HUD text
// -----------------------------------------------------------------------------

singleton GuiControlProfile (HudTextNormalProfile)
{
   opaque = false;
   fontType = "Arial";
   fontSize = 14;
   fontColor = "255 255 255";
};

singleton GuiControlProfile (HudTextItalicProfile : HudTextNormalProfile)
{
   fontType = "ArialItalic";
};

singleton GuiControlProfile (HudTextBoldProfile : HudTextNormalProfile)
{
   fontType = "ArialBold";
};

// -----------------------------------------------------------------------------
// Numerical health text
// -----------------------------------------------------------------------------

singleton GuiControlProfile (NumericHealthProfile)
{
   opaque = true;
   justify = "center";
   fontType = "ArialBold";
   fontSize = 32;
   fontColor = "255 255 255";
};