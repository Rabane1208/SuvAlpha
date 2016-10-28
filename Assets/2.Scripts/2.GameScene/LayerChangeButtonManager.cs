using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LayerChangeButtonManager : MonoBehaviour {
    public Sprite Inside;
    public Sprite Outside;
    private GameObject game_system;

    // Use this for initialization
    void Start () {
        game_system = GameObject.Find( "GameSystem" ).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        LAYER layer = game_system.GetComponent<GameManager>( ).getLayer( );
        if ( layer == LAYER.OUTSIDE ) {
            gameObject.GetComponent<Image>( ).sprite = Inside;
        } else {
            gameObject.GetComponent<Image>( ).sprite = Outside;
        }
    }
}
