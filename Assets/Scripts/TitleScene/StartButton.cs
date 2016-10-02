using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    public void ChangeScene( ) {
        SceneManager.LoadScene( "IntroMovieScene" );
    }
}
