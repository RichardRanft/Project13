$Sidebars::ButtonStyleSquare = 0;
$Sidebars::ButtonStyleRectangle = 1;
$Sidebars::buttonExtent = 64;
$Sidebars::buttonExtent.x = 64;
$Sidebars::buttonExtent.y = 64;
$Sidebars::buttonSpacing = 4;

/// <summary>
/// This gets the defined button extent
/// </summary>
/// <return>Returns the defined button extent ("64 64")</return>
function Sidebar::getButtonExtent(%this)
{
    if(%this.buttonStyle = $Sidebars::ButtonStyleSquare)
        return $Sidebars::buttonExtent;

    return $Sidebars::buttonExtent.x SPC $Sidebars::buttonExtent.y;
}

/// <summary>
/// Pushes the rollout to the top of the GUI.
/// </summary>
function Sidebar::selectWindow(%this)
{
    %this.getParent().pushToBack(%this);
}

/// <summary>
/// This gets the defined button width
/// </summary>
/// <return>Returns the defined button width ("64")</return>
function Sidebar::getButtonWidth(%this)
{
    if(%this.buttonStyle = $Sidebars::ButtonStyleSquare)
        return $Sidebars::buttonExtent;

    return $Sidebars::buttonExtent.x;
}

/// <summary>
/// This gets the defined button height
/// </summary>
/// <return>Returns the defined button height ("64")</return>
function Sidebar::getButtonHeight(%this)
{
    if(%this.buttonStyle = $Sidebars::ButtonStyleSquare)
        return $Sidebars::buttonExtent;

    return $Sidebars::buttonExtent.y;
}

function Sidebar::clear(%this)
{
    for (%i = 0; %i < %this.rows; %i++)
    {
        for (%j = 0; %j < %this.cols; %j++)
        {
            %this.buttons[%i,%j] = "";
        }
    }
}

function Sidebar::addButton(%this, %text, %function, %params)
{
    for (%i = 0; %i < %this.rows; %i++)
    {
        for (%j = 0; %j < %this.cols; %j++)
        {
            if(!isObject(%this.buttons[%i,%j]))
            {
                if(%function !$= "")
                {
                    %paramCount = getFieldCount(%params);
                    %paramList = "";
                    for (%k = 0; %k < %paramCount; %k++)
                    {
                        if(%k == 0)
                            %paramList = getField(%params, %k);
                        else
                            %paramList = %paramList @ ", " @ getField(%params, %k);
                    }
                    %this.buttons[%i,%j] = new GuiButtonCtrl()
                    {
                        canSave = "0";
                        profile = "GuiButtonProfile";
                        class = "SidebarButton";
                        text = %text;
                        command = %function@"("@%paramList@");";
                    };
                }
                else
                %this.buttons[%i,%j] = new GuiButtonCtrl()
                {
                    canSave = "0";
                    profile = "GuiButtonProfile";
                    class = "SidebarButton";
                    text = %text;
                };
                %this.btnContainer.addGuiControl(%this.buttons[%i,%j]);
                %pos = %this.spacing + (%j * %this.spacing) + (%j * %this.getButtonWidth()) SPC %this.spacing + (%i * %this.spacing) + (%i * %this.getButtonHeight());
                %this.buttons[%i,%j].extent = %this.getButtonExtent();
                %this.buttons[%i,%j].position = %pos;
                %this.numButtons++;
                return;
            }
        }
    }
}

function Sidebar::calcButtonGrid(%this)
{
    %width = getWord(%this.extent, 0);
    %height = getWord(%this.extent, 1);
    %this.rows = mFloor(%height / (%this.getButtonHeight() + $Sidebars::buttonSpacing));
    %this.cols = mFloor(%width / (%this.getButtonWidth() + $Sidebars::buttonSpacing));
    %this.spacing = $Sidebars::buttonSpacing;
    %this.maxBtns = %this.rows * %this.cols;
    %this.createControlContainer();
    echo(" -- " @ %this.getName() @ ".rows = " @ %this.rows);
    echo(" -- " @ %this.getName() @ ".cols = " @ %this.cols);
}

/// <summary>
/// Internal
/// Creates a GuiControl to contain the buttons - will be just large enough to 
/// hold the contained controls.  This will be used to simplify handling setting
/// alignment options.
/// </summary>
function Sidebar::createControlContainer(%this)
{
    %width = %this.spacing + (%this.cols * (%this.getButtonWidth() + $Sidebars::buttonSpacing));
    %height = %this.spacing + (%this.rows * (%this.getButtonHeight() + $Sidebars::buttonSpacing));
    %extent = %width SPC %height;
    %this.btnContainer = new GuiControl()
    {
        class = "SidebarBtnContainer";
        profile = "GuiTextEditProfile";
        extent = %extent;
        position = "0 0";
        canSave = "0";
    };
    %this.contentPane.addGuiControl(%this.btnContainer);
}

/// <summary>
/// Internal
/// This sets the position of the button container control within the sidebar.
/// </summary>
/// <param name="horizAlign">left, right or center</param>
/// <param name="vertAlign">top, bottom or center</param>
function Sidebar::setContentAlignment(%this, %horizAlign, %vertAlign)
{
    %currentX = getWord(%this.btnContainer.position, 0);
    %currentY = getWord(%this.btnContainer.position, 1);

    %paneWidth = getWord(%this.extent, 0);
    %paneHeight = getWord(%this.extent, 1);

    %width = getWord(%this.btnContainer.extent, 0);
    %height = getWord(%this.btnContainer.extent, 1);
    %newX = %currentX;
    %newY = %currentY;
    switch$(%horizAlign)
    {
        case "left":
            %newX = 0;

        case "right":
            %newX = %paneWidth - %width;

        case "center":
            %newX = (%paneWidth / 2) - (%width / 2);
    }
    switch$(%vertAlign)
    {
        case "top":
            %newY = 0;

        case "bottom":
            %newY = %paneHeight - %height;

        case "center":
            %newY = (%paneHeight / 2) - (%height / 2);
    }
    %this.btnContainer.position = %newX SPC %newY;
}

function SidebarButton::onClick(%this)
{
    echo(" -- SidebarButton::onClick - " @ %this.text);
}