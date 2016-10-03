using UnityEngine;
using System.Collections;

public struct STATUS {
    public string tag;
    public LAYER place;
    public int foods;
    public int water;
    public int health;
    public bool death;
    public bool disease;
}

public class CharacterManager : MonoBehaviour {
    public STATUS father;
    public STATUS mother;
    public STATUS sister;
    public STATUS brother;

    void Start( ) {
        init( father  , "FATHER"  );
        init( mother  , "MOTHER"  );
        init( sister  , "SISTER"  );
        init( brother , "BROTHER" );
    }
	
	void Update( ) {
	
	}

    void init( STATUS status, string character ) {
        status.tag       = character;
        status.place     = LAYER.INSIDE;
        status.foods     = 10;
        status.water     = 10;
        status.health    = 10;
        status.death     = false;
        status.disease   = false;
    }

    public STATUS getStatus( string character ) {
        if ( character == "FATHER" ) {
            return father;
        }
        if ( character == "MOTHER" ) {
            return mother;
        }
        if ( character == "SISTER" ) {
            return mother;
        }
        if ( character == "BROTHER" ) {
            return mother;
        }
        return father;
    }
}
