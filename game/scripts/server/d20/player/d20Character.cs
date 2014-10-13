//-----------------------------------------------------------------------------
// Project13
// 3 Jan 2014
// d20Character script
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
//create Derivative Material of Open Game Content. (h) "You" or "Your" means the licensee in terms of this agreement.

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

echo(" -- d20/d20Characer.cs");

function testCharSave()
{
    d20Character::save("./test.cs", d20Character::generate(false));
}

// utility funcitons

/// <summary>
/// Loads a GUI for generating a d20 Modern Character.
/// </summary>
/// <param name="launchGUI">If true, launch character creation GUI.</param>
/// <return>Returns a ScriptObject that carries the character data.</return>
function d20Character::generate(%launchGUI)
{
    %character = new ScriptObject()
    {
        class="d20CharacterData";
    };
    // display character generation GUI
    if( %launchGUI == true )
    {
        // launch character generation GUI
    }
    else
    {
        d20Character::generateAttributes(%character);
        d20Character::selectBaseClass(%character);
        d20Character::getDerivedAttributes(%character);
    }
    return %character;
}

/// <summary>
/// Generates attributes randomly for a character using 3d6.
/// </summary>
/// <param name="character">Character data object.</param>
function d20Character::generateAttributes(%character)
{
    // generate attributes using traditional 3d6 method
    %character.Attribute[$Stat::Strength] = d20System::rollDice(3, d6);
    %character.Attribute[$Stat::Dexterity] = d20System::rollDice(3, d6);
    %character.Attribute[$Stat::Constitution] = d20System::rollDice(3, d6);
    %character.Attribute[$Stat::Intelligence] = d20System::rollDice(3, d6);
    %character.Attribute[$Stat::Wisdom] = d20System::rollDice(3, d6);
    %character.Attribute[$Stat::Charisma] = d20System::rollDice(3, d6);
}

/// <summary>
/// Generates attributes randomly for a character using 4d6, 
/// drop lowest die.
/// </summary>
/// <param name="character">Character data object.</param>
function d20Character::generate4d6Attributes(%character)
{
    // generate attributes using 4d6 drop lowest method
    %character.Attribute[$Stat::Strength] = d20System::gen4d6Stat();
    %character.Attribute[$Stat::Dexterity] = d20System::gen4d6Stat();
    %character.Attribute[$Stat::Constitution] = d20System::gen4d6Stat();
    %character.Attribute[$Stat::Intelligence] = d20System::gen4d6Stat();
    %character.Attribute[$Stat::Wisdom] = d20System::gen4d6Stat();
    %character.Attribute[$Stat::Charisma] = d20System::gen4d6Stat();
}

/// <summary>
/// Sets attributes to 10.
/// </summary>
/// <param name="character">Character data object.</param>
function d20Character::clearPointBuy(%character)
{
    // reset all attributes to 10.
    %character.Attribute[$Stat::Strength] = 10;
    %character.Attribute[$Stat::Dexterity] = 10;
    %character.Attribute[$Stat::Constitution] = 10;
    %character.Attribute[$Stat::Intelligence] = 10;
    %character.Attribute[$Stat::Wisdom] = 10;
    %character.Attribute[$Stat::Charisma] = 10;
}

/// <summary>
/// Selects a base class for a character based on highest attribute.
/// </summary>
/// <param name="file">Name of the character data file to load.</param>
/// <return>Returns a ScriptObject that carries the character data.</return>
function d20Character::selectBaseClass(%character)
{
    %character.numClasses += 1;
    %primaryAttribute = d20Character::getHighestAttribute(%character);
    switch(%primaryAttribute)
    {
        case $Stat::Strength :
            %character.ClassLevel[%character.numClasses] = 1;
            %character.CharClass[%character.numClasses] = $Class[$Stat::Strength].getName();

        case $Stat::Dexterity :
            %character.ClassLevel[%character.numClasses] = 1;
            %character.CharClass[%character.numClasses] = $Class[$Stat::Dexterity].getName();

        case $Stat::Constitution :
            %character.ClassLevel[%character.numClasses] = 1;
            %character.CharClass[%character.numClasses] = $Class[$Stat::Constitution].getName();

        case $Stat::Intelligence :
            %character.ClassLevel[%character.numClasses] = 1;
            %character.CharClass[%character.numClasses] = $Class[$Stat::Intelligence].getName();

        case $Stat::Wisdom :
            %character.ClassLevel[%character.numClasses] = 1;
            %character.CharClass[%character.numClasses] = $Class[$Stat::Wisdom].getName();

        case $Stat::Charisma :
            %character.ClassLevel[%character.numClasses] = 1;
            %character.CharClass[%character.numClasses] = $Class[$Stat::Charisma].getName();
    }
}

