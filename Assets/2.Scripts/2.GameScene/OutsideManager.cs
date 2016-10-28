using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutsideManager : MonoBehaviour { 
    private bool is_yes;

    public Sprite None;
    public Sprite Chara1Image;
    public Sprite Chara2Image;
    public Sprite Chara3Image;
    public Sprite Chara4Image;
    public Sprite Chara5Image;
    public Sprite Chara6Image;

    public Sprite Island;
    public Sprite Ship;

    private Status chara1;
    private Status chara2;
    private Status chara3;
    private Status chara4;
    private Status chara5;
    private Status chara6;

    private Status selected;

    private GameObject event_button;
    private GameObject event_object;
    private GameObject outside_chara;

    private LogManager log_manager;
    private GameManager game_manager;
    private EventManager event_manager;
    private ShipStatus ship_status;
    // Use this for initialization
    void Awake( ) {
        event_button = GameObject.Find( "EventSelects" ).gameObject;
        event_object = GameObject.Find( "EventObject" ).gameObject;

        outside_chara = GameObject.Find( "CharacterImage" ).gameObject;
        outside_chara.GetComponent<SpriteRenderer>( ).sprite = None;

        chara1 = GameObject.Find( "Chara1" ).gameObject.GetComponent<Status>( );
        chara2 = GameObject.Find( "Chara2" ).gameObject.GetComponent<Status>( );
        chara3 = GameObject.Find( "Chara3" ).gameObject.GetComponent<Status>( );
        chara4 = GameObject.Find( "Chara4" ).gameObject.GetComponent<Status>( );
        chara5 = GameObject.Find( "Chara5" ).gameObject.GetComponent<Status>( );
        chara6 = GameObject.Find( "Chara6" ).gameObject.GetComponent<Status>( );

        game_manager = GameObject.Find( "GameSystem" ).gameObject.GetComponent<GameManager>( );
        event_manager = GameObject.Find( "EventSystem" ).gameObject.GetComponent<EventManager>( );
        ship_status = GameObject.Find( "ShipStatus" ).gameObject.GetComponent<ShipStatus>( );
        log_manager = GameObject.Find( "Log" ).gameObject.GetComponent<LogManager>( );
        event_button.SetActive( false );
        is_yes = false;
    }
	
	// Update is called once per frame
	void Update( ) {
        selectedCharacter( );
        drawObject( event_manager.getContent( game_manager.randEvent( ) ) );
    }

    void selectedCharacter( ) {
        if ( isOutside( chara1 ) ) {
            selected = chara1;
            outside_chara.GetComponent<SpriteRenderer>( ).sprite = Chara1Image;
        }
        if ( isOutside( chara2 ) ) {
            selected = chara2;
            outside_chara.GetComponent<SpriteRenderer>( ).sprite = Chara2Image;
        }
        if ( isOutside( chara3 ) ) {
            selected = chara3;
            outside_chara.GetComponent<SpriteRenderer>( ).sprite = Chara3Image;
        }
        if ( isOutside( chara4 ) ) {
            selected = chara4;
            outside_chara.GetComponent<SpriteRenderer>( ).sprite = Chara4Image;
        }
        if ( isOutside( chara5 ) ) {
            selected = chara5;
            outside_chara.GetComponent<SpriteRenderer>( ).sprite = Chara5Image;
        }
        if ( isOutside( chara6 ) ) {
            selected = chara6;
            outside_chara.GetComponent<SpriteRenderer>( ).sprite = Chara6Image;
        }
    }

    bool isOutside( Status character ) {
        if ( character.getStatus( ).place != LAYER.OUTSIDE ) {
            return false;
        }
        if ( character.getStatus( ).death ) {
            return false;
        }
        return true;
    }

    void drawObject( CONTENTS contents ) {
        switch ( contents ) {
            case CONTENTS.ISLAND:
                event_object.GetComponent<Image>( ).sprite = Island;
                break;
            case CONTENTS.SHIP:
                event_object.GetComponent<Image>( ).sprite = Ship;
                break;
        }
    }
    public bool isYesClicked( ) {
        return is_yes;
    }

    public void yesClieked( bool tigger ) {
        is_yes = tigger;
    }

    public void drawEventSelectButton( ) {
        if ( event_button.activeSelf ) {
            event_button.SetActive( false );
        } else {
            event_button.SetActive( true );
        }
    }

    public void EventYes( ) {
        if ( selected == null ) {
            return;
        }
        int fuels = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.FUELS );
        int ship_foods = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.SHIP_FOODS );
        int ship_water = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.SHIP_WATER );
        int guns = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.GUNS );
        int medical_kits = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.MEDICAL_KITS );
        int repair_tools = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.REPAIR_TOOLS );
        int radios = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.RADIOS );
        int ship_break = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.SHIP_STATE );
        int chara_foods = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.CHARA_FOODS );
        int chara_water = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.CHARA_WATER );
        int health = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.HEALTH );
        int loyalty = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.LOYALTY );
        int death = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.DEATH );
        int disease = ( int )event_manager.getData( game_manager.randEvent( ), EVENTDATA.DISEASE );

        ship_status.setFuels( ship_status.getResources( ).fuels + fuels );
        ship_status.setFoods( ship_status.getResources( ).foods + ship_foods );
        ship_status.setWater( ship_status.getResources( ).water + ship_water );
        ship_status.setGuns( ship_status.getResources( ).guns + guns );
        ship_status.setMedicalKits( ship_status.getResources( ).medical_kits + medical_kits );
        ship_status.setRepairTools( ship_status.getResources( ).repair_tools + repair_tools );
        ship_status.setRadios( ship_status.getResources( ).radios + radios );
        ship_status.setShipBreak( ship_break );
        selected.setFoods( selected.getStatus( ).foods + chara_foods );
        selected.setWater( selected.getStatus( ).water + chara_water );
        selected.setHealth( selected.getStatus( ).health + health );
        selected.setLoyalty( selected.getStatus( ).loyalty + loyalty );
        selected.setDeath( death );
        selected.setDisease( disease );

        is_yes = true;
        event_button.SetActive( false );
        log_manager.setLogOpen( true );
    }

    public void EventNo( ) {
        event_button.SetActive( false );
    }
}
