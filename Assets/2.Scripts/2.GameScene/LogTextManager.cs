using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LogTextManager : MonoBehaviour {
    private ShipStatus ship_status;
    private GameObject log;
    private OutsideManager outside_manager;
    private CharacterManager character_manager;
    private GameManager game_manager;
    private EventManager event_manager;

    // Use this for initialization
    void Start( ) {
        ship_status = GameObject.Find( "ShipStatus" ).gameObject.GetComponent<ShipStatus>( );
        log = GameObject.Find( "Log" ).gameObject;
        character_manager = GameObject.Find( "Characters" ).gameObject.GetComponent<CharacterManager>( );
        game_manager = GameObject.Find( "GameSystem" ).gameObject.GetComponent<GameManager>( );
        event_manager = GameObject.Find( "EventSystem" ).gameObject.GetComponent<EventManager>( );
        outside_manager = GameObject.Find( "OutsideSystem" ).gameObject.GetComponent<OutsideManager>( );
    }

    // Update is called once per frame
    void Update( ) {
        int log_page = log.GetComponent<LogManager>( ).getLogPage( );
        if ( gameObject.name == "LeftPage" ) {
            if ( log_page == 1 ) {
                gameObject.GetComponent<Text>( ).text = "Story";
            }
            if ( log_page == 2 ) {
                gameObject.GetComponent<Text>( ).text =
                  "Fuels          : " + ship_status.getResources( ).fuels.ToString( ) + "\n"
                + "Foods          : " + ship_status.getResources( ).foods.ToString( ) + "\n"
                + "Water          : " + ship_status.getResources( ).water.ToString( ) + "\n"
                + "Medical Kits   : " + ship_status.getResources( ).medical_kits.ToString( ) + "\n"
                + "Repair Tools   : " + ship_status.getResources( ).repair_tools.ToString( ) + "\n"
                + "Radios         : " + ship_status.getResources( ).radios.ToString( ) + "\n";
            }
        }
        if ( gameObject.name == "RightPage" ) {
            if ( log_page == 1 ) {
                gameObject.GetComponent<Text>( ).text = writeRightPage( );
            }
            if ( log_page == 2 ) {
                Status chara1 = character_manager.getCharacter( CHARACTER.CHARA1 );
                Status chara2 = character_manager.getCharacter( CHARACTER.CHARA2 );
                Status chara3 = character_manager.getCharacter( CHARACTER.CHARA3 );
                Status chara4 = character_manager.getCharacter( CHARACTER.CHARA4 );
                Status chara5 = character_manager.getCharacter( CHARACTER.CHARA5 );
                Status chara6 = character_manager.getCharacter( CHARACTER.CHARA6 );

                gameObject.GetComponent<Text>( ).text = writeStatus( chara1 )
                                                      + writeStatus( chara2 )
                                                      + writeStatus( chara3 )
                                                      + writeStatus( chara4 )
                                                      + writeStatus( chara5 )
                                                      + writeStatus( chara6 );
            }
        }
        
        
        if ( gameObject.name == "RightDownPage" ) {
            if ( log_page == 1 ) {
                if ( !outside_manager.isYesClicked( ) ) {
                    gameObject.GetComponent<Text>( ).text = "";
                    return;
                }
                gameObject.GetComponent<Text>( ).text = ( string )event_manager.getData( game_manager.randEvent( ), EVENTDATA.STORY );
            }
            if ( log_page == 2 ) {
                gameObject.GetComponent<Text>( ).text = "";
            }
        }
    }

    string writeRightPage( ) {
        string article = event_manager.getData( game_manager.randEvent( ), EVENTDATA.ARTICLE ).ToString( );
        switch ( article ) {
            case "Island":
                return "島が発見されました。";
            case "Ship":
                return "船が発見されました。";
            default:
                return "何も見つけませんでした。";
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
