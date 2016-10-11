using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LogTextManager : MonoBehaviour {
    private ShipStatus ship_status;
    private GameObject log;
	private CharacterManager character_manager;
    private GameManager game_manager;
    private EventManager event_manager;


    // Use this for initialization
    void Start( ) {
        ship_status = GameObject.Find( "ShipStatus" ).gameObject.GetComponent<ShipStatus>( );
        log = GameObject.Find( "Log" ).gameObject;
		character_manager = GameObject.Find( "CharacterSystem" ).gameObject.GetComponent<CharacterManager>( );
		game_manager = GameObject.Find( "GameSystem" ).gameObject.GetComponent<GameManager>( );
        event_manager = GameObject.Find( "EventSystem" ).gameObject.GetComponent<EventManager>( );
    }
	
	// Update is called once per frame
	void Update( ) {
        int log_page = log.GetComponent<LogManager>( ).getLogPage( );
        if ( gameObject.name == "LeftPage" ) {
            if ( log_page == 1 ) {
                gameObject.GetComponent<Text>( ).text = "Story";
            }
            if ( log_page == 2 ) {
				gameObject.GetComponent<Text> ().text = "Days           : " + game_manager.getDays( ).ToString( ) + "\n\n"
				+ "Fuels          : " + ship_status.getResources( ).fuels.ToString () + "\n"
				+ "Foods          : " + ship_status.getResources( ).foods.ToString () + "\n"
				+ "Water          : " + ship_status.getResources( ).water.ToString () + "\n"
				+ "Medical Kits   : " + ship_status.getResources( ).medical_kits.ToString () + "\n"
				+ "Repair Tools   : " + ship_status.getResources( ).repair_tools.ToString () + "\n"
				+ "Radios         : " + ship_status.getResources( ).radios.ToString () + "\n";
            }
        }
        if ( gameObject.name == "RightPage" ) {
            if ( log_page == 1 ) {
                gameObject.GetComponent<Text>( ).text = ( string )event_manager.getData( game_manager.randEvent( ), EVENTDATA.STORY );
            }
            if ( log_page == 2 ) {
                Status father = character_manager.getCharacter( CHARACTER.FATHER );
                Status mother = character_manager.getCharacter( CHARACTER.MOTHER );
                Status sister = character_manager.getCharacter( CHARACTER.SISTER );
                Status brother = character_manager.getCharacter( CHARACTER.BROTHER );

                gameObject.GetComponent<Text>( ).text = writeStatus( father )
                                                      + writeStatus( mother )
                                                      + writeStatus( sister )
                                                      + writeStatus( brother );
            }
        }
    }

    string writeStatus( Status character ) {
        if ( character.getStatus( ).death ) {
            return "";
        }
        string status_log;
        status_log = character.name + "  : Foods " + character.getStatus( ).foods.ToString( )
                   + " Water " + character.getStatus( ).water.ToString( ) + "\n"
                   + "            Health " + character.getStatus( ).health.ToString( )
                   + " Loyalty " + character.getStatus( ).loyalty.ToString( ) + "\n"
                   + "            Disease " + character.getStatus( ).disease.ToString( ) + "\n";
        return status_log;
    }
}
