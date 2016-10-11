using UnityEngine;
using System.Collections;

public class InsideManager : MonoBehaviour {
    private CHARACTER _menu;
    private ShipStatus ship_status;
    private GameObject menus;
    private GameObject inside_system;

    private GameObject inside_father;
    private GameObject inside_mother;
    private GameObject inside_sister;
    private GameObject inside_brother;

    private Status father;
    private Status mother;
    private Status sister;
    private Status brother;

    // Use this for initialization
    void Start( ) {
        menus = GameObject.Find( "InsideMenus" ).gameObject;
        ship_status = GameObject.Find( "ShipStatus" ).gameObject.GetComponent<ShipStatus>( );
        inside_system = GameObject.Find( "InsideSystem" ).gameObject;

        inside_father = GameObject.Find( "InsideFather" ).gameObject;
        inside_mother = GameObject.Find( "InsideMother" ).gameObject;
        inside_sister = GameObject.Find( "InsideSister" ).gameObject;
        inside_brother = GameObject.Find( "InsideBrother" ).gameObject;

        father = GameObject.Find( "Father" ).gameObject.GetComponent<Status>( );
        mother = GameObject.Find( "Mother" ).gameObject.GetComponent<Status>( );
        sister = GameObject.Find( "Sister" ).gameObject.GetComponent<Status>( );
        brother = GameObject.Find( "Brother" ).gameObject.GetComponent<Status>( );
    }

    // Update is called once per frame
    void Update( ) {
        inside_father.SetActive( isInside( father ) );
        inside_mother.SetActive( isInside( mother ) );
        inside_sister.SetActive( isInside( sister ) );
        inside_brother.SetActive( isInside( brother ) );
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
        if ( gameObject.name == "InsideFather" ) {
            inside_manager.setMenu( CHARACTER.FATHER );
        }
        if ( gameObject.name == "InsideMother" ) {
            inside_manager.setMenu( CHARACTER.MOTHER );
        }
        if ( gameObject.name == "InsideSister" ) {
            inside_manager.setMenu( CHARACTER.SISTER );
        }
        if ( gameObject.name == "InsideBrother" ) {
            inside_manager.setMenu( CHARACTER.BROTHER );
        }
    }

    public void FoodsButtonEvent( ) {
        ship_status.setFoods( ship_status.getResources( ).foods - 1 );
        InsideManager inside_manager = inside_system.GetComponent<InsideManager>( );
        switch ( inside_manager.getMenu( ) ) {
            case CHARACTER.FATHER:
                father.setFoods( father.getStatus( ).foods + 1 );
                break;
            case CHARACTER.MOTHER:
                mother.setFoods( mother.getStatus( ).foods + 1 );
                break;
            case CHARACTER.SISTER:
                sister.setFoods( sister.getStatus( ).foods + 1 );
                break;
            case CHARACTER.BROTHER:
                brother.setFoods( brother.getStatus( ).foods + 1 );
                break;
        }
    }

    public void WaterButtonEvent( ) {
        ship_status.setWater( ship_status.getResources( ).water - 1 );
        InsideManager inside_manager = inside_system.GetComponent<InsideManager>( );
        switch ( inside_manager.getMenu( ) ) {
            case CHARACTER.FATHER:
                father.setWater( father.getStatus( ).water + 1 );
                break;
            case CHARACTER.MOTHER:
                mother.setWater( mother.getStatus( ).water + 1 );
                break;
            case CHARACTER.SISTER:
                sister.setWater( sister.getStatus( ).water + 1 );
                break;
            case CHARACTER.BROTHER:
                brother.setWater( brother.getStatus( ).water + 1 );
                break;
        }
    }

    public void OutsideButtonEvent( ) {
        father.setPlace( LAYER.INSIDE );
        mother.setPlace( LAYER.INSIDE );
        sister.setPlace( LAYER.INSIDE );
        brother.setPlace( LAYER.INSIDE );

        InsideManager inside_manager = inside_system.GetComponent<InsideManager>( );
        switch ( inside_manager.getMenu( ) ) {
            case CHARACTER.FATHER:
                father.setPlace( LAYER.OUTSIDE );
                break;
            case CHARACTER.MOTHER:
                mother.setPlace( LAYER.OUTSIDE );
                break;
            case CHARACTER.SISTER:
                sister.setPlace( LAYER.OUTSIDE );
                break;
            case CHARACTER.BROTHER:
                brother.setPlace( LAYER.OUTSIDE );
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
            case CHARACTER.FATHER:
                cure( father );
                break;
            case CHARACTER.MOTHER:
                cure( mother );
                break;
            case CHARACTER.SISTER:
                cure( sister );
                break;
            case CHARACTER.BROTHER:
                cure( brother );
                break;
        }
    }
}