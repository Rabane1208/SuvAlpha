using UnityEngine;
using System.Collections;

public class SisterStatus : MonoBehaviour {
<<<<<<< HEAD
	private LAYER _place;
	private int _foods;
	private int _water;
	private int _health;
	private bool _death;
	private bool _disease;

	void Start( ) {
		_place = LAYER.INSIDE;
		_foods = 10;
		_water = 10;
		_health = 10;
		_death = false;
		_disease = false;
	}

	public LAYER getPlace( ) { return _place; }
	public int getFoods( ) { return _foods; }
	public int getWater( ) { return _water; }
	public int getHealth( ) { return _health; }
	public bool getDeath( ) { return _death; }
	public bool getDisease( ) { return _disease; }
	public void setPlace( LAYER place ) 	{ _place = place; }
	public void setFoods( int foods ) 		{ _foods = foods; }
	public void setWater( int water ) 		{ _water = water; }
	public void setHealth( int health ) 	{ _health = health; }
	public void setDeath( bool death ) 		{ _death = death; }
	public void setDisease( bool disease ) 	{ _disease = disease; }
=======
	private SisterStatus sister;
	public LAYER Place;
	public int Foods;
	public int Water;
	public int Health;
	public bool Death;
	public bool Disease;

	void Start( ) {
		sister = gameObject.GetComponent<SisterStatus>( );

		Place = LAYER.INSIDE;
		Foods = 10;
		Water = 10;
		Health = 10;
		Death = false;
		Disease = false;
	}

	public SisterStatus getStatus( ) {
		return sister;
	}

	public void setPlace( LAYER place ) 	{ Place = place; }
	public void setFoods( int foods ) 		{ Foods = foods; }
	public void setWater( int water ) 		{ Water = water; }
	public void setHealth( int health ) 	{ Health = health; }
	public void setDeath( bool death ) 		{ Death = death; }
	public void setDisease( bool disease ) 	{ Disease = disease; }
>>>>>>> eb2275d70e12f63b1fcc8cb1e6367ab3e154508d
}
