$PlayerDatablocks = new SimSet()
{
    class = "PlayerDatablockList";
};

function PlayerDatablockList::init(%this)
{
    %this.clearDatablocks();
    %this.loadData();
}

function PlayerDatablockList::addDatablock(%this, %datablock)
{
    if(!%this.isMember(%datablock))
        %this.add(%datablock);
}

function PlayerDatablockList::clearDatablocks(%this)
{
    while(isObject(%obj = %this.getObject(0)))
    {
        %this.remove(%obj);
    }
    %this.clear();
}

function PlayerDatablockList::loadData(%this, %path)
{
    // find main.cs
    %search = "art/datablocks/aiPlayer/*.cs";
    // search for scripts and load them
    for( %file = findFirstFile( %search ); %file !$= ""; %file = findNextFile( %search ) )
    {
        %this.readDatablockInfo(%file);
    }
}

function PlayerDatablockList::readDatablockInfo( %this, %fileName )
{
    %infoObject = new ScriptObject();
    %infoObject.shapeFileInfo = "";
    %infoObject.datablockName = "";
    %file = new FileObject();
    %validFile = false;

    if ( %file.openForRead( %fileName ) )
    {
        %validFile = true;
        %inInfoBlock = false;
        %dbNameFound = false;
		
        while ( !%file.isEOF() )
        {
            %line = %file.readLine();
            %line = trim( %line );
            %tempLine = strreplace(%line, "datablock PlayerData(", "");
			
            if( %line !$= %tempLine ) // deduction by negatives - this is the start of a PlayerData datablock
                %inInfoBlock = true;
            else if( %inInfoBlock && %line $= "};" )
            {
                %inInfoBlock = false;
                %infoObject = %infoObject @ %line; 
                break;
			}
			
			if( %inInfoBlock )
			{
			    if (!%dbNameFound)
			    {
			        // find datablock name
			        %schloc = strchr(%tempLine, ":");
			        %dbName = trim(strreplace(%tempLine, %schloc, ""));
			        %infoObject.datablockName = %dbName;
			        %dbNameFound = true;
			    }
			    else
			    {
			        %tempLine = strreplace(%line, "shapeFile = ", "");
			        if (%line !$= %tempLine) // found the shapefile entry
			        {
			            %sfName = trim(strreplace(%tempLine, "\"", ""));
			            %sfName = strreplace(%sfName, ";", "");
			            %infoObject.shapeFileInfo = trim(%sfName);
			        }
			    }
			}
		}
		
		%file.close();
    }
    else
    {
	    %validFile = false;
        error("Datablock file " @ %fileName @ " not found.");
    }

	%file.delete();
	%this.addDatablock(%infoObject);
}

$PlayerDatablocks.init();