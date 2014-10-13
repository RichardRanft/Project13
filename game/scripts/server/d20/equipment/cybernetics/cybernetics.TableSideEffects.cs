//-----------------------------------------------------------------------------
// Copyright (c) 2014 Roostertail Games
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

//OPEN GAME LICENSE Version 1.0a
//
//The following text is the property of Wizards of the Coast, Inc. and is Copyright 
//2000 Wizards of the Coast, Inc ("Wizards"). All Rights Reserved.

//1. Definitions: 
//  (a)"Contributors" means the copyright and/or trademark owners who have contributed 
//Open Game Content; 

//  (b)"Derivative Material" means copyrighted material including derivative works and 
//translations (including into other computer languages), potation, modification, correction, addition, 
//extension, upgrade, improvement, compilation, abridgment or other form in which an existing work may be 
//recast, transformed or adapted; 

//  (c) "Distribute" means to reproduce, license, rent, lease, sell, broadcast, publicly display, transmit 
//or otherwise distribute; 

//  (d)"Open Game Content" means the game mechanic and includes the methods, procedures, processes and 
//routines to the extent such content does not embody the Product Identity and is an enhancement over the 
//prior art and any additional content clearly identified as Open Game Content by the Contributor, and means 
//any work covered by this License, including translations and derivative works under copyright law, but 
//specifically excludes Product Identity. 

//  (e) "Product Identity" means product and product line names, logos and identifying marks including trade 
//dress; artifacts; creatures characters; stories, storylines, plots, thematic elements, dialogue, incidents, 
//language, artwork, symbols, designs, depictions, likenesses, formats, poses, concepts, themes and graphic, 
//photographic and other visual or audio representations; names and descriptions of characters, spells, 
//enchantments, personalities, teams, personas, likenesses and special abilities; places, locations, 
//environments, creatures, equipment, magical or supernatural abilities or effects, logos, symbols, 
//or graphic designs; and any other trademark or registered trademark clearly identified as Product identity 
//by the owner of the Product Identity, and which specifically excludes the Open Game Content; 

//  (f) "Trademark" means the logos, names, mark, sign, motto, designs that are used by a Contributor to identify 
//itself or its products or the associated products contributed to the Open Game License by the Contributor 

//  (g) "Use", "Used" or "Using" means to use, Distribute, copy, edit, format, modify, translate and otherwise 
//create Derivative Material of Open Game Content. 

//  (h) "You" or "Your" means the licensee in terms of this agreement.

//2. The License: This License applies to any Open Game Content that contains a notice indicating that the Open Game 
//Content may only be Used under and in terms of this License. You must affix such a notice to any Open Game Content 
//that you Use. No terms may be added to or subtracted from this License except as described by the License itself. 
//No other terms or conditions may be applied to any Open Game Content distributed using this License.

//3.Offer and Acceptance: By Using the Open Game Content You indicate Your acceptance of the terms of this License.

//4. Grant and Consideration: In consideration for agreeing to use this License, the Contributors grant You a perpetual, 
//worldwide, royalty-free, non-exclusive license with the exact terms of this License to Use, the Open Game Content.

//5.Representation of Authority to Contribute: If You are contributing original material as Open Game Content, You 
//represent that Your Contributions are Your original creation and/or You have sufficient rights to grant the rights 
//conveyed by this License.

//6.Notice of License Copyright: You must update the COPYRIGHT NOTICE portion of this License to include the exact 
//text of the COPYRIGHT NOTICE of any Open Game Content You are copying, modifying or distributing, and You must add 
//the title, the copyright date, and the copyright holder's name to the COPYRIGHT NOTICE of any original Open Game 
//Content you Distribute.

//7. Use of Product Identity: You agree not to Use any Product Identity, including as an indication as to compatibility, 
//except as expressly licensed in another, independent Agreement with the owner of each element of that Product Identity. 
//You agree not to indicate compatibility or co-adaptability with any Trademark or Registered Trademark in conjunction 
//with a work containing Open Game Content except as expressly licensed in another, independent Agreement with the owner 
//of such Trademark or Registered Trademark. The use of any Product Identity in Open Game Content does not constitute a 
//challenge to the ownership of that Product Identity. The owner of any Product Identity used in Open Game Content shall 
//retain all rights, title and interest in and to that Product Identity.

//8. Identification: If you distribute Open Game Content You must clearly indicate which portions of the work that you 
//are distributing are Open Game Content.

//9. Updating the License: Wizards or its designated Agents may publish updated versions of this License. You may use 
//any authorized version of this License to copy, modify and distribute any Open Game Content originally distributed under 
//any version of this License.

//10. Copy of this License: You MUST include a copy of this License with every copy of the Open Game Content You Distribute.

//11. Use of Contributor Credits: You may not market or advertise the Open Game Content using the name of any Contributor 
//unless You have written permission from the Contributor to do so.

//12 Inability to Comply: If it is impossible for You to comply with any of the terms of this License with respect to some 
//or all of the Open Game Content due to statute, judicial order, or governmental regulation then You may not Use any Open 
//Game Material so affected.

//13 Termination: This License will terminate automatically if You fail to comply with all terms herein and fail to cure 
//such breach within 30 days of becoming aware of the breach. All sublicenses shall survive the termination of this License.

//14 Reformation: If any provision of this License is held to be unenforceable, such provision shall be reformed only to the 
//extent necessary to make it enforceable.

