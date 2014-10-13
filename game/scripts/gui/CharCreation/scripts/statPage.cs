//-----------------------------------------------------------------------------
// Project13
// 3 Jan 2014
// d20 character creation stat page scripts
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

function CCStatsPage::onWake(%this)
{
    echo(" --- CCStatsPage::onWake()");
    if( !isObject(%character) )
    {
        CharacterCreator.newCharacter();
    }
    %method = "";
    %found = false;
    %count = CCMPanel.getCount();
    for( %i = 0; %i < %count; %i++ )
    {
        %method = CCMPanel.getObject(%i);
        if( %method.getClassName() $= "GuiRadioCtrl" )
        {
            if( %method.getValue() == true )
                %found = true;
        }
    }
    if( !%found )
    {
        rcbPB25.setStateOn(true);
        rcbPB25.onClick();
    }
}

function CCCharName::validate(%this)
{
    %name = %this.getText();
    // remove whitespaces at beginning and end
    %name = ltrim(%name);

    // remove any other invalid characters
    %name = stripChars(%name, "-+*/%$&§=()[].?\"'`#,;!~<>|°^{}");

    if (%name $= "")
        %name = "Unnamed";
        
    CharacterCreator.currentChar.CharacterName = %name;
    
    return %name;
}

function rbcPB3d6::onClick(%this)
{
    CharacterCreator.createMethod = "PB3d6";
    btnRollAttributes.setVisible(true);
    CCPointDisplay.text = "0";
    CCPointDisplay.visible = false;
    lblPointsRemain.visible = false;
    CharacterCreator.setSpinnerVisible(false);
    %character = CharacterCreator.currentChar;
    d20Character::clearPointBuy(%character);
    CharacterCreator.resetPointDisplays();
    CharacterCreator.refreshAttributeDisplay();
}

function rcbPB4d6::onClick(%this)
{
    CharacterCreator.createMethod = "PB4d6";
    btnRollAttributes.setVisible(true);
    CCPointDisplay.text = "0";
    CCPointDisplay.visible = false;
    lblPointsRemain.visible = false;
    CharacterCreator.setSpinnerVisible(false);
    %character = CharacterCreator.currentChar;
    d20Character::clearPointBuy(%character);
    CharacterCreator.resetPointDisplays();
    CharacterCreator.refreshAttributeDisplay();
}

function rcbPB25::onClick(%this)
{
    CharacterCreator.createMethod = "PB25";
    btnRollAttributes.setVisible(false);
    CCPointDisplay.text = "25";
    CCPointDisplay.visible = true;
    lblPointsRemain.visible = true;
    CharacterCreator.setSpinnerVisible(true);
    %character = CharacterCreator.currentChar;
    d20Character::clearPointBuy(%character);
    CharacterCreator.resetPointDisplays();
    CharacterCreator.refreshAttributeDisplay();
}

function rcbPB28::onClick(%this)
{
    CharacterCreator.createMethod = "PB28";
    btnRollAttributes.setVisible(false);
    CCPointDisplay.text = "28";
    CCPointDisplay.visible = true;
    lblPointsRemain.visible = true;
    CharacterCreator.setSpinnerVisible(true);
    %character = CharacterCreator.currentChar;
    d20Character::clearPointBuy(%character);
    CharacterCreator.resetPointDisplays();
    CharacterCreator.refreshAttributeDisplay();
}

function rcbPB32::onClick(%this)
{
    CharacterCreator.createMethod = "PB32";
    btnRollAttributes.setVisible(false);
    CCPointDisplay.text = "32";
    CCPointDisplay.visible = true;
    lblPointsRemain.visible = true;
    CharacterCreator.setSpinnerVisible(true);
    %character = CharacterCreator.currentChar;
    d20Character::clearPointBuy(%character);
    CharacterCreator.resetPointDisplays();
    CharacterCreator.refreshAttributeDisplay();
}

function rcbPB36::onClick(%this)
{
    CharacterCreator.createMethod = "PB36";
    btnRollAttributes.setVisible(false);
    CCPointDisplay.text = "36";
    CCPointDisplay.visible = true;
    lblPointsRemain.visible = true;
    CharacterCreator.setSpinnerVisible(true);
    %character = CharacterCreator.currentChar;
    d20Character::clearPointBuy(%character);
    CharacterCreator.resetPointDisplays();
    CharacterCreator.refreshAttributeDisplay();
}

function btnRollAttributes::onClick(%this)
{
    %character = CharacterCreator.currentChar;
    if( !isObject(%character) )
    {
        CharacterCreator.newCharacter();
    }
    if( CharacterCreator.createMethod $= "PB3d6" )
        d20Character::generateAttributes(%character);
    if( CharacterCreator.createMethod $= "PB4d6" )
        d20Character::generate4d6Attributes(%character);
    CharacterCreator.resetPointDisplays();
    CharacterCreator.refreshAttributeDisplay();
}

