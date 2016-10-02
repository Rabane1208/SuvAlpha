using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour {
    public void SkipMovie( ) {
        SceneManager.LoadScene( "GameScene" );
    }
}
