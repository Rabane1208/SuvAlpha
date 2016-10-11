using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovieManager : MonoBehaviour {
    private GameObject _text;
    private float _select;

    // Use this for initialization
	void Start ( ) {
        _select = PlayerPrefs.GetFloat( "Select" );
        _text = GameObject.Find( "MovieNum" ).gameObject;
        _text.GetComponent<Text>( ).text = "Movie " + PlayerPrefs.GetInt( "EventNumber" ).ToString( );
    }
	
	// Update is called once per frame
	void Update ( ) {
        
    }

    void playMovie( ) {
        switch ( PlayerPrefs.GetInt( "EventNumber" ) ) {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
    }

    public float getSelect( ) {
        return _select;
    }

    public void setSelect( float select ) {
        _select = select;
    }
}
