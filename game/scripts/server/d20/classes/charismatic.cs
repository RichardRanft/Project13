//-----------------------------------------------------------------------------
// Project13
// 3 Jan 2014
// d20 charismatic class script loader
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

echo(" -- d20/classes/charismatic.cs");

$Class[$Stat::Charisma] = new ScriptObject("Charismatic")
{
    class="d20CharacterClass";
};

$Class[$Stat::Charisma].ClassName = "Charismatic";
$Class[$Stat::Charisma].Ability = "Charisma";
$Class[$Stat::Charisma].HitDie = 6;
$Class[$Stat::Charisma].ActionPoints = 5;
$Class[$Stat::Charisma].ActionPointMod = 0.5;
$Class[$Stat::Charisma].SkillPoints = 7;
$Class[$Stat::Charisma].ClassFeats = "Simple Weapons Proficiency";
// Bluff (Cha), Craft (visual art, writing) (Int), Diplomacy (Cha), Disguise (Cha), Gather Information (Cha), Handle Animal (Cha), Intimidate (Cha), Knowledge (arcane lore, art, behavioral sciences, business, civics, current events, popular culture, streetwise, theology and philosophy) (Int), Perform (act, dance, keyboards, percussion instruments, sing, stand-up, stringed instruments, wind instruments) (Cha), Profession (Wis), Read/Write Language (none), and Speak Language (none).
$Class[$Stat::Charisma].ClassSkills = $Skills::Climb::Name TAB $Skills::Craft::Structural::Name TAB $Skills::HandleAnimal::Name TAB $Skills::Jump::Name TAB $Skills::Knowledge::CurrentEvents::Name TAB $Skills::Knowledge::PopularCulture::Name TAB $Skills::Knowledge::Streetwise::Name TAB $Skills::Knowledge::Tactics::Name TAB $Skills::Profession::Name TAB $Skills::ReadLanguage::Name TAB $Skills::Repair::Name TAB $Skills::SpeakLanguage::Name TAB $Skills::Swim::Name;

$Class[$Stat::Charisma].ClassData[1] = new ScriptObject();
$Class[$Stat::Charisma].ClassData[1].BAB = "1";
$Class[$Stat::Charisma].ClassData[1].FortSave = "1";
$Class[$Stat::Charisma].ClassData[1].RefSave = "0";
$Class[$Stat::Charisma].ClassData[1].WillSave = "0";
$Class[$Stat::Charisma].ClassData[1].Feature = "Talent";
$Class[$Stat::Charisma].ClassData[1].DefenseBonus = "1";
$Class[$Stat::Charisma].ClassData[1].RepBonus = "0";

$Class[$Stat::Charisma].ClassData[2] = new ScriptObject();
$Class[$Stat::Charisma].ClassData[2].BAB = "2";
$Class[$Stat::Charisma].ClassData[2].FortSave = "2";
$Class[$Stat::Charisma].ClassData[2].RefSave = "0";
$Class[$Stat::Charisma].ClassData[2].WillSave = "0";
$Class[$Stat::Charisma].ClassData[2].Feature = "Bonus feat";
$Class[$Stat::Charisma].ClassData[2].DefenseBonus = "2";
$Class[$Stat::Charisma].ClassData[2].RepBonus = "0";

$Class[$Stat::Charisma].ClassData[3] = new ScriptObject();
$Class[$Stat::Charisma].ClassData[3].BAB = "3";
$Class[$Stat::Charisma].ClassData[3].FortSave = "2";
$Class[$Stat::Charisma].ClassData[3].RefSave = "1";
$Class[$Stat::Charisma].ClassData[3].WillSave = "1";
$Class[$Stat::Charisma].ClassData[3].Feature = "Talent";
$Class[$Stat::Charisma].ClassData[3].DefenseBonus = "2";
$Class[$Stat::Charisma].ClassData[3].RepBonus = "0";

$Class[$Stat::Charisma].ClassData[4] = new ScriptObject();
$Class[$Stat::Charisma].ClassData[4].BAB = "4";
$Class[$Stat::Charisma].ClassData[4].FortSave = "2";
$Class[$Stat::Charisma].ClassData[4].RefSave = "1";
$Class[$Stat::Charisma].ClassData[4].WillSave = "1";
$Class[$Stat::Charisma].ClassData[4].Feature = "Bonus feat";
$Class[$Stat::Charisma].ClassData[4].DefenseBonus = "3";
$Class[$Stat::Charisma].ClassData[4].RepBonus = "0";

