using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum LAYER {
    INSIDE,
    OUTSIDE,
}

public class GameManager : MonoBehaviour {
    
    private int _fuels;
    private int _foods;
    private int _bullets;
    private int _days;
    private LAYER _layer;

    // Use this for initialization
    void Start( ) {
        _days    = 1;
        _fuels   = 100;
        _foods   = 100;
        _bullets = 100;
        _layer = LAYER.OUTSIDE;
    }

    // Update is called once per frame
    void Update( ) {
        changeScene( );
    }

    void changeScene( ) {
        if ( gameOver( ) ) {
            SceneManager.LoadScene( "GameOverScene" );
        }
    }

    bool gameOver( ) {
        if ( _foods <= 0 ) {
            return true;
        }
        return false;
    }

    public int getFuels( ) {
        return _fuels;
    }

    public int getFoods( ) {
        return _foods;
    }

    public int getBullets( ) {
        return _bullets;
    }

    public int getDays( ) {
        return _days;
    }

    public LAYER getLayer( ) {
        return _layer;
    }

    public void setLayer( LAYER layer ) {
        _layer = layer;
    }

    public void NextDay( ) {
        _days++;
        _fuels -= 10;
        _foods -= 10;
    }
}
