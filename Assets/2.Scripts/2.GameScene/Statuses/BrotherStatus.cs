using UnityEngine;
using System.Collections;

public class BrotherStatus : MonoBehaviour {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 2cff042a845e8cf3ceb029438d36ed525e8421de
	private LAYER _place;
	private int _foods;
	private int _water;
	private int _health;
	private bool _death;
	private bool _disease;
<<<<<<< HEAD
=======

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
	private BrotherStatus brother;
	public LAYER Place;
	public int Foods;
	public int Water;
	public int Health;
	public bool Death;
	public bool Disease;
>>>>>>> 2cff042a845e8cf3ceb029438d36ed525e8421de

	void Start( ) {
		_place = LAYER.INSIDE;
		_foods = 10;
		_water = 10;
		_health = 10;
		_death = false;
		_disease = false;
	}

<<<<<<< HEAD
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
	public void setPlace( LAYER place ) 	{ Place = place; }
	public void setFoods( int foods ) 		{ Foods = foods; }
	public void setWater( int water ) 		{ Water = water; }
	public void setHealth( int health ) 	{ Health = health; }
	public void setDeath( bool death ) 		{ Death = death; }
	public void setDisease( bool disease ) 	{ Disease = disease; }
>>>>>>> eb2275d70e12f63b1fcc8cb1e6367ab3e154508d
>>>>>>> 2cff042a845e8cf3ceb029438d36ed525e8421de
}
