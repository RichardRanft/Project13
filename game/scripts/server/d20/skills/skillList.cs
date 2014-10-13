//-----------------------------------------------------------------------------
// Project13
// 3 Jan 2014
// d20 skill list
//-----------------------------------------------------------------------------

//OPEN GAME LICENSE Version 1::0a
//
//The following text is the property of Wizards of the Coast, Inc:: and is Copyright 
//2000 Wizards of the Coast, Inc ("Wizards"):: All Rights Reserved::

//1:: Definitions: 
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
//specifically excludes Product Identity:: 
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
//create Derivative Material of Open Game Content:: (h) "You" or "Your" means the licensee in terms of this agreement::

//2:: The License: This License applies to any Open Game Content that contains a notice indicating that the Open Game 
//Content may only be Used under and in terms of this License:: You must affix such a notice to any Open Game Content 
//that you Use:: No terms may be added to or subtracted from this License except as described by the License itself:: 
//No other terms or conditions may be applied to any Open Game Content distributed using this License::
//
//3::Offer and Acceptance: By Using the Open Game Content You indicate Your acceptance of the terms of this License::
//
//4:: Grant and Consideration: In consideration for agreeing to use this License, the Contributors grant You a perpetual, 
//worldwide, royalty-free, non-exclusive license with the exact terms of this License to Use, the Open Game Content::
//
//5::Representation of Authority to Contribute: If You are contributing original material as Open Game Content, You 
//represent that Your Contributions are Your original creation and/or You have sufficient rights to grant the rights 
//conveyed by this License::
//
//6::Notice of License Copyright: You must update the COPYRIGHT NOTICE portion of this License to include the exact 
//text of the COPYRIGHT NOTICE of any Open Game Content You are copying, modifying or distributing, and You must add 
//the title, the copyright date, and the copyright holder's name to the COPYRIGHT NOTICE of any original Open Game 
//Content you Distribute::
//
//7:: Use of Product Identity: You agree not to Use any Product Identity, including as an indication as to compatibility, 
//except as expressly licensed in another, independent Agreement with the owner of each element of that Product Identity:: 
//You agree not to indicate compatibility or co-adaptability with any Trademark or Registered Trademark in conjunction 
//with a work containing Open Game Content except as expressly licensed in another, independent Agreement with the owner 
//of such Trademark or Registered Trademark:: The use of any Product Identity in Open Game Content does not constitute a 
//challenge to the ownership of that Product Identity:: The owner of any Product Identity used in Open Game Content shall 
//retain all rights, title and interest in and to that Product Identity::
//
//8:: Identification: If you distribute Open Game Content You must clearly indicate which portions of the work that you 
//are distributing are Open Game Content::
//
//9:: Updating the License: Wizards or its designated Agents may publish updated versions of this License:: You may use 
//any authorized version of this License to copy, modify and distribute any Open Game Content originally distributed under 
//any version of this License::
//
//10:: Copy of this License: You MUST include a copy of this License with every copy of the Open Game Content You Distribute::
//
//11:: Use of Contributor Credits: You may not market or advertise the Open Game Content using the name of any Contributor 
//unless You have written permission from the Contributor to do so::
//
//12 Inability to Comply: If it is impossible for You to comply with any of the terms of this License with respect to some 
//or all of the Open Game Content due to statute, judicial order, or governmental regulation then You may not Use any Open 
//Game Material so affected::
//
//13 Termination: This License will terminate automatically if You fail to comply with all terms herein and fail to cure 
//such breach within 30 days of becoming aware of the breach:: All sublicenses shall survive the termination of this License::
//
//14 Reformation: If any provision of this License is held to be unenforceable, such provision shall be reformed only to the 
//extent necessary to make it enforceable::
//
//15 COPYRIGHT NOTICE
//Open Game License v 1::0 Copyright 2000, Wizards of the Coast, Inc::

echo(" -- d20/skills/skillList::cs");

$Skills::Balance::id = 1000;
$Skills::Balance::Name = "Balance";
$Skills::Balance::Stat = "Dexterity";
$Skills::Balance::Trained = false;
$Skills::Balance::ArmorPenalty = true;

$Skills::Bluff::id = 1001;
$Skills::Bluff::Name = "Bluff";
$Skills::Bluff::Stat = "Charisma";
$Skills::Bluff::Trained = false;
$Skills::Bluff::ArmorPenalty = false;

$Skills::Climb::id = 1002;
$Skills::Climb::Name = "Climb";
$Skills::Climb::Stat = "Strength";
$Skills::Climb::Trained = false;
$Skills::Climb::ArmorPenalty = true;

