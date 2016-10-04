using UnityEngine;
using System.Collections;

public class BrotherStatus : MonoBehaviour {
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
}
