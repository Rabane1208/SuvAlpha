using UnityEngine;
using System.Collections;

public struct STATUS {
    public LAYER place;
    public int foods;
    public int water;
    public int health;
    public int loyalty;
    public bool death;
    public bool disease;
}

public enum CHARACTER {
    NONE,
    CHARA1,
    CHARA2,
    CHARA3,
    CHARA4,
    CHARA5,
    CHARA6,
    MAX,
}

public class CharacterManager : MonoBehaviour {
    Status chara1;
    Status chara2;
    Status chara3;
    Status chara4;
    Status chara5;
    Status chara6;

    //Came to next day, character decrease foods and wather. 
    public int DECREASE_FOODS_HEALTHY;
    public int DECREASE_WATER_HEALTHY;

    //If character's state is hunger, character decrease health. 
    public int DECREASE_HEALTH_HUNGER;
    
    //If character is sick, get more decrease value. 
    public int DECREASE_WATER_SICK;
    public int DECREASE_HEALTH_SICK;

    //If character is healthy and no hunger, character increase health.
    private int FULL_HEALTH;
    public int INCREASE_HEALTH;

    //If character have foods and water more than this value, increase loyalty to next day.
    public int SATISFACTION_VALUE;
    public int INCREASE_LOYALTY;

    //If character have foods and water less than this value, increase loyalty to next day.
    public int DISSATISFACTION_VALUE;
    public int DECREASE_LOYALTY_SICK;
    public int DECREASE_LOYALTY_DISSATISFACTION;

    void Awake( ) {
        FULL_HEALTH = 10;

		chara1 = GameObject.Find( "Chara1" ).GetComponent<Status>( );
		chara2 = GameObject.Find( "Chara2" ).GetComponent<Status>( );
		chara3 = GameObject.Find( "Chara3" ).GetComponent<Status>( );
		chara4 = GameObject.Find( "Chara4" ).GetComponent<Status>( );
		chara5 = GameObject.Find( "Chara5" ).GetComponent<Status>( );
		chara6 = GameObject.Find( "Chara6" ).GetComponent<Status>( );
    }
	
	void Update( ) {
        AliveCharacters( );
        isAllGood( chara6 );
    }

    void isAllGood( Status character ) {
        if ( character.getStatus( ).death ) {
            character.setFace( STATE.DEATH );
            return;
        }
        if ( character.getStatus( ).foods <= 0 ) {
            character.setFace( STATE.HUNGRY );
            return;
        }
        if ( character.getStatus( ).water <= 0 ) {
            character.setFace( STATE.THIRSTY );
            return;
        }
        if ( character.getStatus( ).disease ) {
            character.setFace( STATE.SICK );
            return;
        }
        if ( character.getStatus( ).loyalty <= 0 ) {
            character.setFace( STATE.DEFIANCE );
            return;
        }
        chara6.setFace( STATE.NORMAL );
    }

    public void setNewGame( ) {
        chara1.setNew( );
        chara2.setNew( );
        chara3.setNew( );
        chara4.setNew( );
        chara5.setNew( );
        chara6.setNew( );
    }

    public void AliveCharacters( ) {
        if ( PlayerPrefs.GetInt( "Chara1Alive" ) == 0 ) {
            chara1.setDeath( true );
        }
        if ( PlayerPrefs.GetInt( "Chara2Alive" ) == 0 ) {
            chara2.setDeath( true );
        }
        if ( PlayerPrefs.GetInt( "Chara3Alive" ) == 0 ) {
            chara3.setDeath( true );
        }
        if ( PlayerPrefs.GetInt( "Chara4Alive" ) == 0 ) {
            chara4.setDeath( true );
        }
        if ( PlayerPrefs.GetInt( "Chara5Alive" ) == 0 ) {
            chara5.setDeath( true );
        }
        if ( PlayerPrefs.GetInt( "Chara6Alive" ) == 0 ) {
            chara6.setDeath( true );
        }
    }

    void death( Status character ) {
        if ( character.getStatus( ).health <= 0 ) {
            character.setDeath( true );
        }
    }

    void decreaseFoods( Status character ) {
        character.setFoods( character.getStatus( ).foods - DECREASE_FOODS_HEALTHY );
        if ( character.getStatus( ).foods <= 0 ) {
            character.setFoods( 0 );
            return;
        }
    }

