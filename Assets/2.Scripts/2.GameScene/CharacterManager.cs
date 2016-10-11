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
    FATHER,
    MOTHER,
    SISTER,
    BROTHER,
}

public class CharacterManager : MonoBehaviour {
    Status father;
    Status mother;
    Status sister;
    Status brother;

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

    void Start( ) {
        DECREASE_FOODS_HEALTHY = 1;
        DECREASE_WATER_HEALTHY = 1;
        DECREASE_WATER_SICK = 1;
        DECREASE_HEALTH_HUNGER = 2;
        DECREASE_HEALTH_SICK = 1;
        DECREASE_LOYALTY_SICK = 1;
        DECREASE_LOYALTY_DISSATISFACTION = 2;

        INCREASE_HEALTH = 1;
        INCREASE_LOYALTY = 1;

        FULL_HEALTH = 10;
        SATISFACTION_VALUE = 5;
        DISSATISFACTION_VALUE = 2;

		father = GameObject.Find( "Father" ).GetComponent<Status>( );
		mother = GameObject.Find( "Mother" ).GetComponent<Status>( );
		sister = GameObject.Find( "Sister" ).GetComponent<Status>( );
		brother = GameObject.Find( "Brother" ).GetComponent<Status>( );
    }
	
	void Update( ) {
        
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
        decreaseFoods( father );
        decreaseFoods( mother );
        decreaseFoods( sister );
        decreaseFoods( brother );

        decreaseWater( father );
        decreaseWater( mother );
        decreaseWater( sister );
        decreaseWater( brother );

        variationHealth( father );
        variationHealth( mother );
        variationHealth( sister );
        variationHealth( brother );

        variationLoyality( father );
        variationLoyality( mother );
        variationLoyality( sister );
        variationLoyality( brother );

        death( father );
        death( mother );
        death( sister );
        death( brother );

        haveDisease( father );
        haveDisease( mother );
        haveDisease( sister );
        haveDisease( brother );
    }

    public bool allDeath( ) {
        if ( !father.getStatus( ).death ) {
            return false;
        }
        if ( !mother.getStatus( ).death ) {
            return false;
        }
        if ( !sister.getStatus( ).death ) {
            return false;
        }
        if ( !brother.getStatus( ).death ) {
            return false;
        }
        return true;
    }

    public Status getCharacter( CHARACTER character ) {
        switch ( character ) {
            case CHARACTER.FATHER:
                return father;
            case CHARACTER.MOTHER:
                return mother;
            case CHARACTER.SISTER:
                return sister;
            case CHARACTER.BROTHER:
                return brother;
            default:
                return father;
        }
    }
}
