using UnityEngine;
using System.Collections;

public class OutsideManager : MonoBehaviour {
    private GameObject outside_chara1;
    private GameObject outside_chara2;
    private GameObject outside_chara3;
    private GameObject outside_chara4;
    private GameObject outside_chara5;
    private GameObject outside_chara6;

    private Status chara1;
    private Status chara2;
    private Status chara3;
    private Status chara4;
    private Status chara5;
    private Status chara6;

    private GameObject event_button;
    private GameObject island;
    private GameObject other_ship;

    private GameManager game_manager;
    private EventManager event_manager;
    // Use this for initialization
    void Awake( ) {
        event_button = GameObject.Find( "EventSelects" ).gameObject;
        island = GameObject.Find( "Island" ).gameObject;
        other_ship = GameObject.Find( "OtherShip" ).gameObject;

        outside_chara1 = GameObject.Find( "OutsideChara1" ).gameObject;
        outside_chara2 = GameObject.Find( "OutsideChara2" ).gameObject;
        outside_chara3 = GameObject.Find( "OutsideChara3" ).gameObject;
        outside_chara4 = GameObject.Find( "OutsideChara4" ).gameObject;
        outside_chara5 = GameObject.Find( "OutsideChara5" ).gameObject;
        outside_chara6 = GameObject.Find( "OutsideChara6" ).gameObject;

        chara1 = GameObject.Find( "Chara1" ).gameObject.GetComponent<Status>( );
        chara2 = GameObject.Find( "Chara2" ).gameObject.GetComponent<Status>( );
        chara3 = GameObject.Find( "Chara3" ).gameObject.GetComponent<Status>( );
        chara4 = GameObject.Find( "Chara4" ).gameObject.GetComponent<Status>( );
        chara5 = GameObject.Find( "Chara5" ).gameObject.GetComponent<Status>( );
        chara6 = GameObject.Find( "Chara6" ).gameObject.GetComponent<Status>( );

        game_manager = GameObject.Find( "GameSystem" ).gameObject.GetComponent<GameManager>( );
        event_manager = GameObject.Find( "EventSystem" ).gameObject.GetComponent<EventManager>( );

        event_button.SetActive( false );
    }
	
	// Update is called once per frame
	void Update( ) {
        outside_chara1.SetActive( isOutside( chara1 ) );
        outside_chara2.SetActive( isOutside( chara2 ) );
        outside_chara3.SetActive( isOutside( chara3 ) );
        outside_chara4.SetActive( isOutside( chara4 ) );
        outside_chara5.SetActive( isOutside( chara5 ) );
        outside_chara6.SetActive( isOutside( chara6 ) );
        drawObject( event_manager.getContent( game_manager.randEvent( ) ) );
    }

    bool isOutside( Status character ) {
        if ( character.getStatus( ).place != LAYER.OUTSIDE ) {
            return false;
        }
        if ( character.getStatus( ).death ) {
            return false;
        }
        return true;
    }

    void drawObject( CONTENTS contents ) {
        switch ( contents ) {
            case CONTENTS.ISLAND:
                island.SetActive( true );
                other_ship.SetActive( false );
                break;
            case CONTENTS.SHIP:
                other_ship.SetActive( true );
                island.SetActive( false );
                break;
        }
    }

    public void drawEventSelectButton( ) {
        if ( event_button.activeSelf ) {
            event_button.SetActive( false );
        } else {
            event_button.SetActive( true );
        }
    }
}
