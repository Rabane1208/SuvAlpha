using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InsideManager : MonoBehaviour {
	private GameObject menus;
	private GameObject character_system;
	private GameObject game_system;
	private MENUS_POS menu_pos;

	private enum MENUS_POS {
		NONE,
		FATHER,
		MOTHER,
		SISTER,
		BROTHER,
	}

	// Use this for initialization
	void Start( ) {
		menus = GameObject.Find( "InsideMenus" ).gameObject;
		character_system = GameObject.Find( "CharacterSystem" ).gameObject;
		game_system = GameObject.Find( "GameSystem" ).gameObject;

		menu_pos = MENUS_POS.NONE;
	}
	
	// Update is called once per frame
	void Update( ) {
		
	}

	public void CharacterClickEvent( ) {
		Vector3 menus_pos = menus.transform.position;
		menus_pos.x = transform.position.x;
		menus.transform.position = menus_pos;

		if ( gameObject.name == "InsideFather" ) {
			menu_pos = MENUS_POS.FATHER;
		}
		if ( gameObject.name == "InsideMother" ) {
			menu_pos = MENUS_POS.MOTHER;
		}
		if ( gameObject.name == "InsideSister" ) {
			menu_pos = MENUS_POS.SISTER;
		}
		if ( gameObject.name == "InsideBrother" ) {
			menu_pos = MENUS_POS.BROTHER;
		}
	}

	public void FoodsButtonEvent( ) {
		GameManager game = game_system.GetComponent<GameManager>( );
		game.setFoods( game.getFoods( ) - 1 );
		switch( menu_pos ) {
			case MENUS_POS.FATHER:
				FatherStatus father = character_system.GetComponent<FatherStatus>( );
				father.setFoods( father.getFoods( ) + 1 );
				break;
			case MENUS_POS.MOTHER:
				break;
			case MENUS_POS.SISTER:
				break;
			case MENUS_POS.BROTHER:
				break;
		}
	}
}
