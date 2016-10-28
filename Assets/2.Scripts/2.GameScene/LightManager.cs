using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour {
    [SerializeField]
    private GameObject Light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnOffLight( ) {
        if ( Light.activeSelf ) {
            Light.SetActive( false );
        } else {
            Light.SetActive( true );
        }
    }
}