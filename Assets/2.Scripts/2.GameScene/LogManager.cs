using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogManager : MonoBehaviour {
    private Vector3 log_pos;
    private bool log_open;
    private int log_page;

    // Use this for initialization
    void Start( ) {
        log_open = false;
        log_page = 1;
    }
	
	// Update is called once per frame
    void Update( ) {
        UpdateLog( );
    }

    void UpdateLog( ) {
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit hit;

        MoveLog( );

        if ( !Input.GetMouseButtonUp( 0 ) ) {
            return;
        }
        if ( !Physics.Raycast( ray, out hit ) ) {
            return;
        }

        if ( hit.transform.gameObject.name == "Log" ) {
            log_open = true;
        }

        if ( hit.transform.gameObject.name == "CloseButton" ) {
            log_open = false;
        }

        if ( hit.transform.gameObject.name == "NextPageButton" ) {
            log_page = 2;
        }

        if ( hit.transform.gameObject.name == "BeforePageButton" ) {
            log_page = 1;
        }
    }

    void MoveLog( ) {
        if ( !log_open ) {
            if( transform.position.x <= -650.0f ) {
                return;
            }
            log_pos = transform.position;
            log_pos.x -= 10f;
            transform.position = log_pos;
        }
        
        if ( log_open ) {
            if( transform.position.x >= 0 ) {
                return;
            }
            log_pos = transform.position;
            log_pos.x += 10f;
            transform.position = log_pos;
        }
    }

    public bool isLogOpened( ) {
        return log_open;
    }

    public void setLogOpen( bool flag ) {
        log_open = flag;
    }

    public int getLogPage( ) {
        return log_page;
    }
}