function btnStrUp::onClick(%this)
{
    if( CCStrAttribute.text == 18 )
        return;
    if( CCStrAttribute.text >= 10 )
        %cost = d20System::getAbilityScoreCost(CCStrAttribute.text + 1);
    else
        %cost = d20System::getAbilityScoreCost(CCStrAttribute.text);
    if( %cost > CCPointDisplay.text )
        return;
    else
    {
        if( %cost < 0 )
            CCPointDisplay.text = CCPointDisplay.text - mAbs(%cost);
        else
            CCPointDisplay.text = CCPointDisplay.text - %cost;
        CCStrPoints.text = CCStrPoints.text + %cost;
    }
    CharacterCreator.currentChar.Attribute[$Stat::Strength]++;
    CCStrAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Strength];
    CCStrModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Strength]), 0);
}

function btnStrDown::onClick(%this)
{
    if( CCStrAttribute.text == 7 )
        return;
    if( CCStrAttribute.text <= 10 )
        %cost = d20System::getAbilityScoreCost(CCStrAttribute.text - 1);
    else
        %cost = d20System::getAbilityScoreCost(CCStrAttribute.text);
    if( %cost < 0 )
        CCPointDisplay.text = CCPointDisplay.text + mAbs(%cost);
    else
        CCPointDisplay.text = CCPointDisplay.text + %cost;
    CCStrPoints.text = CCStrPoints.text - %cost;
    CharacterCreator.currentChar.Attribute[$Stat::Strength]--;
    CCStrAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Strength];
    CCStrModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Strength]), 0);
}

function btnDexUp::onClick(%this)
{
    if( CCDexAttribute.text == 18 )
        return;
    if( CCDexAttribute.text >= 10 )
        %cost = d20System::getAbilityScoreCost(CCDexAttribute.text + 1);
    else
        %cost = d20System::getAbilityScoreCost(CCDexAttribute.text);
    if( %cost > CCPointDisplay.text )
        return;
    else
    {
        if( %cost < 0 )
            CCPointDisplay.text = CCPointDisplay.text - mAbs(%cost);
        else
            CCPointDisplay.text = CCPointDisplay.text - %cost;
        CCDexPoints.text = CCDexPoints.text + %cost;
    }
    CharacterCreator.currentChar.Attribute[$Stat::Dexterity]++;
    CCDexAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Dexterity];
    CCDexModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Dexterity]), 0);
}

function btnDexDown::onClick(%this)
{
    if( CCDexAttribute.text == 7 )
        return;
    if( CCDexAttribute.text <= 10 )
        %cost = d20System::getAbilityScoreCost(CCDexAttribute.text - 1);
    else
        %cost = d20System::getAbilityScoreCost(CCDexAttribute.text);
    if( %cost < 0 )
        CCPointDisplay.text = CCPointDisplay.text + mAbs(%cost);
    else
        CCPointDisplay.text = CCPointDisplay.text + %cost;
    CCDexPoints.text = CCDexPoints.text - %cost;
    CharacterCreator.currentChar.Attribute[$Stat::Dexterity]--;
    CCDexAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Dexterity];
    CCDexModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Dexterity]), 0);
}

function btnConUp::onClick(%this)
{
    if( CCConAttribute.text == 18 )
        return;
    if( CCConAttribute.text >= 10 )
        %cost = d20System::getAbilityScoreCost(CCConAttribute.text + 1);
    else
        %cost = d20System::getAbilityScoreCost(CCConAttribute.text);
    if( %cost > CCPointDisplay.text )
        return;
    else
    {
        if( %cost < 0 )
            CCPointDisplay.text = CCPointDisplay.text - mAbs(%cost);
        else
            CCPointDisplay.text = CCPointDisplay.text - %cost;
        CCConPoints.text = CCConPoints.text + %cost;
    }
    CharacterCreator.currentChar.Attribute[$Stat::Constitution]++;
    CCConAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Constitution];
    CCConModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Constitution]), 0);
}

function btnConDown::onClick(%this)
{
    if( CCConAttribute.text == 7 )
        return;
    if( CCConAttribute.text <= 10 )
        %cost = d20System::getAbilityScoreCost(CCConAttribute.text - 1);
    else
        %cost = d20System::getAbilityScoreCost(CCConAttribute.text);
    if( %cost < 0 )
        CCPointDisplay.text = CCPointDisplay.text + mAbs(%cost);
    else
        CCPointDisplay.text = CCPointDisplay.text + %cost;
    CCConPoints.text = CCConPoints.text - %cost;
    CharacterCreator.currentChar.Attribute[$Stat::Constitution]--;
    CCConAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Constitution];
    CCConModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Constitution]), 0);
}