/// <summary>
/// Finds the highest attribute and returns the global attribute index:
/// $Stat::Strength = 0;
/// $Stat::Dexterity = 1;
/// $Stat::Constitution = 2;
/// $Stat::Intelligence = 3;
/// $Stat::Wisdom = 4;
/// $Stat::Charisma = 5;
/// </summary>
/// <param name="character">Character data object.</param>
/// <return>Highest attribute index.</return>
function d20Character::getHighestAttribute(%character)
{
    %index = 0;
    %highest = %character.Attribute[%index];
    for( %i = 0; %i < 6; %i++ )
    {
        if( %character.Attribute[%i] >= %highest )
        {
            %index = %i;
            %highest = %character.Attribute[%i];
        }
    }
    return %index;
}

/// <summary>
/// Calculate derived attributes:
/// </summary>
/// <param name="character">Character data object.</param>
function d20Character::getDerivedAttributes(%character, %level)
{
    if( %level $= "")
    {
        // Because this is used in the generation of new random characters we are making
        // the assumption that there is only one class level.
        %character.Level = 1;
        %character.HitDie[1] = %character.CharClass[1].HitDie;
        %character.CharClassName[1] = %character.CharClass[1].ClassName;
        %character.ClassLevel[1] = 1;
        %character.ActionPoints = %character.CharClass[1].ActionPoints;
        %character.ActionPointMod = %character.CharClass[1].ActionPointMod;
        %character.SkillPoints = %character.CharClass[1].SkillPoints;
        %character.ClassFeats[1] = %character.CharClass[1].ClassFeats;
        %character.ClassSkills[1] = %character.CharClass[1].ClassSkills;
        %character.BAB = %character.CharClass[1].ClassData[1].BAB;
        %character.FortSave = %character.CharClass[1].ClassData[1].FortSave + d20System::getStatMod(%character.Attribute[$Stat::Constitution]);
        %character.RefSave = %character.CharClass[1].ClassData[1].RefSave + d20System::getStatMod(%character.Attribute[$Stat::Dexterity]);
        %character.WillSave = %character.CharClass[1].ClassData[1].WillSave + d20System::getStatMod(%character.Attribute[$Stat::Wisdom]);
        %character.DefenseBonus = %character.CharClass[1].ClassData[1].DefenseBonus;
        %character.RepBonus = %character.CharClass[1].ClassData[1].RepBonus;
        %character.HitPoints[1] = d20System::rollDice(1, %character.HitDie[1]);
        %character.MaxHealth = %character.HitPoints[1] + d20System::getStatMod(%character.Attribute[$Stat::Constitution]);
    }
    else
    {
        %character.Level = %level;
        for( %i = 1; %i <= %level; %i++ )
        {
            // Walk all levels and add it all up
            // Need better data schema .... (2 Jul 2014)
            %classLevel = %character.ClassLevel[%i].Level;
            if( %classLevel $= "" )
                %classLevel = %i;
            %character.HitDie[%i] = %character.CharClass[%i].HitDie;
            %character.CharClassName[%i] = %character.CharClass[%i].ClassName;
            %character.ActionPoints += %character.CharClass[%i].ActionPoints;
            %character.ActionPointMod += %character.CharClass[%i].ActionPointMod;
            %character.SkillPoints += %character.CharClass[%i].SkillPoints;
            %character.ClassFeats[%i] = %character.CharClass[%i].ClassFeats;
            %character.ClassSkills[%i] = %character.CharClass[%i].ClassSkills;
            %character.FortSave += %character.CharClass[%i].ClassData[%classLevel].FortSave;
            %character.RefSave += %character.CharClass[%i].ClassData[%classLevel].RefSave;
            %character.WillSave += %character.CharClass[%i].ClassData[%classLevel].WillSave;  
            %character.DefenseBonus += %character.CharClass[%i].ClassData[%classLevel].DefenseBonus;
            %character.RepBonus += %character.CharClass[%i].ClassData[%classLevel].RepBonus;
            %character.HitPoints[%i] = d20System::rollDice(1, %character.HitDie[1]);
            %character.MaxHealth += %character.HitPoints[%i] + d20System::getStatMod(%character.Attribute[$Stat::Constitution]);
        }

        // this won't do - have to calculate based on all class BAB numbers
        %character.BAB = %character.calculateBAB();

        %character.FortSave += d20System::getStatMod(%character.Attribute[$Stat::Constitution]);
        %character.RefSave += d20System::getStatMod(%character.Attribute[$Stat::Dexterity]);
        %character.WillSave += d20System::getStatMod(%character.Attribute[$Stat::Wisdom]);
    }
}