//15 COPYRIGHT NOTICE
//Open Game License v 1.0 Copyright 2000, Wizards of the Coast, Inc.

// ----------------------------------------------------------------------------

// Table: TableSideEffects
$TableCyberneticsSideEffects::dRoll[0] = "01 08";
$TableCyberneticsSideEffects::SideEffect[0] = "Blurred Vision";
$TableCyberneticsSideEffects::SideEffectType[0] = "MissChance";
$TableCyberneticsSideEffects::SideEffectValue[0] = "Miss:20%";

$TableCyberneticsSideEffects::dRoll[1] = "09 17";
$TableCyberneticsSideEffects::SideEffect[1] = "Constant Trembling";
$TableCyberneticsSideEffects::SideEffectType[1] = "Check";
$TableCyberneticsSideEffects::SideEffectValue[1] = "DexCheck:-2";

$TableCyberneticsSideEffects::dRoll[2] = "18 25";
$TableCyberneticsSideEffects::SideEffect[2] = "Cybernetic Rejection";
$TableCyberneticsSideEffects::SideEffectType[2] = "ConDamage";
$TableCyberneticsSideEffects::SideEffectValue[2] = "ConDamage:-1d4";

$TableCyberneticsSideEffects::dRoll[3] = "26 34";
$TableCyberneticsSideEffects::SideEffect[3] = "Dizziness";
$TableCyberneticsSideEffects::SideEffectType[3] = "ASAS";  // Attack, Saves, Ability Check, Skill Check
$TableCyberneticsSideEffects::SideEffectValue[3] = "ASAS:-1";

$TableCyberneticsSideEffects::dRoll[4] = "35 42";
$TableCyberneticsSideEffects::SideEffect[4] = "Impaired Hearing";
$TableCyberneticsSideEffects::SideEffectType[4] = "Check";
$TableCyberneticsSideEffects::SideEffectValue[4] = "Listen:-2";

$TableCyberneticsSideEffects::dRoll[5] = "43 50";
$TableCyberneticsSideEffects::SideEffect[5] = "Impaired Vision";
$TableCyberneticsSideEffects::SideEffectType[5] = "Check";
$TableCyberneticsSideEffects::SideEffectValue[5] = "Spot:-2";

$TableCyberneticsSideEffects::dRoll[6] = "51 59";
$TableCyberneticsSideEffects::SideEffect[6] = "Insomnia";
$TableCyberneticsSideEffects::SideEffectType[6] = "RecoveryPenalty";
$TableCyberneticsSideEffects::SideEffectValue[6] = "Health:None";

$TableCyberneticsSideEffects::dRoll[7] = "60 67";
$TableCyberneticsSideEffects::SideEffect[7] = "Muscle Cramps";
$TableCyberneticsSideEffects::SideEffectType[7] = "Penalty";
$TableCyberneticsSideEffects::SideEffectValue[7] = "Move:50%";

$TableCyberneticsSideEffects::dRoll[8] = "68 76";
$TableCyberneticsSideEffects::SideEffect[8] = "Muscle Fatigue";
$TableCyberneticsSideEffects::SideEffectType[8] = "Check";
$TableCyberneticsSideEffects::SideEffectValue[8] = "Str:-2";

$TableCyberneticsSideEffects::dRoll[9] = "77 84";
$TableCyberneticsSideEffects::SideEffect[9] = "Power Surge";
$TableCyberneticsSideEffects::SideEffectType[9] = "MissChance";
$TableCyberneticsSideEffects::SideEffectValue[9] = "Miss:20%";

$TableCyberneticsSideEffects::dRoll[10] = "85 93";
$TableCyberneticsSideEffects::SideEffect[10] = "Psychosis";
$TableCyberneticsSideEffects::SideEffectType[10] = "Impared";
$TableCyberneticsSideEffects::SideEffectValue[10] = "Shaken:1:DC12";

$TableCyberneticsSideEffects::dRoll[11] = "94 100";
$TableCyberneticsSideEffects::SideEffect[11] = "Sensory Overload";
$TableCyberneticsSideEffects::SideEffectType[11] = "Impared";
$TableCyberneticsSideEffects::SideEffectValue[11] = "Stunned:1:DC15";

$TableCyberneticsSideEffects::EffectCount = 12;

/// <summary>
/// Takes a ScriptObject containing special damage effect data and adds 
/// a new ScriptObject containing side effect data for cybernetics.
/// </summary>
/// <param name="effect">A script object that carries effect data.</param>
function Cybernetics::getSideEffect(%effect)
{
    %sideEffect = new ScriptObject();
    %roll = getRandom(1, 100);
    for(%i = 0; %i < $TableCyberneticsSideEffects::::EffectCount; %i++)
    {
        %rngMin = getWord($TableCyberneticsSideEffects::dRoll[%i], 0);
        %rngMax = getWord($TableCyberneticsSideEffects::dRoll[%i], 1);
        if( %roll >= %rngMin && %roll <= %rngMax )
        {
            %sideEffect.roll = %roll; // for debugging
            %sideEffect.index = %i;
            %sideEffect.description = $TableCyberneticsSideEffects::SideEffect[%i];
            %sideEffect.effectType = $TableCyberneticsSideEffects::SideEffectType[%i];
            %sideEffect.effectValue = $TableCyberneticsSideEffects::SideEffectValue[%i];

            %effect.sideEffect = %sideEffect; // placeholder
            return;
        }
    }
}