$Class[$Stat::Charisma].ClassData[5] = new ScriptObject();
$Class[$Stat::Charisma].ClassData[5].BAB = "5";
$Class[$Stat::Charisma].ClassData[5].FortSave = "3";
$Class[$Stat::Charisma].ClassData[5].RefSave = "1";
$Class[$Stat::Charisma].ClassData[5].WillSave = "1";
$Class[$Stat::Charisma].ClassData[5].Feature = "Talent";
$Class[$Stat::Charisma].ClassData[5].DefenseBonus = "3";
$Class[$Stat::Charisma].ClassData[5].RepBonus = "1";

$Class[$Stat::Charisma].ClassData[6] = new ScriptObject();
$Class[$Stat::Charisma].ClassData[6].BAB = "6 1";
$Class[$Stat::Charisma].ClassData[6].FortSave = "3";
$Class[$Stat::Charisma].ClassData[6].RefSave = "2";
$Class[$Stat::Charisma].ClassData[6].WillSave = "2";
$Class[$Stat::Charisma].ClassData[6].Feature = "Bonus feat";
$Class[$Stat::Charisma].ClassData[6].DefenseBonus = "3";
$Class[$Stat::Charisma].ClassData[6].RepBonus = "1";

$Class[$Stat::Charisma].ClassData[7] = new ScriptObject();
$Class[$Stat::Charisma].ClassData[7].BAB = "7 2";
$Class[$Stat::Charisma].ClassData[7].FortSave = "4";
$Class[$Stat::Charisma].ClassData[7].RefSave = "2";
$Class[$Stat::Charisma].ClassData[7].WillSave = "2";
$Class[$Stat::Charisma].ClassData[7].Feature = "Talent";
$Class[$Stat::Charisma].ClassData[7].DefenseBonus = "4";
$Class[$Stat::Charisma].ClassData[7].RepBonus = "1";

$Class[$Stat::Charisma].ClassData[8] = new ScriptObject();
$Class[$Stat::Charisma].ClassData[8].BAB = "8 3";
$Class[$Stat::Charisma].ClassData[8].FortSave = "4";
$Class[$Stat::Charisma].ClassData[8].RefSave = "2";
$Class[$Stat::Charisma].ClassData[8].WillSave = "2";
$Class[$Stat::Charisma].ClassData[8].Feature = "Bonus feat";
$Class[$Stat::Charisma].ClassData[8].DefenseBonus = "4";
$Class[$Stat::Charisma].ClassData[8].RepBonus = "1";

$Class[$Stat::Charisma].ClassData[9] = new ScriptObject();
$Class[$Stat::Charisma].ClassData[9].BAB = "9 4";
$Class[$Stat::Charisma].ClassData[9].FortSave = "4";
$Class[$Stat::Charisma].ClassData[9].RefSave = "3";
$Class[$Stat::Charisma].ClassData[9].WillSave = "3";
$Class[$Stat::Charisma].ClassData[9].Feature = "Talent";
$Class[$Stat::Charisma].ClassData[9].DefenseBonus = "5";
$Class[$Stat::Charisma].ClassData[9].RepBonus = "2";

$Class[$Stat::Charisma].ClassData[10] = new ScriptObject();
$Class[$Stat::Charisma].ClassData[10].BAB = "10 5";
$Class[$Stat::Charisma].ClassData[10].FortSave = "5";
$Class[$Stat::Charisma].ClassData[10].RefSave = "3";
$Class[$Stat::Charisma].ClassData[10].WillSave = "3";
$Class[$Stat::Charisma].ClassData[10].Feature = "Bonus feat";
$Class[$Stat::Charisma].ClassData[10].DefenseBonus = "5";
$Class[$Stat::Charisma].ClassData[10].RepBonus = "2";

// names contain spaces - list is tab-delimited
$Class[$Stat::Charisma].BonusFeats = "Agile Riposte"TAB"Creative"TAB"Deceptive"TAB"Dodge"TAB"Frightful Presence"TAB"Iron Will"TAB"Lightning Reflexes"TAB"Low Profile"TAB"Point Blank Shot"TAB"Renown"TAB"Trustworthy"TAB"Windfall";

// Talents
$Class[$Stat::Charisma].ExtremeEffortTalents[1] = new ScriptObject();
$Class[$Stat::Charisma].ExtremeEffortTalents[1].Name = "Extreme Effort";
$Class[$Stat::Charisma].ExtremeEffortTalents[1].Effect = "2";
$Class[$Stat::Charisma].ExtremeEffortTalents[1].AppliesTo = "StrCheck StrSkill";
$Class[$Stat::Charisma].ExtremeEffortTalents[1].Time = "Swift";
$Class[$Stat::Charisma].ExtremeEffortTalents[1].Prerequisite = "0";

