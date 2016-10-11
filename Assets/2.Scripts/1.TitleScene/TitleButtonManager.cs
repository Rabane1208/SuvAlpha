using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour {
    private GameObject mark;
    // Use this for initialization
    void Start( ) {
        mark = GameObject.Find( "Mark" ).gameObject;
    }

    // Update is called once per frame
    void Update( ) {

    }

    public void PointEnter( ) {
        Vector3 pos = mark.transform.position;
        pos.y = transform.position.y;
        mark.transform.position = pos;
    }

    public void NewGameButton( ) {
        PlayerPrefs.DeleteAll( );
        SceneManager.LoadScene( "IntroScene" );
    }

    public void LoadGameButton( ) {
        SceneManager.LoadScene( "GameScene" );
    }

    public void OptionButton( ) {
        SceneManager.LoadScene( "OptionScene" );
    }

    public void CreditButton( ) {
        SceneManager.LoadScene( "CreditScene" );
    }
}
