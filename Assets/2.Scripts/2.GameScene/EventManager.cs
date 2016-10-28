using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EVENTDATA {
	NUMBER,
	ARTICLE,
	STORY,
	DAYS,
	FUELS,
	SHIP_FOODS,
	SHIP_WATER,
	GUNS,
	MEDICAL_KITS,
	REPAIR_TOOLS,
	RADIOS,
	SHIP_STATE,
	CHARA_FOODS,
	CHARA_WATER,
	HEALTH,
	LOYALTY,
	DEATH,
	DISEASE,
    ACTIVE,
    NEED,
    MAX,
}

public enum CONTENTS {
    NONE,
    ISLAND,
    SHIP,
    CONTENTS_MAX,
}

public class EventManager : MonoBehaviour {
	
	List<Dictionary<string,object>> data;
    private int data_max;

    // Use this for initialization
    void Start ( ) {
		data = CSVReader.Read("Event_Data");
        data_max = data.Count;
        print( getData( 0, EVENTDATA.NUMBER ) );
	}
	
	// Update is called once per frame
	void Update ( ) {

	}

    public int getMaxData( ) {
        return data_max;
    }

    public object getData( int i, EVENTDATA event_data ) {
		switch ( event_data ) {
		    case EVENTDATA.NUMBER:
		    	return data[ i ][ "No" ];
		    case EVENTDATA.ARTICLE:
                return data[ i ][ "Article" ];
		    case EVENTDATA.STORY:
                return data[ i ][ "Story" ];
		    case EVENTDATA.DAYS:
                return data[ i ][ "Days" ];
		    case EVENTDATA.FUELS:
                return data[ i ][ "Fuels" ];
		    case EVENTDATA.SHIP_FOODS:
                return data[ i ][ "Ship_Foods" ];
		    case EVENTDATA.SHIP_WATER:
                return data[ i ][ "Ship_Water" ];
		    case EVENTDATA.GUNS:
                return data[ i ][ "Guns" ];
		    case EVENTDATA.MEDICAL_KITS:
                return data[ i ][ "MedicalKits" ];
		    case EVENTDATA.REPAIR_TOOLS:
                return data[ i ][ "RepairTools" ];
		    case EVENTDATA.RADIOS:
                return data[ i ][ "Radios" ];
		    case EVENTDATA.SHIP_STATE:
                return data[ i ][ "Ship_State" ];
		    case EVENTDATA.CHARA_FOODS:
                return data[ i ][ "Chara_Foods" ];
		    case EVENTDATA.CHARA_WATER:
                return data[ i ][ "Chara_Water" ];
		    case EVENTDATA.HEALTH:
                return data[ i ][ "Health" ];
		    case EVENTDATA.LOYALTY:
                return data[ i ][ "Loyalty" ];
            case EVENTDATA.DEATH:
                return data[ i ][ "Death" ];
		    case EVENTDATA.DISEASE:
                return data[ i ][ "Disease" ];
            case EVENTDATA.ACTIVE:
                return data [ i ] [ "Active" ];
            case EVENTDATA.NEED:
                return data [ i ] [ "Need" ];
            case EVENTDATA.MAX:
                return data.Count;
		}
        return "";
	}

    public CONTENTS getContent( int i ) {
        switch ( ( string ) data[ i ][ "Article" ] ) {
            case "Island":
			    return CONTENTS.ISLAND;
		    case "Ship":
                return CONTENTS.SHIP;
            default:
                return CONTENTS.NONE;
		}
    }
}
