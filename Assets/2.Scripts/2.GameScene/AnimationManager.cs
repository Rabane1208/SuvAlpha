using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PointEnterUIButton( ) {
        Vector3 pos = transform.position;
        pos.x += 10;
        transform.position = pos;
    }

    public void PointExitUIButton( ) {
        Vector3 pos = transform.position;
        pos.x -= 10;
        transform.position = pos;
    }
}