$Skills::ComputerUse::id = 1003;
$Skills::ComputerUse::Name = "Computer Use";
$Skills::ComputerUse::Stat = "Intelligence";
$Skills::ComputerUse::Trained = false;
$Skills::ComputerUse::ArmorPenalty = false;

$Skills::Concentration::id = 1004;
$Skills::Concentration::Name = "Concentration";
$Skills::Concentration::Stat = "Constitution";
$Skills::Concentration::Trained = false;
$Skills::Concentration::ArmorPenalty = false;

$Skills::Craft::Chemical::id = 1005;
$Skills::Craft::Chemical::Name = "Craft (chemical)";
$Skills::Craft::Chemical::Stat = "Intelligence";
$Skills::Craft::Chemical::Trained = true;
$Skills::Craft::Chemical::ArmorPenalty = false;

$Skills::Craft::Electronic::id = 1006;
$Skills::Craft::Electronic::Name = "Craft (electronic)";
$Skills::Craft::Electronic::Stat = "Intelligence";
$Skills::Craft::Electronic::Trained = true;
$Skills::Craft::Electronic::ArmorPenalty = false;

$Skills::Craft::Mechanical::id = 1007;
$Skills::Craft::Mechanical::Name = "Craft (mechanical)";
$Skills::Craft::Mechanical::Stat = "Intelligence";
$Skills::Craft::Mechanical::Trained = true;
$Skills::Craft::Mechanical::ArmorPenalty = false;

$Skills::Craft::Pharmaceutical::id = 1008;
$Skills::Craft::Pharmaceutical::Name = "Craft (pharmaceutical)";
$Skills::Craft::Pharmaceutical::Stat = "Intelligence";
$Skills::Craft::Pharmaceutical::Trained = true;
$Skills::Craft::Pharmaceutical::ArmorPenalty = false;

$Skills::Craft::Structural::id = 1009;
$Skills::Craft::Structural::Name = "Craft (structural)";
$Skills::Craft::Structural::Stat = "Intelligence";
$Skills::Craft::Structural::Trained = true;
$Skills::Craft::Structural::ArmorPenalty = false;

$Skills::Craft::VisualArts::id = 1010;
$Skills::Craft::VisualArts::Name = "Craft (visual arts)";
$Skills::Craft::VisualArts::Stat = "Intelligence";
$Skills::Craft::VisualArts::Trained = true;
$Skills::Craft::VisualArts::ArmorPenalty = false;

$Skills::Craft::Writing::id = 1011;
$Skills::Craft::Writing::Name = "Craft (writing)";
$Skills::Craft::Writing::Stat = "Intelligence";
$Skills::Craft::Writing::Trained = false;
$Skills::Craft::Writing::ArmorPenalty = false;

$Skills::DecipherScript::id = 1012;
$Skills::DecipherScript::Name = "Decipher Script";
$Skills::DecipherScript::Stat = "Intelligence";
$Skills::DecipherScript::Trained = true;
$Skills::DecipherScript::ArmorPenalty = false;

$Skills::Demolitions::id = 1013;
$Skills::Demolitions::Name = "Demolitions";
$Skills::Demolitions::Stat = "Intelligence";
$Skills::Demolitions::Trained = true;
$Skills::Demolitions::ArmorPenalty = false;

$Skills::Diplomacy::id = 1014;
$Skills::Diplomacy::Name = "Diplomacy";
$Skills::Diplomacy::Stat = "Charisma";
$Skills::Diplomacy::Trained = false;
$Skills::Diplomacy::ArmorPenalty = false;

$Skills::DisableDevice::id = 1015;
$Skills::DisableDevice::Name = "Disable Device";
$Skills::DisableDevice::Stat = "Intelligence";
$Skills::DisableDevice::Trained = true;
$Skills::DisableDevice::ArmorPenalty = true;

$Skills::Disguise::id = 1016;
$Skills::Disguise::Name = "Disguise";
$Skills::Disguise::Stat = "Charisma";
$Skills::Disguise::Trained = false;
$Skills::Disguise::ArmorPenalty = false;

$Skills::Drive::id = 1017;
$Skills::Drive::Name = "Drive";
$Skills::Drive::Stat = "Dexterity";
$Skills::Drive::Trained = False;
$Skills::Drive::ArmorPenalty = false;

$Skills::EscapeArtist::id = 1018;
$Skills::EscapeArtist::Name = "Escape Artist";
$Skills::EscapeArtist::Stat = "Dexterity";
$Skills::EscapeArtist::Trained = false;
$Skills::EscapeArtist::ArmorPenalty = true;