/// <summary>
/// Calculates current BAB based on all character levels
/// </summary>
function d20Character::calculateBAB(%this)
{
    // iterate through levels and get each BAB
    %classData = %this.getClassLevelData();
    %classCount = getFieldCount(%classData);
    if( %classCount != %this.numClasses )
    {
        error(" --- Error: d20Character::calculateBAB() - class data does not match numClasses");
    }
    %BAB = "";
    for( %i = 0; %i < %classCount; %i++ )
    {
        %field = getField(%classData, %i);
        %className = getWord(%field, 0);
        %classLevel = getWord(%field, 1);
        if( %BAB $= "" )
            %BAB = %className.ClassData[%classLevel].BAB;
        else
            %BAB = %BAB TAB %className.ClassData[%classLevel].BAB;
    }
    %this.BAB = d20System::addBAB(%BAB);
}

/// <summary>
/// Gets all classes and each class' level from the character
/// </summary>
/// <return>A string composed of tab-delimited <classname>SPC<classlevel> pairs.</return>
function d20Character::getClassLevelData(%this)
{
    %classList = "";
    %classLevel = "";
    %classData = "";
    for( %i = 1; %i <= %this.Level; %i++ )
    {
        %found = false;
        %class = "";
        %currentClass = %this.CharClassName[%i];
        %classCount = getWordCount(%classList);
        for( %j = 0; %j < %classCount; %j++ )
        {
            %class = getWord(%classList, %j);
            if( %class !$= "" || %class !$= %currentClass )
            {
                continue;
            }
            else
                %found = true;
        }
        if( !%found )
        {
            if( %classCount == 0 )
            {
                %classList = %this.CharClassName[%i];
                %index = d20System::getWordIndex(%classList, %this.CharClassName[%i]);
                if( %index >= 0 )
                    %classLevel[%index] = %this.ClassLevel[%i];
            }
            else
            {
                %classList = %classList SPC %this.CharClassName[%i];
                %index = d20System::getWordIndex(%classList, %this.CharClassName[%i]);
                if( %index >= 0 )
                    %classLevel[%index] = %this.ClassLevel[%i];
            }
        }
    }
    for( %i = 0; %i < %classCount; %i++ )
    {
        if( %i == 0 )
            %classData = getWord(%classList, %i) SPC %classLevel[%i];
        else
            %classData = %classData TAB getWord(%classList, %i) SPC %classLevel[%i]; 
    }
    return %classData;
}



/// <summary>
/// Loads a character from file
/// </summary>
/// <param name="file">Name of the character data file to load.</param>
/// <return>Returns a ScriptObject that carries the character data.</return>
function d20Character::load(%file)
{
    // read character file
    %character = exec(%file);
    
    // return character
    return %character;
}

/// <summary>
/// Saves character data to file.
/// </summary>
/// <param name="filename">Name of the character data file to save to.</param>
/// <param name="character">Script object containing character data.</param>
/// <return>Returns boolean to indicate success/failure.</return>
function d20Character::save(%filename, %character)
{
    %character.save(%filename);
    return true;
}

/// <summary>
/// Gets massive damage effect when a character equipped with cybernetics
/// takes massive damage
/// </summary>
/// <return>Returns a ScriptObject that carries the effect data.</return>
function d20CharacterData::getInventory(%this)
{
    return %this.inventory;
}

/// <summary>
/// Gets massive damage effect when a character equipped with cybernetics
/// takes massive damage
/// </summary>
/// <return>Returns a ScriptObject that carries the effect data.</return>
function d20CharacterData::getEffectState(%this)
{
    return %effect;
}