function btnIntUp::onClick(%this)
{
    if( CCIntAttribute.text == 18 )
        return;
    if( CCIntAttribute.text >= 10 )
        %cost = d20System::getAbilityScoreCost(CCIntAttribute.text + 1);
    else
        %cost = d20System::getAbilityScoreCost(CCIntAttribute.text);
    if( %cost > CCPointDisplay.text )
        return;
    else
    {
        if( %cost < 0 )
            CCPointDisplay.text = CCPointDisplay.text - mAbs(%cost);
        else
            CCPointDisplay.text = CCPointDisplay.text - %cost;
        CCIntPoints.text = CCIntPoints.text + %cost;
    }
    CharacterCreator.currentChar.Attribute[$Stat::Intelligence]++;
    CCIntAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Intelligence];
    CCIntModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Intelligence]), 0);
}

function btnIntDown::onClick(%this)
{
    if( CCIntAttribute.text == 7 )
        return;
    if( CCIntAttribute.text <= 10 )
        %cost = d20System::getAbilityScoreCost(CCIntAttribute.text - 1);
    else
        %cost = d20System::getAbilityScoreCost(CCIntAttribute.text);
    if( %cost < 0 )
        CCPointDisplay.text = CCPointDisplay.text + mAbs(%cost);
    else
        CCPointDisplay.text = CCPointDisplay.text + %cost;
    CCIntPoints.text = CCIntPoints.text - %cost;
    CharacterCreator.currentChar.Attribute[$Stat::Intelligence]--;
    CCIntAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Intelligence];
    CCIntModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Intelligence]), 0);
}

function btnWisUp::onClick(%this)
{
    if( CCWisAttribute.text == 18 )
        return;
    if( CCWisAttribute.text >= 10 )
        %cost = d20System::getAbilityScoreCost(CCWisAttribute.text + 1);
    else
        %cost = d20System::getAbilityScoreCost(CCWisAttribute.text);
    if( %cost > CCPointDisplay.text )
        return;
    else
    {
        if( %cost < 0 )
            CCPointDisplay.text = CCPointDisplay.text - mAbs(%cost);
        else
            CCPointDisplay.text = CCPointDisplay.text - %cost;
        CCWisPoints.text = CCWisPoints.text + %cost;
    }
    CharacterCreator.currentChar.Attribute[$Stat::Wisdom]++;
    CCWisAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Wisdom];
    CCWisModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Wisdom]), 0);
}

function btnWisDown::onClick(%this)
{
    if( CCWisAttribute.text == 7 )
        return;
    if( CCWisAttribute.text <= 10 )
        %cost = d20System::getAbilityScoreCost(CCWisAttribute.text - 1);
    else
        %cost = d20System::getAbilityScoreCost(CCWisAttribute.text);
    if( %cost < 0 )
        CCPointDisplay.text = CCPointDisplay.text + mAbs(%cost);
    else
        CCPointDisplay.text = CCPointDisplay.text - %cost;
    CCWisPoints.text = CCWisPoints.text + %cost;
    CharacterCreator.currentChar.Attribute[$Stat::Wisdom]--;
    CCWisAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Wisdom];
    CCWisModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Wisdom]), 0);
}

function btnChaUp::onClick(%this)
{
    if( CCChaAttribute.text == 18 )
        return;
    if( CCChaAttribute.text >= 10 )
        %cost = d20System::getAbilityScoreCost(CCChaAttribute.text + 1);
    else
        %cost = d20System::getAbilityScoreCost(CCChaAttribute.text);
    if( %cost > CCPointDisplay.text )
        return;
    else
    {
        if( %cost < 0 )
            CCPointDisplay.text = CCPointDisplay.text - mAbs(%cost);
        else
            CCPointDisplay.text = CCPointDisplay.text - %cost;
        CCChaPoints.text = CCChaPoints.text + %cost;
    }
    CharacterCreator.currentChar.Attribute[$Stat::Charisma]++;
    CCChaAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Charisma];
    CCChaModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Charisma]), 0);
}

function btnChaDown::onClick(%this)
{
    if( CCChaAttribute.text == 7 )
        return;
    if( CCChaAttribute.text <= 10 )
        %cost = d20System::getAbilityScoreCost(CCChaAttribute.text - 1);
    else
        %cost = d20System::getAbilityScoreCost(CCChaAttribute.text);
    if( %cost < 0 )
        CCPointDisplay.text = CCPointDisplay.text + mAbs(%cost);
    else
        CCPointDisplay.text = CCPointDisplay.text + %cost;
    CCChaPoints.text = CCChaPoints.text - %cost;
    CharacterCreator.currentChar.Attribute[$Stat::Charisma]--;
    CCChaAttribute.text = CharacterCreator.currentChar.Attribute[$Stat::Charisma];
    CCChaModifier.text = getWord(d20System::getStatMod(CharacterCreator.currentChar.Attribute[$Stat::Charisma]), 0);
}