$Skills::Forgery::id = 1019;
$Skills::Forgery::Name = "Forgery";
$Skills::Forgery::Stat = "Intelligence";
$Skills::Forgery::Trained = false;
$Skills::Forgery::ArmorPenalty = false;

$Skills::Gamble::id = 1020;
$Skills::Gamble::Name = "Gamble";
$Skills::Gamble::Stat = "Wisdom";
$Skills::Gamble::Trained = false;
$Skills::Gamble::ArmorPenalty = false;

$Skills::GatherInformation::id = 1021;
$Skills::GatherInformation::Name = "Gather Information";
$Skills::GatherInformation::Stat = "Charisma";
$Skills::GatherInformation::Trained = false;
$Skills::GatherInformation::ArmorPenalty = false;

$Skills::HandleAnimal::id = 1022;
$Skills::HandleAnimal::Name = "Handle Animal";
$Skills::HandleAnimal::Stat = "Charisma";
$Skills::HandleAnimal::Trained = true;
$Skills::HandleAnimal::ArmorPenalty = false;

$Skills::Hide::id = 1023;
$Skills::Hide::Name = "Hide";
$Skills::Hide::Stat = "Dexterity";
$Skills::Hide::Trained = false;
$Skills::Hide::ArmorPenalty = true;

$Skills::Intimidate::id = 1024;
$Skills::Intimidate::Name = "Intimidate";
$Skills::Intimidate::Stat = "Charisma";
$Skills::Intimidate::Trained = false;
$Skills::Intimidate::ArmorPenalty = false;

$Skills::Investigate::id = 1025;
$Skills::Investigate::Name = "Investigate";
$Skills::Investigate::Stat = "Intelligence";
$Skills::Investigate::Trained = true;
$Skills::Investigate::ArmorPenalty = false;

$Skills::Jump::id = 1026;
$Skills::Jump::Name = "Jump";
$Skills::Jump::Stat = "Strength";
$Skills::Jump::Trained = false;
$Skills::Jump::ArmorPenalty = true;

$Skills::Knowledge::ArcaneLore::id = 1027;
$Skills::Knowledge::ArcaneLore::Name = "Knowledge; Arcane Lore";
$Skills::Knowledge::ArcaneLore::Stat = "Intelligence";
$Skills::Knowledge::ArcaneLore::Trained = true;
$Skills::Knowledge::ArcaneLore::ArmorPenalty = false;

$Skills::Knowledge::BehavioralScience::id = 1028;
$Skills::Knowledge::BehavioralScience::Name = "Knowledge; Behavioral Science";
$Skills::Knowledge::BehavioralScience::Stat = "Intelligence";
$Skills::Knowledge::BehavioralScience::Trained = true;
$Skills::Knowledge::BehavioralScience::ArmorPenalty = false;

$Skills::Knowledge::Business::id = 1029;
$Skills::Knowledge::Business::Name = "Knowledge; Business";
$Skills::Knowledge::Business::Stat = "Intelligence";
$Skills::Knowledge::Business::Trained = true;
$Skills::Knowledge::Business::ArmorPenalty = false;

$Skills::Knowledge::Civics::id = 1030;
$Skills::Knowledge::Civics::Name = "Knowledge; Civics";
$Skills::Knowledge::Civics::Stat = "Intelligence";
$Skills::Knowledge::Civics::Trained = true;
$Skills::Knowledge::Civics::ArmorPenalty = false;

$Skills::Knowledge::CurrentEvents::id = 1031;
$Skills::Knowledge::CurrentEvents::Name = "Knowledge; Current Events";
$Skills::Knowledge::CurrentEvents::Stat = "Intelligence";
$Skills::Knowledge::CurrentEvents::Trained = true;
$Skills::Knowledge::CurrentEvents::ArmorPenalty = false;

$Skills::Knowledge::EarthScience::id = 1032;
$Skills::Knowledge::EarthScience::Name = "Knowledge; Earth and Life Sciences";
$Skills::Knowledge::EarthScience::Stat = "Intelligence";
$Skills::Knowledge::EarthScience::Trained = true;
$Skills::Knowledge::EarthScience::ArmorPenalty = false;

$Skills::Knowledge::History::id = 1033;
$Skills::Knowledge::History::Name = "Knowledge; History";
$Skills::Knowledge::History::Stat = "Intelligence";
$Skills::Knowledge::History::Trained = true;
$Skills::Knowledge::History::ArmorPenalty = false;

