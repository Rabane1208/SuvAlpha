using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogTextManager : MonoBehaviour {
    private GameObject game_system;
    private GameObject log;
     
	// Use this for initialization
	void Start( ) {
        game_system = GameObject.Find( "GameSystem" ).gameObject;
        log = GameObject.Find( "Log" ).gameObject;
    }
	
	// Update is called once per frame
	void Update( ) {
        int log_page = log.GetComponent<LogManager>( ).getLogPage( );
	    if ( gameObject.name == "LeftPage" ) {
            if ( log_page == 1 ) {
                gameObject.GetComponent<Text>( ).text = "Story";
            }
            if ( log_page == 2 ) {
                gameObject.GetComponent<Text>( ).text = "Days    : " + game_system.GetComponent<GameManager>( ).getDays( ).ToString( ) + "\n\n"
                                                      + "Fuels   : " + game_system.GetComponent<GameManager>( ).getFuels( ).ToString( ) + "\n"
                                                      + "Foods   : " + game_system.GetComponent<GameManager>( ).getFoods( ).ToString( ) + "\n"
                                                      + "Bullets : " + game_system.GetComponent<GameManager>( ).getBullets( ).ToString( ) + "\n";
            }
        }
        if ( gameObject.name == "RightPage" ) {
            if ( log_page == 1 ) {
                gameObject.GetComponent<Text>( ).text = "Story";
            }
            if ( log_page == 2 ) {
                gameObject.GetComponent<Text>( ).text = "Father  : 10\n"
                                                      + "Mother  : 10\n"
                                                      + "Sister  : 10\n"
                                                      + "Brother : 10\n";
            }
        }
    }
}
