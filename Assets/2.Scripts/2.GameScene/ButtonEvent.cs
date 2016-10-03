using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour {
    private GameObject log;
    private GameObject game_system;
    private GameObject inside_layer;
    private GameObject outside_layer;
    private GameObject layer_button_text;
    //private LAYER layer;

    void Awake( ) {
        log = GameObject.Find( "Log" ).gameObject;
        game_system = GameObject.Find( "GameSystem" ).gameObject;
        inside_layer = GameObject.Find( "InsideLayer" ).gameObject;
        outside_layer = GameObject.Find( "OutsideLayer" ).gameObject;
        layer_button_text = GameObject.Find( "LayerChangeText" ).gameObject;
    }

    public void NextDayButton( ) {
        if ( log.GetComponent<LogManager>( ).isLogOpened( ) ) {
            return;
        }
        game_system.GetComponent<GameManager>( ).NextDay( );
        log.GetComponent<LogManager>( ).setLogOpen( true );
    }

    public void ChangeLayer( ) {
        LAYER layer = game_system.GetComponent<GameManager>( ).getLayer( );
        if ( layer == LAYER.OUTSIDE ) {
            layer_button_text.GetComponent<Text>( ).text = "Outside";
            inside_layer.SetActive( true );
            outside_layer.SetActive( false );
            game_system.GetComponent<GameManager>( ).setLayer( LAYER.INSIDE );
        } else {
            layer_button_text.GetComponent<Text>( ).text = "Inside";
            inside_layer.SetActive( false );
            outside_layer.SetActive( true );
            game_system.GetComponent<GameManager>( ).setLayer( LAYER.OUTSIDE );
        }
    }
}
