﻿using UnityEngine;
using System.Collections;

public class SisterStatus : MonoBehaviour {
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
}