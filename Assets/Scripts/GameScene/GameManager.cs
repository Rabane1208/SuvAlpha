using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    private int oils;
    private int foods;
    private int bullets;

	// Use this for initialization
	void Start ( ) {
        oils = 100;
        foods = 100;
        bullets = 100;
	}
	
	// Update is called once per frame
	void Update ( ) {
	    
	}

    public int getOils( ) {
        return oils;
    }

    public int getFoods( ) {
        return foods;
    }

    public int getBullets( ) {
        return bullets;
    }
}
