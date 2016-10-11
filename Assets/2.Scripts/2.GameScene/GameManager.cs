using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum LAYER {
    INSIDE,
    OUTSIDE,
}

public class GameManager : MonoBehaviour {
    public int MAIN_EVENT_INTERVAL = 5;

    private int days;
    private LAYER _layer;
    private int rand_event;

    private GameObject inside_layer;
    private GameObject outside_layer;
    private CharacterManager character_manager;
    private EventManager event_manager;
    private ShipStatus ship_status;

    void Start( ) {
        init( );

        inside_layer = GameObject.Find( "InsideLayer" ).gameObject;
        outside_layer = GameObject.Find( "OutsideLayer" ).gameObject;
        character_manager = GameObject.Find( "CharacterSystem" ).gameObject.GetComponent<CharacterManager>( );
        event_manager = GameObject.Find( "EventSystem" ).gameObject.GetComponent<EventManager>( );
        ship_status = GameObject.Find( "ShipStatus" ).gameObject.GetComponent<ShipStatus>( );
        rand_event = Random.Range( 0, ( int )event_manager.getMaxData( ) );
    }

    void Update( ) {
        updateLayer( );
        changeScene( );
    }

    void init( ) {
        if ( PlayerPrefs.GetInt( "Days" ) == 0 ) {
            PlayerPrefs.SetInt( "Days", 1 );
        }
        days = PlayerPrefs.GetInt("Days");

        _layer = LAYER.OUTSIDE;
    }

    public int randEvent( ) {
        return rand_event;
    }

    void updateLayer( ) {
		Vector3 inside_layer_pos = inside_layer.transform.position;
        switch ( _layer ) {
            case LAYER.INSIDE:
				inside_layer_pos.x = 0;
				inside_layer.transform.position = inside_layer_pos;
                inside_layer.SetActive( true );
                outside_layer.SetActive( false );
                break;
            case LAYER.OUTSIDE:
                inside_layer.SetActive( false );
                outside_layer.SetActive( true );
                break;
        }
    }

    void changeScene( ) {
        if ( gameOver( ) ) {
            PlayerPrefs.DeleteAll( );
            SceneManager.LoadScene( "GameOverScene" );
        }
        if ( days % MAIN_EVENT_INTERVAL == 0 ) {
            PlayerPrefs.SetInt( "EventNumber", days / MAIN_EVENT_INTERVAL );
            NextDay( );
            PlayerPrefs.SetInt( "Days", days );
            PlayerPrefs.Save( );
            SceneManager.LoadScene( "MovieScene" );
        }
    }

    bool gameOver( ) {
        if ( character_manager.allDeath( ) ) {
            return true;
        }
        if ( ship_status.getResources( ).fuels <= -1 ) {
            return true;
        }
		if ( ship_status.getResources( ).ship_break && ship_status.getResources( ).repair_tools <= 0 ) {
            return true;
        }
        return false;
    }

    public void NextDay( ) {
        days++;
        ship_status.setFuels( ship_status.getResources( ).fuels - 1 );
        character_manager.nextDay( );
        rand_event = Random.Range( 0, ( int )event_manager.getMaxData( ) );
    }
	
    public LAYER getLayer( ) { return _layer; }
    public void setLayer( LAYER layer ) { _layer = layer; }
    public int getDays( ) { return days; }
    
}
