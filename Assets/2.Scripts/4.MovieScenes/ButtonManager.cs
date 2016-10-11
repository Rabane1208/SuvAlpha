using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    MovieManager select_manager;

    void Awake( ) {
        select_manager = GameObject.Find( "MovieSystem" ).gameObject.GetComponent<MovieManager>( );
    }

    public void SkipMovie( ) {
        SceneManager.LoadScene( "GameScene" );
    }

    public void Select1( ) {
        int event_num = PlayerPrefs.GetInt( "EventNumber" );
        select_manager.setSelect( select_manager.getSelect( ) + Mathf.Pow( 2.0f, ( float )event_num ) );
        PlayerPrefs.SetFloat( "Select", select_manager.getSelect( ) );
        PlayerPrefs.Save( );
    }

    public void reset( ) {
        PlayerPrefs.DeleteAll( );
    }
}
