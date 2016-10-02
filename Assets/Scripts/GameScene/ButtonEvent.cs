using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour {
    private GameObject log;
    private Vector3 log_pos;

    void Awake( ) {
        log = GameObject.Find( "Log" ).gameObject;
    }

    public void CloseLog( ) {
        log.GetComponent<LogManager>( ).setLogOpen( false );
    }

    public void NextDay( ) {
        if ( log.GetComponent<LogManager>( ).isLogOpened( ) ) {
            return;
        }
        SceneManager.LoadScene( "CreditScene" );
    }
}
