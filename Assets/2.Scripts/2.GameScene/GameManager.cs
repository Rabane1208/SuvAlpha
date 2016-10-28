using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public enum LAYER {
    INSIDE,
    OUTSIDE,
}

public class GameManager : MonoBehaviour {
    public int MAIN_EVENT_INTERVAL = 10;
    public int MAX_DAYS = 70;

    private int days;
    private float time;
    private LAYER _layer;
    private int rand_event;

    private GameObject inside_layer;
    private GameObject outside_layer;
    private OutsideManager outside_manager;
    private CharacterManager character_manager;
    private EventManager event_manager;
    private ShipStatus ship_status;
    private GameObject watch;

    void Awake( ) {
        inside_layer = GameObject.Find( "InsideLayer" ).gameObject;
        outside_layer = GameObject.Find( "OutsideLayer" ).gameObject;
        outside_manager = GameObject.Find( "OutsideSystem" ).gameObject.GetComponent<OutsideManager>( );
        character_manager = GameObject.Find( "Characters" ).gameObject.GetComponent<CharacterManager>( );
        event_manager = GameObject.Find( "EventSystem" ).gameObject.GetComponent<EventManager>( );
        ship_status = GameObject.Find( "ShipStatus" ).gameObject.GetComponent<ShipStatus>( );
        rand_event = Random.Range( 0, ( int )event_manager.getMaxData( ) );

        watch = GameObject.Find( "Watch" ).gameObject;

        init( );
    }

    void Update( ) {
        updateWatch( );
        updateLayer( );
        changeScene( );
    }

    void init( ) {
        if ( PlayerPrefs.GetInt( "Days" ) == 0 ) {
            character_manager.setNewGame( );
            ship_status.setNewShip( );
            PlayerPrefs.SetInt( "Days", 1 );
            PlayerPrefs.Save( );
        }
        days = PlayerPrefs.GetInt( "Days" );
        time = PlayerPrefs.GetFloat( "Time" );
        _layer = LAYER.OUTSIDE;
    }

    void updateWatch( ) {
        time += Time.deltaTime;
        int hour = ( int )time / 60;
        int mint = ( int )time % 60;
        watch.GetComponent<Text>( ).text = days.ToString( ) + " Days  " 
            + hour.ToString( "00" ) + " : " + mint.ToString( "00" ) 
            + "  " + PlayerPrefs.GetInt( "Select" ).ToString( );
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
            character_manager.setNewGame( );
            ship_status.setNewShip( );
            PlayerPrefs.SetInt( "GameOver", 1 );
            PlayerPrefs.SetInt( "LoadGame", 0 );
            PlayerPrefs.Save( );
            SceneManager.LoadScene( "GameOverScene" );
        }
        if ( days >= MAX_DAYS ) {
            SceneManager.LoadScene( "EndingScene" );
        }
        if ( days % MAIN_EVENT_INTERVAL == 0 ) {
            PlayerPrefs.SetInt( "EventNumber", days / MAIN_EVENT_INTERVAL - 1 );
            NextDay( );
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
        dataSave( );
        rand_event = Random.Range( 0, ( int )event_manager.getMaxData( ) );
        outside_manager.yesClieked( false );
    }
    
    public void dataSave( ) {
        ship_status.saveData( );
        PlayerPrefs.SetInt( "Days", days );
        PlayerPrefs.SetFloat( "Time", time );
        PlayerPrefs.Save( );
    }
	
    public LAYER getLayer( ) { return _layer; }
    public void setLayer( LAYER layer ) { _layer = layer; }
    public int getDays( ) { return days; }
}
