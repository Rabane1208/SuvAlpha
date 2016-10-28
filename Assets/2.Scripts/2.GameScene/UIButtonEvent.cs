using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonEvent : MonoBehaviour {
    private GameObject log;
    private GameObject game_system;
    private GameObject layer_button_text;

    void Awake( ) {
        log = GameObject.Find( "Log" ).gameObject;
        game_system = GameObject.Find( "GameSystem" ).gameObject;
    }

    public void NextDayButton( ) {
        if ( log.GetComponent<LogManager>( ).isLogOpened( ) ) {
            return;
        }
        game_system.GetComponent<GameManager>( ).NextDay( );
        log.GetComponent<LogManager>( ).setLogOpen( true );
        log.GetComponent<LogManager>( ).setLogPage( 1 );
    }

    public void ChangeLayer( ) {
        LAYER layer = game_system.GetComponent<GameManager>( ).getLayer( );
        if ( layer == LAYER.OUTSIDE ) {
            game_system.GetComponent<GameManager>( ).setLayer( LAYER.INSIDE );
        } else {
            game_system.GetComponent<GameManager>( ).setLayer( LAYER.OUTSIDE );
        }
    }

    public void OpenLog( ) {
        if ( log.GetComponent<LogManager>( ).isLogOpened( ) ) {
            log.GetComponent<LogManager>( ).setLogOpen( false );
        }
        if ( !log.GetComponent<LogManager>( ).isLogOpened( ) ) {
            log.GetComponent<LogManager>( ).setLogOpen( true );
        }
    }

    public void GoToOption( ) {
        SceneManager.LoadScene( "OptionScene" );
    }
}
