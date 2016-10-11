using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	private GameObject mark;
	// Use this for initialization
	void Start () {
		mark = GameObject.Find ("Mark").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PointUp( ) {
		Vector3 pos = mark.transform.position;
		pos.y = transform.position.y;
		mark.transform.position = pos;
	}
}
