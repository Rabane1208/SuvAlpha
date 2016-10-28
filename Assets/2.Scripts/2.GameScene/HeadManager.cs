using UnityEngine;
using System.Collections;

public class HeadManager : MonoBehaviour {

    [SerializeField]
    private GameObject Body;

    public Sprite Normal;
    public Sprite Sick;
    public Sprite Hungry;
    public Sprite Thirsty;
    public Sprite Defiance;
    public Sprite Death;

    // Use this for initialization
    void Start ( ) {
	
	}
	
	// Update is called once per frame
	void Update ( ) {
        setFace( );
    }

    void setFace( ) {
        switch ( Body.GetComponent<Status>( ).getState( ) ) {
            case STATE.NORMAL:
                gameObject.GetComponent<SpriteRenderer>( ).sprite = Normal;
                break;
            case STATE.SICK:
                gameObject.GetComponent<SpriteRenderer>( ).sprite = Sick;
                break;
            case STATE.HUNGRY:
                gameObject.GetComponent<SpriteRenderer>( ).sprite = Hungry;
                break;
            case STATE.THIRSTY:
                gameObject.GetComponent<SpriteRenderer>( ).sprite = Thirsty;
                break;
            case STATE.DEFIANCE:
                gameObject.GetComponent<SpriteRenderer>( ).sprite = Defiance;
                break;
            case STATE.DEATH:
                gameObject.GetComponent<SpriteRenderer>( ).sprite = Death;
                break;
            default:
                gameObject.GetComponent<SpriteRenderer>( ).sprite = Normal;
                break;
        }
    }
}
