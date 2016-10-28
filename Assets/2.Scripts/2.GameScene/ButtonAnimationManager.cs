using UnityEngine;
using System.Collections;

public class ButtonAnimationManager : MonoBehaviour {
    public GameObject page;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PointEnterUIButton( ) {
        Vector3 pos = transform.position;
        Vector3 page_pos = page.transform.position;
        pos.x += 10;
        page_pos.x += 10;
        transform.position = pos;
        page.transform.position = page_pos;
    }

    public void PointExitUIButton( ) {
        Vector3 pos = transform.position;
        Vector3 page_pos = page.transform.position;
        pos.x -= 10;
        page_pos.x -= 10;
        transform.position = pos;
        page.transform.position = page_pos;
    }
}
