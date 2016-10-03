using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SupplyUIManager : MonoBehaviour {
    private GameObject game_system;
     
	// Use this for initialization
	void Start () {
        game_system = GameObject.Find( "GameSystem" ).gameObject; 
    }
	
	// Update is called once per frame
	void Update () {
	    if ( gameObject.name == "LeftPage" ) {
            gameObject.GetComponent<Text>( ).text = "Oils : " + game_system.GetComponent<GameManager>( ).getOils( ).ToString( ) + "\n"
                                                  + "Foods : " + game_system.GetComponent<GameManager>( ).getFoods( ).ToString( ) + "\n"
                                                  + "Bullets : " + game_system.GetComponent<GameManager>( ).getBullets( ).ToString( ) + "\n";
        }
    }
}
