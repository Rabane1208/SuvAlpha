using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {
    private STATUS character;

    void init( ) {
        character.place     = LAYER.INSIDE;
        character.foods     = 300;
        character.water     = 300;
        character.health    = 7;
        character.loyalty  = 5;
        character.death     = false;
        character.disease   = false;
    }

    void Start( ) {
        init( );
    }

    public STATUS getStatus( ) { return character; }
    public void setPlace( LAYER place ) { character.place = place; }
    public void setFoods( int foods ) { character.foods = foods; }
    public void setWater( int water ) { character.water = water; }
    public void setHealth( int health ) { character.health = health; }
    public void setLoyalty( int loyalty ) { character.loyalty = loyalty; }
    public void setDeath( bool death ) { character.death = death; }
    public void setDisease( bool disease ) { character.disease = disease; }
}
