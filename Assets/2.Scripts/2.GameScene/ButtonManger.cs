using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManger : MonoBehaviour {
    private GameObject log;
    private GameObject game_system;
    private GameObject layer_button_text;

    void Awake( ) {
        log = GameObject.Find( "Log" ).gameObject;
        game_system = GameObject.Find( "GameSystem" ).gameObject;
        layer_button_text = GameObject.Find( "LayerChangeText" ).gameObject;
    }

    public void NextDayButton( ) {
        if ( log.GetComponent<LogManager>( ).isLogOpened( ) ) {
            return;
        }
        game_system.GetComponent<GameManager>( ).NextDay( );
        log.GetComponent<LogManager>( ).setLogOpen( true );
        log.GetComponent<LogManager>( ).setLogPage( 1 );
    }

    public void ChangeLayerButton( ) {
        LAYER layer = game_system.GetComponent<GameManager>( ).getLayer( );
        if ( layer == LAYER.OUTSIDE ) {
            layer_button_text.GetComponent<Text>( ).text = "Outside";
            game_system.GetComponent<GameManager>( ).setLayer( LAYER.INSIDE );
        } else {
            layer_button_text.GetComponent<Text>( ).text = "Inside";
            game_system.GetComponent<GameManager>( ).setLayer( LAYER.OUTSIDE );
        }
    }
}