$Skills::Knowledge::PhysicalSciences::id = 1034;
$Skills::Knowledge::PhysicalSciences::Name = "Knowledge; Physical Sciences";
$Skills::Knowledge::PhysicalSciences::Stat = "Intelligence";
$Skills::Knowledge::PhysicalSciences::Trained = true;
$Skills::Knowledge::PhysicalSciences::ArmorPenalty = false;

$Skills::Knowledge::PopularCulture::id = 1035;
$Skills::Knowledge::PopularCulture::Name = "Knowledge; Popular Culture";
$Skills::Knowledge::PopularCulture::Stat = "Intelligence";
$Skills::Knowledge::PopularCulture::Trained = true;
$Skills::Knowledge::PopularCulture::ArmorPenalty = false;

$Skills::Knowledge::Streetwise::id = 1036;
$Skills::Knowledge::Streetwise::Name = "Knowledge; Streetwise";
$Skills::Knowledge::Streetwise::Stat = "Intelligence";
$Skills::Knowledge::Streetwise::Trained = true;
$Skills::Knowledge::Streetwise::ArmorPenalty = false;

$Skills::Knowledge::Tactics::id = 1037;
$Skills::Knowledge::Tactics::Name = "Knowledge; Tactics";
$Skills::Knowledge::Tactics::Stat = "Intelligence";
$Skills::Knowledge::Tactics::Trained = true;
$Skills::Knowledge::Tactics::ArmorPenalty = false;

$Skills::Knowledge::Technology::id = 1038;
$Skills::Knowledge::Technology::Name = "Knowledge; Technology";
$Skills::Knowledge::Technology::Stat = "Intelligence";
$Skills::Knowledge::Technology::Trained = true;
$Skills::Knowledge::Technology::ArmorPenalty = false;

$Skills::Knowledge::Theology::id = 1039;
$Skills::Knowledge::Theology::Name = "Knowledge; Theology and Philosophy";
$Skills::Knowledge::Theology::Stat = "Intelligence";
$Skills::Knowledge::Theology::Trained = true;
$Skills::Knowledge::Theology::ArmorPenalty = false;

$Skills::Listen::id = 1040;
$Skills::Listen::Name = "Listen";
$Skills::Listen::Stat = "Wisdom";
$Skills::Listen::Trained = false;
$Skills::Listen::ArmorPenalty = false;

$Skills::MoveSilently::id = 1041;
$Skills::MoveSilently::Name = "Move Silently";
$Skills::MoveSilently::Stat = "Dexterity";
$Skills::MoveSilently::Trained = false;
$Skills::MoveSilently::ArmorPenalty = true;

$Skills::Navigate::id = 1042;
$Skills::Navigate::Name = "Navigate";
$Skills::Navigate::Stat = "Intelligence";
$Skills::Navigate::Trained = false;
$Skills::Navigate::ArmorPenalty = false;

$Skills::Perform::Act::id = 1043;
$Skills::Perform::Act::Name = "Perform; Act";
$Skills::Perform::Act::Stat = "Charisma";
$Skills::Perform::Act::Trained = false;
$Skills::Perform::Act::ArmorPenalty = false;

$Skills::Perform::Dance::id = 1044;
$Skills::Perform::Dance::Name = "Perform; Dance";
$Skills::Perform::Dance::Stat = "Charisma";
$Skills::Perform::Dance::Trained = false;
$Skills::Perform::Dance::ArmorPenalty = false;

$Skills::Perform::Keyboards::id = 1045;
$Skills::Perform::Keyboards::Name = "Perform; Keyboards";
$Skills::Perform::Keyboards::Stat = "Charisma";
$Skills::Perform::Keyboards::Trained = false;
$Skills::Perform::Keyboards::ArmorPenalty = false;

$Skills::Perform::Percussion::id = 1046;
$Skills::Perform::Percussion::Name = "Perform; Percussion Instruments";
$Skills::Perform::Percussion::Stat = "Charisma";
$Skills::Perform::Percussion::Trained = false;
$Skills::Perform::Percussion::ArmorPenalty = false;

$Skills::Perform::Sing::id = 1047;
$Skills::Perform::Sing::Name = "Perform; Sing";
$Skills::Perform::Sing::Stat = "Charisma";
$Skills::Perform::Sing::Trained = false;
$Skills::Perform::Sing::ArmorPenalty = false;

