using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {
	float _timer;
	float _timer_switch;
	float _event_time;
	int _event_num;
	int _select;

	public int FIRST_EVENT;
	public int SECOND_EVENT;
	public int THIRD_EVENT;
	public int FOURTH_EVENT;
	public int FIFTH_EVENT;
	public int SIXTH_EVENT;
	public int SEVENTH_EVENT;

    GameObject _yes_text;
	GameObject _no_text;
	GameObject _button;

	GameObject _text;

	// Use this for initialization
	void Start( ) {
		FIRST_EVENT = 1;
		SECOND_EVENT = 2;
        THIRD_EVENT = 3;
        FOURTH_EVENT = 2;
        FIFTH_EVENT = 1;
        SIXTH_EVENT = 4;
        SEVENTH_EVENT = 4;

        _timer = 0;
		_timer_switch = 1;
		_event_time = FIRST_EVENT;
		_event_num = 0;
		_select = 0;
		_yes_text = GameObject.Find( "YesText" ).gameObject;
		_no_text = GameObject.Find( "NoText" ).gameObject;
		_yes_text.GetComponent<Text>( ).text = "0";
		_no_text.GetComponent<Text>( ).text = "0";
		_button = GameObject.Find( "Button" ).gameObject;

		_text = GameObject.Find( "Text" ).gameObject;
	}
	
	// Update is called once per frame
	void Update( ) {
        if ( _event_num > 6 ) {
            PlayerPrefs.SetInt( "IntroSelect", _select );
            SceneManager.LoadScene( "GameScene" );
        }
        if ( _select == 15 ) {

        }
		_timer += _timer_switch * Time.deltaTime;
		drawButton( );
		Select( _event_time );
		Debug.Log( _timer );
		_text.GetComponent<Text>().text = _event_num.ToString( ) +"  " + _select.ToString();
	}

	void drawButton( ) {
		if ( _timer_switch == 1 ) {
			_button.SetActive( false );
		}
        if ( _timer_switch == 0 ) {
            _button.SetActive( true );
        } 
	}

	void Select( float time ) {
		if ( _timer < time ) {
			return;
		}
		_timer_switch = 0;
		
		switch ( _event_num ) {
			case 0:
				_event_time = SECOND_EVENT;
				break;
			case 1:
                _event_time = THIRD_EVENT;
                _yes_text.GetComponent<Text>( ).text = "1";
				_no_text.GetComponent<Text>( ).text = "1";
				break;
			case 2:
                _event_time = FOURTH_EVENT;
                _yes_text.GetComponent<Text>( ).text = "2";
				_no_text.GetComponent<Text>( ).text = "2";
				break;
			case 3:
                _event_time = FIFTH_EVENT;
                _yes_text.GetComponent<Text>( ).text = "3";
				_no_text.GetComponent<Text>( ).text = "3";
				break;
			case 4:
                _event_time = SIXTH_EVENT;
                _yes_text.GetComponent<Text>( ).text = "4";
				_no_text.GetComponent<Text>( ).text = "4";
				break;
			case 5:
                _event_time = SEVENTH_EVENT;
                _yes_text.GetComponent<Text>( ).text = "5";
				_no_text.GetComponent<Text>( ).text = "5";
				break;
		}
	}

	public int getEventNum( ) {
		return _event_num;
	}

	public void setEventNum( int num ) {
		_event_num = num;
	}

	public int getSelect( ) {
		return _select;
	}

	public void setSelect( int num ) {
		_select = num;
	}

	public void setTimerSwitch( int num ) {
		_timer = 0;
		_timer_switch = num;
	}
}
