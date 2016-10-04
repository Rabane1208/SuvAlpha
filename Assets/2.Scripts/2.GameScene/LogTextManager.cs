using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogTextManager : MonoBehaviour {
    private GameObject game_system;
    private GameObject log;
	private GameObject character_system;

	// Use this for initialization
	void Start( ) {
        game_system = GameObject.Find( "GameSystem" ).gameObject;
        log = GameObject.Find( "Log" ).gameObject;
		character_system = GameObject.Find( "CharacterSystem" ).gameObject;
    }
	
	// Update is called once per frame
	void Update( ) {
        int log_page = log.GetComponent<LogManager>( ).getLogPage( );
		GameManager game_manager = game_system.GetComponent<GameManager>( );
		FatherStatus father = character_system.GetComponent<FatherStatus>( );
		MotherStatus mother = character_system.GetComponent<MotherStatus>( );
		SisterStatus sister = character_system.GetComponent<SisterStatus>( );
		BrotherStatus brother = character_system.GetComponent<BrotherStatus>( );

	    if ( gameObject.name == "LeftPage" ) {
            if ( log_page == 1 ) {
                gameObject.GetComponent<Text>( ).text = "Story";
            }
            if ( log_page == 2 ) {
				gameObject.GetComponent<Text>( ).text = "Days           : " + game_manager.getDays( ).ToString( )        + "\n\n"
													  + "Fuels          : " + game_manager.getFuels( ).ToString( )       + "\n"
                                                      + "Foods          : " + game_manager.getFoods( ).ToString( )       + "\n"
                                                      + "Water          : " + game_manager.getWater( ).ToString( )       + "\n"
                                                      + "Medical Kits   : " + game_manager.getMedicalKits( ).ToString( ) + "\n"
                                                      + "Radios         : " + game_manager.getRadios( ).ToString( )      + "\n"
                                                      + "Repair Tools   : " + game_manager.getRepairTools( ).ToString( ) + "\n";
            }
        }
        if ( gameObject.name == "RightPage" ) {
            if ( log_page == 1 ) {
                gameObject.GetComponent<Text>( ).text = "Story";
            }
            if ( log_page == 2 ) {
				gameObject.GetComponent<Text>( ).text = "Father  : Foods " + father.getFoods( ).ToString( )
													  + " Water " + father.getWater( ).ToString( ) + "\n"
													  + "Mother  : Foods " + mother.getFoods( ).ToString( )
													  + " Water " + father.getWater( ).ToString( ) + "\n"
													  + "Sister  : Foods " + sister.getFoods( ).ToString( )
													  + " Water " + father.getWater( ).ToString( ) + "\n"
													  + "Brother  : Foods " + brother.getFoods( ).ToString( )
													  + " Water " + father.getWater( ).ToString( ) + "\n";
            }
        }
    }
}