$Skills::Perform::Standup::id = 1048;
$Skills::Perform::Standup::Name = "Perform; Stand-Up";
$Skills::Perform::Standup::Stat = "Charisma";
$Skills::Perform::Standup::Trained = false;
$Skills::Perform::Standup::ArmorPenalty = false;

$Skills::Perform::Stringed::id = 1049;
$Skills::Perform::Stringed::Name = "Perform; Stringed Instruments";
$Skills::Perform::Stringed::Stat = "Charisma";
$Skills::Perform::Stringed::Trained = false;
$Skills::Perform::Stringed::ArmorPenalty = false;

$Skills::Perform::Wind::id = 1050;
$Skills::Perform::Wind::Name = "Perform; Wind Instruments";
$Skills::Perform::Wind::Stat = "Charisma";
$Skills::Perform::Wind::Trained = false;
$Skills::Perform::Wind::ArmorPenalty = false;

$Skills::Pilot::id = 1051;
$Skills::Pilot::Name = "Pilot";
$Skills::Pilot::Stat = "Dexterity";
$Skills::Pilot::Trained = true;
$Skills::Pilot::ArmorPenalty = false;

$Skills::Profession::id = 1052;
$Skills::Profession::Name = "Profession";
$Skills::Profession::Stat = "Wisdom";
$Skills::Profession::Trained = false;
$Skills::Profession::ArmorPenalty = false;

$Skills::ReadLanguage::id = 1053;
$Skills::ReadLanguage::Name = "Read/Write Languages";
$Skills::ReadLanguage::Stat = "None";
$Skills::ReadLanguage::Trained = true;
$Skills::ReadLanguage::ArmorPenalty = false;

$Skills::Repair::id = 1054;
$Skills::Repair::Name = "Repair";
$Skills::Repair::Stat = "Intelligence";
$Skills::Repair::Trained = true;
$Skills::Repair::ArmorPenalty = false;

$Skills::Research::id = 1055;
$Skills::Research::Name = "Research";
$Skills::Research::Stat = "Intelligence";
$Skills::Research::Trained = false;
$Skills::Research::ArmorPenalty = false;

$Skills::Ride::id = 1056;
$Skills::Ride::Name = "Ride";
$Skills::Ride::Stat = "Dexterity";
$Skills::Ride::Trained = false;
$Skills::Ride::ArmorPenalty = false;

$Skills::Search::id = 1057;
$Skills::Search::Name = "Search";
$Skills::Search::Stat = "Intelligence";
$Skills::Search::Trained = false;
$Skills::Search::ArmorPenalty = false;

$Skills::SenseMotive::id = 1058;
$Skills::SenseMotive::Name = "Sense Motive";
$Skills::SenseMotive::Stat = "Wisdom";
$Skills::SenseMotive::Trained = false;
$Skills::SenseMotive::ArmorPenalty = false;

$Skills::SleightOfHand::id = 1059;
$Skills::SleightOfHand::Name = "Sleight of Hand";
$Skills::SleightOfHand::Stat = "Dexterity";
$Skills::SleightOfHand::Trained = true;
$Skills::SleightOfHand::ArmorPenalty = true;

$Skills::SpeakLanguage::id = 1060;
$Skills::SpeakLanguage::Name = "Speak Language";
$Skills::SpeakLanguage::Stat = "None";
$Skills::SpeakLanguage::Trained = true;
$Skills::SpeakLanguage::ArmorPenalty = false;

$Skills::Spot::id = 1061;
$Skills::Spot::Name = "Spot";
$Skills::Spot::Stat = "Wisdom";
$Skills::Spot::Trained = false;
$Skills::Spot::ArmorPenalty = false;

$Skills::Survival::id = 1062;
$Skills::Survival::Name = "Survival";
$Skills::Survival::Stat = "Wisdom";
$Skills::Survival::Trained = false;
$Skills::Survival::ArmorPenalty = false;

$Skills::Swim::id = 1063;
$Skills::Swim::Name = "Swim";
$Skills::Swim::Stat = "Strength";
$Skills::Swim::Trained = false;
$Skills::Swim::ArmorPenalty = true;

$Skills::TreatInjury::id = 1064;
$Skills::TreatInjury::Name = "Treat Injury";
$Skills::TreatInjury::Stat = "Wisdom";
$Skills::TreatInjury::Trained = false;
$Skills::TreatInjury::ArmorPenalty = false;

$Skills::Tumble::id = 1065;
$Skills::Tumble::Name = "Tumble";
$Skills::Tumble::Stat = "Dexterity";
$Skills::Tumble::Trained = true;
$Skills::Tumble::ArmorPenalty = true;
