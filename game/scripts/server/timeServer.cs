$TimeServerList[0] = "nist1-nj2.ustiming.org";
$TimeServerList[1] = "nist1-ny2.ustiming.org";
$TimeServerList[2] = "nist1-pa.ustiming.org";
$TimeServerList[3] = "time-a.nist.gov"; // busy
$TimeServerList[4] = "time-b.nist.gov"; // busy
$TimeServerList[5] = "time-c.nist.gov";
$TimeServerList[6] = "time-d.nist.gov";
$TimeServerList[7] = "nist1-macon.macon.ga.us";
$TimeServerList[8] = "wolfnisttime.com";
$TimeServerList[9] = "nist1-chi.ustiming.org";
$TimeServerList[10] = "nist.time.nosc.us";
$TimeServerList[11] = "nist.expertsmi.com";
$TimeServerList[12] = "nist.netservicesgroup.com";
$TimeServerList[13] = "nisttime.carsoncity.k12.mi.us";
$TimeServerList[14] = "nist1-lnk.binary.net";
$TimeServerList[15] = "wwv.nist.gov";
$TimeServerList[16] = "time.nist.gov";
$TimeServerList[17] = "utcnist.colorado.edu";
$TimeServerList[18] = "utcnist2.colorado.edu";
$TimeServerList[19] = "ntp-nist.ldsbc.edu";
$TimeServerList[20] = "nist1-lv.ustiming.org";
$TimeServerList[21] = "nist1-lv.ustiming.org";
$TimeServerList[22] = "nist1.symmetricom.com";
$TimeServerCount = 22;

function InitTimeService()
{
    initializeTimeServiceEventManager();
    
    if( !isObject($TimeServerObject) )
    {
        $TimeServerObject = new TCPObject(){
            class = "TimeServiceObject";
            timeport = "13";
        };
    }
    $TimeServerObject.serverIndex = 0;
    $TimeServerObject.timeservice = $TimeServerList[$TimeServerObject.serverIndex];
    $TimeServerObject.timeout = 4000;
    
    TimeServiceEventManager.subscribe($TimeServerObject, "_ConnectRequest", "onConnectRequested");
    TimeServiceEventManager.subscribe($TimeServerObject, "_ConnectComplete", "onConnectComplete");
}

function TimeServiceObject::onConnectRequested(%this, %data)
{
    echo(" --- Time out in " @ %this.timeout @ "ms...");
    %this.connectRetry = %this.schedule(%this.timeout, tryNext);
}

function TimeServiceObject::onConnectComplete(%this, %data)
{
    %this.cancel(%this.connectRetry);
}

function TimeServiceObject::tryNext(%this)
{
    %this.disconnect();
    if( %this.serverIndex < $TimeServerCount )
        %this.serverIndex++;
    else
        %this.serverIndex = 0;
    %this.timeservice = $TimeServerList[%this.serverIndex];
    %server = %this.timeservice @ ":" @ %this.timeport;
    echo(" -- Connecting to " @ %server);
    %this.connect(%server);
    TimeServiceEventManager.postEvent("_ConnectRequest", %this.serverIndex);
    %this.disconnect();
}

function TimeServiceObject::getTime(%this, %requestedFormat)
{
    %this.timedata = "";
    %this.requestedFormat = %requestedFormat;
    if( %requestedFormat $= "systemtime" )
    {
        %this.timedata = getSystemTime();
        return;
    }
    %server = %this.timeservice @ ":" @ %this.timeport;
    echo(" -- Connecting to " @ %server);
    %this.connect(%server);
    TimeServiceEventManager.postEvent("_ConnectRequest", %this.serverIndex);
    %this.disconnect();
}

function TimeServiceObject::onDNSResolved(%this)
{
    %server = %this.timeservice @ ":" @ %this.timeport;
    echo(" -- Resolved " @ %server);
}

function TimeServiceObject::onDNSFailed(%this)
{
    echo(" --- Unable to resolve " @ %this.timeservice);
    %this.tryNext();
}

function TimeServiceObject::onConnected(%this)
{
    TimeServiceEventManager.postEvent("_ConnectComplete", "");
    %server = %this.timeservice @ ":" @ %this.timeport;
    echo(" -- TimeServiceObjectect connected to " @ %server);
}

function TimeServiceObject::onConnectFailed(%this)
{
    %server = %this.timeservice @ ":" @ %this.timeport;
    echo(" --- Unable to connect to " @ %server);
    %this.tryNext();
}

function TimeServiceObject::onDisconnect(%this)
{
    %server = %this.timeservice @ ":" @ %this.timeport;
    echo(" -- Disconnected from " @ %server);
    echo(" -- TimeData: " @ %this.timedata);
}

function TimeServiceObject::onLine(%this, %line)
{
    if( %line !$= "" )
    {
        echo(" --- Time Data: " @ %line);
        if( %this.requestedFormat $= "Julian" )
            %this.timedata =  getWord(%this.timedata, 0);
        else if( %this.requestedFormat $= "Date" )
            %this.timedata =  getWord(%this.timedata, 1);
        else if( %this.requestedFormat $= "Time" )
            %this.timedata =  getWord(%this.timedata, 2);
        else if( %this.requestedFormat $= "DateTime" )
            %this.timedata =  (getWord(%this.timedata, 1) @ "_" @ getWord(%this.timedata, 2));
        else
            %this.timedata = %line;
    }
    else
        echo(" --- TimeServiceObject recieved an empty line");
}

//Only while in a listen state
function TimeServiceObject::onConnectRequest(%this,%address,%tag)
{
}

// Event manager - handles connection attempt timeout
function initializeTimeServiceEventManager()
{
    if (!isObject(TimeServiceEventManager))
    {
        $TimeServiceEventManager = new EventManager(TimeServiceEventManager)
        { 
            queue = "TimeServiceEventManager"; 
        };
        
        // Module related signals
        TimeServiceEventManager.registerEvent("_ConnectRequest");
        TimeServiceEventManager.registerEvent("_ConnectComplete");
    }
    
    if (!isObject(TimeServiceListener))
    {
        $TimeServiceListener = new ScriptMsgListener(TimeServiceListener) 
        { 
            class = "TimeServiceEventListener"; 
        };
        
        // Module related subscriptions
        TimeServiceEventManager.subscribe(TimeServiceListener, "_ConnectRequest", "onConnectRequested");
        TimeServiceEventManager.subscribe(TimeServiceListener, "_ConnectComplete", "onConnectComplete");
    }
}

// Cleanup the TimeServiceEventManager
function destroyTimeServiceEventManager()
{
    if (isObject(TimeServiceEventManager) && isObject(TimeServiceListener))
    {
        // Remove all the subscriptions5        TimeServiceEventManager.remove(TimeServiceListener, "_AnimUpdateRequest");
        TimeServiceEventManager.remove(TimeServiceListener, "_ConnectRequest");
        TimeServiceEventManager.remove(TimeServiceListener, "_ConnectComplete");

        // Delete the actual objects
        TimeServiceEventManager.delete();
        TimeServiceListener.delete();
        
        // Clear the global variables, just in case
        $TimeServiceEventManager = "";
        $TimeServiceListener = "";
    }
}

// General listener callbacks
function TimeServiceEventListener::onConnectRequested(%this, %msgData)
{
}

function TimeServiceEventListener::onConnectComplete(%this, %msgData)
{
}
