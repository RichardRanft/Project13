//-----------------------------------------------------------------------------
// Project13
// 3 Jan 2014
// d20 character sheet script
//-----------------------------------------------------------------------------

function toggleCharSheet(%make)
{
    // Finish if being released.
    if ( !%make )
    {
        //echo(" -- make : " @ %make);
        return;
    }
        
    %currentUI = Canvas.getContent();
    // Is the console awake?
    if ( !CharacterSheet.isAwake() )
    {
        %currentUI.add(CharacterSheet);    
        return;
    }
    
    %currentUI.remove(CharacterSheet);
}

//moveMap.bind( keyboard, c, toggleCharSheet );

function CharacterSheet::onDialogPush(%this)
{
    // get active character
    
    // update character fields
}

function CharacterSheet::onDialogPop(%this)
{
}
