using UnityEngine;
using System.Collections;

public class InsideManager : MonoBehaviour {
    private CHARACTER _menu;
    private ShipStatus ship_status;
    private GameObject menus;
    private GameObject inside_system;

    private GameObject inside_chara1;
    private GameObject inside_chara2;
    private GameObject inside_chara3;
    private GameObject inside_chara4;
    private GameObject inside_chara5;
    private GameObject inside_chara6;

    private Status chara1;
    private Status chara2;
    private Status chara3;
    private Status chara4;
    private Status chara5;
    private Status chara6;

    // Use this for initialization
    void Start( ) {
        menus = GameObject.Find( "InsideMenus" ).gameObject;
        ship_status = GameObject.Find( "ShipStatus" ).gameObject.GetComponent<ShipStatus>( );
        inside_system = GameObject.Find( "InsideSystem" ).gameObject;
        
        inside_chara1 = GameObject.Find( "Chara1" ).gameObject;
        inside_chara2 = GameObject.Find( "Chara2" ).gameObject;
        inside_chara3 = GameObject.Find( "Chara3" ).gameObject;
        inside_chara4 = GameObject.Find( "Chara4" ).gameObject;
        inside_chara5 = GameObject.Find( "Chara5" ).gameObject;
        inside_chara6 = GameObject.Find( "Chara6" ).gameObject;

        chara1 = inside_chara1.GetComponent<Status>( );
        chara2 = inside_chara2.GetComponent<Status>( );
        chara3 = inside_chara3.GetComponent<Status>( );
        chara4 = inside_chara4.GetComponent<Status>( );
        chara5 = inside_chara5.GetComponent<Status>( );
        chara6 = inside_chara6.GetComponent<Status>( );
    }

    // Update is called once per frame
    void Update( ) {
        inside_chara1.SetActive( isInside( chara1 ) );
        inside_chara2.SetActive( isInside( chara2 ) );
        inside_chara3.SetActive( isInside( chara3 ) );
        inside_chara4.SetActive( isInside( chara4 ) );
        inside_chara5.SetActive( isInside( chara5 ) );
        inside_chara6.SetActive( isInside( chara6 ) );
    }

    CHARACTER getMenu( ) {
        return _menu;
    }

    void setMenu( CHARACTER menu ) {
        _menu = menu;
    }

    bool isInside( Status character ) {
        if ( character.getStatus( ).place != LAYER.INSIDE ) {
            return false;
        }
        if ( character.getStatus( ).death ) {
            return false;
        }
        return true;
    }

    public void CharacterClickEvent( ) {
        Vector3 menus_pos = menus.transform.position;
        menus_pos.x = transform.position.x;
        menus.transform.position = menus_pos;

        InsideManager inside_manager = inside_system.GetComponent<InsideManager>( );
        if ( gameObject.name == "Chara1" ) {
            inside_manager.setMenu( CHARACTER.CHARA1 );
        }
        if ( gameObject.name == "Chara2" ) {
            inside_manager.setMenu( CHARACTER.CHARA2 );
        }
        if ( gameObject.name == "Chara3" ) {
            inside_manager.setMenu( CHARACTER.CHARA3 );
        }
        if ( gameObject.name == "Chara4" ) {
            inside_manager.setMenu( CHARACTER.CHARA4 );
        }
        if ( gameObject.name == "Chara5" ) {
            inside_manager.setMenu( CHARACTER.CHARA5 );
        }
        if ( gameObject.name == "Chara6" ) {
            inside_manager.setMenu( CHARACTER.CHARA6 );
        }
    }

    public void FoodsButtonEvent( ) {
        ship_status.setFoods( ship_status.getResources( ).foods - 1 );
        InsideManager inside_manager = inside_system.GetComponent<InsideManager>( );
        switch ( inside_manager.getMenu( ) ) {
            case CHARACTER.CHARA1:
                chara1.setFoods( chara1.getStatus( ).foods + 1 );
                break;
            case CHARACTER.CHARA2:
                chara2.setFoods( chara2.getStatus( ).foods + 1 );
                break;
            case CHARACTER.CHARA3:
                chara3.setFoods( chara3.getStatus( ).foods + 1 );
                break;
            case CHARACTER.CHARA4:
                chara4.setFoods( chara4.getStatus( ).foods + 1 );
                break;
            case CHARACTER.CHARA5:
                chara5.setFoods( chara5.getStatus( ).foods + 1 );
                break;
            case CHARACTER.CHARA6:
                chara6.setFoods( chara6.getStatus( ).foods + 1 );
                break;
        }
    }

    public void WaterButtonEvent( ) {
        ship_status.setWater( ship_status.getResources( ).water - 1 );
        InsideManager inside_manager = inside_system.GetComponent<InsideManager>( );
        switch ( inside_manager.getMenu( ) ) {
            case CHARACTER.CHARA1:
                chara1.setWater( chara1.getStatus( ).water + 1 );
                break;
            case CHARACTER.CHARA2:
                chara2.setWater( chara2.getStatus( ).water + 1 );
                break;
            case CHARACTER.CHARA3:
                chara3.setWater( chara3.getStatus( ).water + 1 );
                break;
            case CHARACTER.CHARA4:
                chara4.setWater( chara4.getStatus( ).water + 1 );
                break;
            case CHARACTER.CHARA5:
                chara5.setWater( chara5.getStatus( ).water + 1 );
                break;
            case CHARACTER.CHARA6:
                chara6.setWater( chara6.getStatus( ).water + 1 );
                break;
        }
    }

    public void OutsideButtonEvent( ) {
        chara1.setPlace( LAYER.INSIDE );
        chara2.setPlace( LAYER.INSIDE );
        chara3.setPlace( LAYER.INSIDE );
        chara4.setPlace( LAYER.INSIDE );
        chara5.setPlace( LAYER.INSIDE );
        chara6.setPlace( LAYER.INSIDE );

        InsideManager inside_manager = inside_system.GetComponent<InsideManager>( );
        switch ( inside_manager.getMenu( ) ) {
            case CHARACTER.CHARA1:
                chara1.setPlace( LAYER.OUTSIDE );
                break;
            case CHARACTER.CHARA2:
                chara2.setPlace( LAYER.OUTSIDE );
                break;
            case CHARACTER.CHARA3:
                chara3.setPlace( LAYER.OUTSIDE );
                break;
            case CHARACTER.CHARA4:
                chara4.setPlace( LAYER.OUTSIDE );
                break;
            case CHARACTER.CHARA5:
                chara5.setPlace( LAYER.OUTSIDE );
                break;
            case CHARACTER.CHARA6:
                chara6.setPlace( LAYER.OUTSIDE );
                break;
        }
    }

    void cure( Status character ) {
        if ( !character.getStatus( ).disease ) {
            return;
        }
        ship_status.setMedicalKits( ship_status.getResources( ).medical_kits - 1 );
        character.setDisease( false );
    }

    public void CureButtonEvent( ) {
        InsideManager inside_manager = inside_system.GetComponent<InsideManager>( );
        switch ( inside_manager.getMenu( ) ) {
            case CHARACTER.CHARA1:
                cure( chara1 );
                break;
            case CHARACTER.CHARA2:
                cure( chara2 );
                break;
            case CHARACTER.CHARA3:
                cure( chara3 );
                break;
            case CHARACTER.CHARA4:
                cure( chara4 );
                break;
            case CHARACTER.CHARA5:
                cure( chara5 );
                break;
            case CHARACTER.CHARA6:
                cure( chara6 );
                break;
        }
    }
}