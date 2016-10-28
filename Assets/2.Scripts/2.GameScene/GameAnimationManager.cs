using UnityEngine;
using System.Collections;

public class GameAnimationManager : MonoBehaviour {
    public GameObject Sea1;
    public float Sea1Ampplitude;
    public GameObject Sea2;
    public float Sea2Ampplitude;
    public GameObject Sea3;
    public float Sea3Ampplitude;
    public GameObject Sea4;
    public float Sea4Ampplitude;
    public GameObject Sea5;
    public float Sea5Ampplitude;
    public GameObject Character;
    public float CharacterAmpplitude;
    public GameObject Ship;
    public float ShipAmpplitude;

    public GameObject Clude1;
    public float Clude1Speed;
    public GameObject Clude2;
    public float Clude2Speed;
    public GameObject Clude3;
    public float Clude3Speed;
    public GameObject Clude4;
    public float Clude4Speed;

    private float _timer;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;
        WaveOnSea( Sea1, Sea1Ampplitude, _timer, 1, 0 );
        WaveOnSea( Sea2, Sea2Ampplitude, _timer, 2, 0 );
        WaveOnSea( Sea3, Sea3Ampplitude, _timer, 3, 0 );
        WaveOnSea( Sea4, Sea4Ampplitude, _timer, 4, 0 );
        WaveOnSea( Sea5, Sea5Ampplitude, _timer, 3, 0 );
        WaveOnSea( Character, CharacterAmpplitude, _timer, 2, 70 );
        WaveOnSea( Ship, ShipAmpplitude, _timer, 2, -230 );

        CludeMove( Clude1, Clude1Speed );
        CludeMove( Clude2, Clude2Speed );
        CludeMove( Clude3, Clude3Speed );
        CludeMove( Clude4, Clude4Speed );
    }

    void WaveOnSea( GameObject obj, float ampplitude, float timer, float speed, float s_pos ) {
        Vector3 pos = obj.transform.position;
        pos.y = ampplitude * Mathf.Sin( timer * Mathf.PI / speed ) + s_pos;
        obj.transform.position = pos;
    }

    void CludeMove( GameObject obj, float speed ) {
        Vector3 pos = obj.transform.position;
        pos.x += speed;
        if ( pos.x > 1600 ) {
            pos.x = -1600;
        }
        if ( pos.x < -1600 ) {
            pos.x = 1600;
        }
        obj.transform.position = pos;
    }
}
