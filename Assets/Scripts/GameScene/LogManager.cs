using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogManager : MonoBehaviour {
    private Vector3 log_pos;
    private bool log_open;

    // Use this for initialization
    void Start ( ) {
        log_open = false;
    }
	
	// Update is called once per frame
    void Update( ) {
        UpdateLog( );
    }

    void UpdateLog( ) {
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit hit;

        MoveLog( );

        if( !Input.GetMouseButton( 0 ) ) {
            return;
        }
        if( !Physics.Raycast( ray, out hit ) ) {
            return;
        }
        if ( hit.transform.gameObject.name != "Log" ) {
            return;
        }
        log_open = true;
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
}