$Class[$Stat::Charisma].ExtremeEffortTalents[2] = new ScriptObject();
$Class[$Stat::Charisma].ExtremeEffortTalents[2].Name = "Improved Extreme Effort";
$Class[$Stat::Charisma].ExtremeEffortTalents[2].Effect = "4";
$Class[$Stat::Charisma].ExtremeEffortTalents[2].AppliesTo = "StrCheck StrSkill";
$Class[$Stat::Charisma].ExtremeEffortTalents[2].Time = "FullRound";
$Class[$Stat::Charisma].ExtremeEffortTalents[2].Prerequisite = "1";

$Class[$Stat::Charisma].ExtremeEffortTalents[3] = new ScriptObject();
$Class[$Stat::Charisma].ExtremeEffortTalents[3].Name = "Advanced Extreme Effort";
$Class[$Stat::Charisma].ExtremeEffortTalents[3].Effect = "6";
$Class[$Stat::Charisma].ExtremeEffortTalents[3].AppliesTo = "StrCheck StrSkill";
$Class[$Stat::Charisma].ExtremeEffortTalents[3].Time = "FullRound";
$Class[$Stat::Charisma].ExtremeEffortTalents[3].Prerequisite = "2";

$Class[$Stat::Charisma].IgnoreHardnessTalents[1] = new ScriptObject();
$Class[$Stat::Charisma].IgnoreHardnessTalents[1].Name = "Ignore Hardness";
$Class[$Stat::Charisma].IgnoreHardnessTalents[1].Effect = "2";
$Class[$Stat::Charisma].IgnoreHardnessTalents[1].AppliesTo = "TargetHardness";
$Class[$Stat::Charisma].IgnoreHardnessTalents[1].Time = "Swift";
$Class[$Stat::Charisma].IgnoreHardnessTalents[1].Prerequisite = "0";

$Class[$Stat::Charisma].IgnoreHardnessTalents[2] = new ScriptObject();
$Class[$Stat::Charisma].IgnoreHardnessTalents[2].Name = "Improved Ignore Hardness";
$Class[$Stat::Charisma].IgnoreHardnessTalents[2].Effect = "4";
$Class[$Stat::Charisma].IgnoreHardnessTalents[2].AppliesTo = "TargetHardness";
$Class[$Stat::Charisma].IgnoreHardnessTalents[2].Time = "Swift";
$Class[$Stat::Charisma].IgnoreHardnessTalents[2].Prerequisite = "1";

$Class[$Stat::Charisma].IgnoreHardnessTalents[3] = new ScriptObject();
$Class[$Stat::Charisma].IgnoreHardnessTalents[3].Name = "Advanced Ignore Hardness";
$Class[$Stat::Charisma].IgnoreHardnessTalents[3].Effect = "6";
$Class[$Stat::Charisma].IgnoreHardnessTalents[3].AppliesTo = "TargetHardness";
$Class[$Stat::Charisma].IgnoreHardnessTalents[3].Time = "Swift";
$Class[$Stat::Charisma].IgnoreHardnessTalents[3].Prerequisite = "2";

$Class[$Stat::Charisma].MeleeSmashTalents[1] = new ScriptObject();
$Class[$Stat::Charisma].MeleeSmashTalents[1].Name = "Melee Smash";
$Class[$Stat::Charisma].MeleeSmashTalents[1].Effect = "1";
$Class[$Stat::Charisma].MeleeSmashTalents[1].AppliesTo = "MeleeDamage";
$Class[$Stat::Charisma].MeleeSmashTalents[1].Time = "Passive";
$Class[$Stat::Charisma].MeleeSmashTalents[1].Prerequisite = "0";

$Class[$Stat::Charisma].MeleeSmashTalents[2] = new ScriptObject();
$Class[$Stat::Charisma].MeleeSmashTalents[2].Name = "Improved Melee Smash";
$Class[$Stat::Charisma].MeleeSmashTalents[2].Effect = "2";
$Class[$Stat::Charisma].MeleeSmashTalents[2].AppliesTo = "MeleeDamage";
$Class[$Stat::Charisma].MeleeSmashTalents[2].Time = "Passive";
$Class[$Stat::Charisma].MeleeSmashTalents[2].Prerequisite = "1";

$Class[$Stat::Charisma].MeleeSmashTalents[3] = new ScriptObject();
$Class[$Stat::Charisma].MeleeSmashTalents[3].Name = "Advanced Melee Smash";
$Class[$Stat::Charisma].MeleeSmashTalents[3].Effect = "3";
$Class[$Stat::Charisma].MeleeSmashTalents[3].AppliesTo = "MeleeDamage";
$Class[$Stat::Charisma].MeleeSmashTalents[3].Time = "Passive";
$Class[$Stat::Charisma].MeleeSmashTalents[3].Prerequisite = "2";