    void decreaseWater( Status character ) {
        character.setWater( character.getStatus( ).water - DECREASE_WATER_HEALTHY );
        if ( character.getStatus( ).disease ) {
            character.setWater( character.getStatus( ).water - DECREASE_WATER_SICK );
        }
        if ( character.getStatus( ).water <= 0 ) {
            character.setWater( 0 );
            return;
        }
    }

    void variationHealth( Status character ) { 
        if ( character.getStatus( ).disease ) {
            character.setHealth( character.getStatus( ).health - DECREASE_HEALTH_SICK );
        }
        if ( !isHunger( character ) ) {
            if ( character.getStatus( ).health >= FULL_HEALTH ) {
                return;
            }
            character.setHealth( character.getStatus( ).health + INCREASE_HEALTH );
        } else {
            character.setHealth( character.getStatus( ).health - DECREASE_HEALTH_HUNGER );
        }
    }

    void variationLoyality( Status character ) {
        if ( character.getStatus( ).foods >= SATISFACTION_VALUE &&
             character.getStatus( ).water >= SATISFACTION_VALUE ) {
            character.setLoyalty( character.getStatus( ).loyalty + INCREASE_LOYALTY );
        }
        if ( character.getStatus( ).foods <= DISSATISFACTION_VALUE &&
             character.getStatus( ).water <= DISSATISFACTION_VALUE ) {
            character.setLoyalty( character.getStatus( ).loyalty - DECREASE_LOYALTY_DISSATISFACTION );
        }
        if ( character.getStatus( ).disease ) {
            character.setLoyalty( character.getStatus( ).loyalty - DECREASE_LOYALTY_SICK );
        }
        if ( character.getStatus( ).loyalty <= 0 ) {
            character.setLoyalty( 0 );
            return;
        }
    }

    bool isHunger( Status character ) {
        if ( character.getStatus( ).foods <= 0 ) {
            return true;
        }
        if ( character.getStatus( ).water <= 0 ) {
            return true;
        }
        return false;
    }

    void haveDisease( Status character ) {
        int isSick = 0;
        if ( character.getStatus( ).foods <= 0 &&
             character.getStatus( ).water <= 0 ) {
            isSick = Random.Range( 0, 1 );
        }
        if ( isSick == 1 ) {
            character.setDisease( true );
        }
    }

    public void nextDay( ) {
        decreaseFoods( chara1 );
        decreaseFoods( chara2 );
        decreaseFoods( chara3 );
        decreaseFoods( chara4 );
        decreaseFoods( chara5 );
        decreaseFoods( chara6 );

        decreaseWater( chara1 );
        decreaseWater( chara2 );
        decreaseWater( chara3 );
        decreaseWater( chara4 );
        decreaseWater( chara5 );
        decreaseWater( chara6 );

        variationHealth( chara1 );
        variationHealth( chara2 );
        variationHealth( chara3 );
        variationHealth( chara4 );
        variationHealth( chara5 );
        variationHealth( chara6 );

        variationLoyality( chara1 );
        variationLoyality( chara2 );
        variationLoyality( chara3 );
        variationLoyality( chara4 );
        variationLoyality( chara5 );
        variationLoyality( chara6 );

        death( chara1 );
        death( chara2 );
        death( chara3 );
        death( chara4 );
        death( chara5 );
        death( chara6 );

        haveDisease( chara1 );
        haveDisease( chara2 );
        haveDisease( chara3 );
        haveDisease( chara4 );
        haveDisease( chara5 );
        haveDisease( chara6 );

        chara1.saveData( );
        chara2.saveData( );
        chara3.saveData( );
        chara4.saveData( );
        chara5.saveData( );
        chara6.saveData( );
    }

    public bool allDeath( ) {
        if ( !chara1.getStatus( ).death ) {
            return false;
        }
        if ( !chara2.getStatus( ).death ) {
            return false;
        }
        if ( !chara3.getStatus( ).death ) {
            return false;
        }
        if ( !chara4.getStatus( ).death ) {
            return false;
        }
        if ( !chara5.getStatus( ).death ) {
            return false;
        }
        if ( !chara6.getStatus( ).death ) {
            return false;
        }
        return true;
    }

    public Status getCharacter( CHARACTER character ) {
        switch ( character ) {
            case CHARACTER.CHARA1:
                return chara1;
            case CHARACTER.CHARA2:
                return chara2;
            case CHARACTER.CHARA3:
                return chara3;
            case CHARACTER.CHARA4:
                return chara4;
            case CHARACTER.CHARA5:
                return chara5;
            case CHARACTER.CHARA6:
                return chara6;
            default:
                return chara1;
        }
    }
}
