using UnityEngine;
using System.Collections;

public class OutsideManager : MonoBehaviour {
    private GameObject outside_father;
    private GameObject outside_mother;
    private GameObject outside_sister;
    private GameObject outside_brother;

    private Status father;
    private Status mother;
    private Status sister;
    private Status brother;

    private GameObject event_button;
    private GameObject island;
    private GameObject other_ship;

    private GameManager game_manager;
    private EventManager event_manager;
    // Use this for initialization
    void Start( ) {
        event_button = GameObject.Find( "EventSelects" ).gameObject;
        island = GameObject.Find( "Island" ).gameObject;
        other_ship = GameObject.Find( "OtherShip" ).gameObject;

        outside_father = GameObject.Find( "OutsideFather" ).gameObject;
        outside_mother = GameObject.Find( "OutsideMother" ).gameObject;
        outside_sister = GameObject.Find( "OutsideSister" ).gameObject;
        outside_brother = GameObject.Find( "OutsideBrother" ).gameObject;

        father = GameObject.Find( "Father" ).gameObject.GetComponent<Status>( );
        mother = GameObject.Find( "Mother" ).gameObject.GetComponent<Status>( );
        sister = GameObject.Find( "Sister" ).gameObject.GetComponent<Status>( );
        brother = GameObject.Find( "Brother" ).gameObject.GetComponent<Status>( );

        game_manager = GameObject.Find( "GameSystem" ).gameObject.GetComponent<GameManager>( );
        event_manager = GameObject.Find( "EventSystem" ).gameObject.GetComponent<EventManager>( );
    }
	
	// Update is called once per frame
	void Update( ) {
        outside_father.SetActive( isOutside( father ) );
        outside_mother.SetActive( isOutside( mother ) );
        outside_sister.SetActive( isOutside( sister ) );
        outside_brother.SetActive( isOutside( brother ) );
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
