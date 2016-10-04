using UnityEngine;
using System.Collections;

public class FatherStatus : MonoBehaviour {
	private FatherStatus father;
	public LAYER Place;
	public int Foods;
	public int Water;
	public int Health;
	public bool Death;
	public bool Disease;

	void Start( ) {
		father = gameObject.GetComponent<FatherStatus>( );

		Place = LAYER.INSIDE;
		Foods = 10;
		Water = 10;
		Health = 10;
		Death = false;
		Disease = false;
	}

	public FatherStatus getStatus( ) {
		return father;
	}
		
	public void setPlace( LAYER place ) 	{ Place = place; }
	public void setFoods( int foods ) 		{ Foods = foods; }
	public void setWater( int water ) 		{ Water = water; }
	public void setHealth( int health ) 	{ Health = health; }
	public void setDeath( bool death ) 		{ Death = death; }
	public void setDisease( bool disease ) 	{ Disease = disease; }
}
