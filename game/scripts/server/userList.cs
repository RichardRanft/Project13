// below are space delimited data fields.  broken into classes for no really good reason
// except to make sorting out appropriate mission names easier I guess.
$UserList::Class1[0] = "JJohnson password mission1";
$UserList::Class1[1] = "BBobson password mission1";
$UserList::Class2[0] = "PPatterson password mission2";
$UserList::Class2[1] = "LLineman password mission2";
$UserList::Class3[0] = "RRothchild password mission3";
$UserList::Class3[1] = "SStevens password mission3";

function UserList::getUserInformation(%userName, %classNum)
{
    for(%index = 0; %data !$= ""; %index++)
    {
        eval("%data = $UserList::Class"@%classNum@"[0];");
        %name = getWord(%data, 0);
        if(%name $= %userName)
            return %data;
    }
}

echo(" -- $UserList::Class1[1] : " @ UserList::getUserInformation("BBobson", 1) );