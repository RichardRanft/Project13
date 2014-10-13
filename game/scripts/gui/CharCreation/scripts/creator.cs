//-----------------------------------------------------------------------------
// Project13
// 3 Jan 2014
// d20 character creation main script
//-----------------------------------------------------------------------------

// CCPointDisplay   - Text object, buy points remaining
// CCStrAttribute   - Current strength score
// CCStrPoints      - Current strength point cost
// CCStrModifier    - Current strength modifier
// CCDexAttribute   - Current dexterity score
// CCDexPoints      - Current dexterity point cost
// CCDexModifier    - Current dexterity modifier
// CCConAttribute   - Current constitution score
// CCConPoints      - Current constitution point cost
// CCConModifier    - Current constitution modifier
// CCIntAttribute   - Current intelligence score
// CCIntPoints      - Current intelligence point cost
// CCIntModifier    - Current intelligence modifier
// CCWisAttribute   - Current wisdom score
// CCWisPoints      - Current wisdom point cost
// CCWisModifier    - Current wisdom modifier
// CCChaAttribute   - Current charisma score
// CCChaPoints      - Current charisma point cost
// CCChaModifier    - Current charisma modifier

function CharacterCreator::onWake(%this)
{
}

function CharacterCreator::onSleep(%this)
{
}

function CharacterCreator::onDialogPush(%this)
{
}

function CharacterCreator::onDialogPop(%this)
{
    if( %this.cancelClicked )
        %this.currentChar.delete();
    // clear data
}

function CharacterCreator::newCharacter(%this)
{
    // create new blank character data object
    if( !isObject(%this.currentChar) )
    {
        %this.currentChar = new ScriptObject()
        {
            class = "d20CharacterData";
        };
        %this.currentChar.CharacterName = "Milton Waddams";
    }
    %this.cancelClicked = false;
}

/// <summary>
/// Sets the spinner visibility.
/// </summary>
/// <param name="value">True to show spinners, false to hide them.</param>
function CharacterCreator::setSpinnerVisible(%this, %value)
{
    %objCount = CCAttributePanel.getCount();
    for(%i = 0; %i < %objCount; %i++)
    {
        %obj = CCAttributePanel.getObject(%i);
        if(%obj.getClassName() $= "GuiBitmapButtonCtrl")
            %obj.setVisible(%value);
    }
}

/// <summary>
/// Clears all attribute point buy totals to 0.
/// </summary>
function CharacterCreator::resetPointDisplays(%this)
{
    CCStrPoints.text = "0";
    CCDexPoints.text = "0";
    CCConPoints.text = "0";
    CCIntPoints.text = "0";
    CCWisPoints.text = "0";
    CCChaPoints.text = "0";
}

/// <summary>
/// Updates attribute display with current values.
/// </summary>
function CharacterCreator::refreshAttributeDisplay(%this)
{
    CCStrAttribute.text = %this.currentChar.Attribute[$Stat::Strength];
    CCStrModifier.text = getWord(d20System::getStatMod(%this.currentChar.Attribute[$Stat::Strength]), 0);
    CCDexAttribute.text = %this.currentChar.Attribute[$Stat::Dexterity];
    CCDexModifier.text = getWord(d20System::getStatMod(%this.currentChar.Attribute[$Stat::Dexterity]), 0);
    CCConAttribute.text = %this.currentChar.Attribute[$Stat::Constitution];
    CCConModifier.text = getWord(d20System::getStatMod(%this.currentChar.Attribute[$Stat::Constitution]), 0);
    CCIntAttribute.text = %this.currentChar.Attribute[$Stat::Intelligence];
    CCIntModifier.text = getWord(d20System::getStatMod(%this.currentChar.Attribute[$Stat::Intelligence]), 0);
    CCWisAttribute.text = %this.currentChar.Attribute[$Stat::Wisdom];
    CCWisModifier.text = getWord(d20System::getStatMod(%this.currentChar.Attribute[$Stat::Wisdom]), 0);
    CCChaAttribute.text = %this.currentChar.Attribute[$Stat::Charisma];
    CCChaModifier.text = getWord(d20System::getStatMod(%this.currentChar.Attribute[$Stat::Charisma]), 0);
    CCCharName.setText(%this.currentChar.CharacterName);
}

/// <summary>
/// Saves the current character.
/// </summary>
function CharacterCreator::saveCharacter(%this)
{
    echo(" --- CharacterCreator::saveCharacter()");
    %name = trim(%this.currentChar.CharacterName);
    %name = strreplace(%name, " ", "");
    %uuid = generateUUID();
    %path = "saves/"@%uuid@"/"@%name@".cs";
    d20Character::save(%path, %this.currentChar);
    $LocalPlayer = new ScriptObject(){
        class = "d20Player";
    };
    $LocalPlayer.Character = %this.currentChar;
    Canvas.popDialog(%this);
}

/// <summary>
/// Cancels current character.
/// </summary>
function CreateCharCancelBtn::onClick(%this)
{
    CharacterCreator.cancelClicked = true;
    Canvas.popDialog(CharacterCreator);
}

function CCTabBook::onTabSelected(%this, %tabName, %tabIndex)
{
    echo(" --- " @ %tabName @ " : " @ %tabIndex @ " selected....");
}

function CCTextEdit::onKeyPressed(%this)
{
    %this.setText(%this.validate());
}
