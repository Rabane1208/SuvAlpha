<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum LAYER {
    INSIDE,
    OUTSIDE,
}

public struct RESOURCES {
    public int fuels;
    public int foods;
    public int water;
    public int guns;
    public int medical_kits;
    public int radios;
    public int repair_tools;
}

public class GameManager : MonoBehaviour {
    private int days;
    private GameObject inside_layer;
    private GameObject outside_layer;
	private GameObject character_system;
    private RESOURCES resources;
    private LAYER _layer;

    void Start( ) {
        init( );

        _layer = LAYER.OUTSIDE;

        inside_layer = GameObject.Find( "InsideLayer" ).gameObject;
        outside_layer = GameObject.Find( "OutsideLayer" ).gameObject;
		character_system = GameObject.Find( "CharacterSystem" ).gameObject;
    }

    void Update( ) {
        updateLayer( );
        changeScene( );
    }

    void updateLayer( ) {
		Vector3 inside_layer_pos = inside_layer.transform.position;
        switch ( _layer ) {
            case LAYER.INSIDE:
				inside_layer_pos.x = 0;
				inside_layer.transform.position = inside_layer_pos;
                inside_layer.SetActive( true );
                outside_layer.SetActive( false );
                break;
            case LAYER.OUTSIDE:
                inside_layer.SetActive( false );
                outside_layer.SetActive( true );
                break;
        }
    }

    void init( ) {
        days = 1;
        resources.fuels = 100;
        resources.foods = 100;
        resources.water = 100;
        resources.guns = 1;
        resources.medical_kits = 1;
        resources.radios = 1;
        resources.repair_tools = 1;
    }

    void changeScene( ) {
        if ( gameOver( ) ) {
            SceneManager.LoadScene( "GameOverScene" );
        }
    }

    bool gameOver( ) {
        if ( resources.foods <= 0 ) {
            return true;
        }
        return false;
    }

    public void NextDay( ) {
		FatherStatus father = character_system.GetComponent<FatherStatus>( );
		MotherStatus mother = character_system.GetComponent<MotherStatus>( );
		SisterStatus sister = character_system.GetComponent<SisterStatus>( );
		BrotherStatus brother = character_system.GetComponent<BrotherStatus>( );
        days++;
        resources.fuels -= 10;

		father.setFoods( father.getFoods( ) - 1 );
		sister.setFoods( sister.getFoods( ) - 1 );
		mother.setFoods( mother.getFoods( ) - 1 );
		brother.setFoods( brother.getFoods( ) - 1 );
    }

    public LAYER getLayer( ) { return _layer; }
    public void setLayer( LAYER layer ) { _layer = layer; }

    public int getDays( )        { return days;                   }
    public int getFuels( )       { return resources.fuels;        }
    public int getFoods( )       { return resources.foods;        }
    public int getWater( )       { return resources.water;        }
    public int getGuns( )        { return resources.guns;         }
    public int getMedicalKits( ) { return resources.medical_kits; }
    public int getRadios( )      { return resources.radios;       }
    public int getRepairTools( ) { return resources.repair_tools; }
    public void setFuels( int fuels )              { resources.fuels = fuels;               }
    public void setFoods( int foods )              { resources.foods = foods;               }
    public void setWater( int water )              { resources.water = water;               }
    public void setGuns( int guns )                { resources.guns = guns;                 }
    public void setMedicalKits( int medical_kits ) { resources.medical_kits = medical_kits; }
    public void setRadios( int radios )            { resources.radios = radios;             }
    public void setRepairTools( int repair_tools ) { resources.repair_tools = repair_tools; }
}
=======
﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum LAYER {
    INSIDE,
    OUTSIDE,
}

public struct RESOURCES {
    public int fuels;
    public int foods;
    public int water;
    public int guns;
    public int medical_kits;
    public int radios;
    public int repair_tools;
}

public class GameManager : MonoBehaviour {
    private int days;
    private GameObject inside_layer;
    private GameObject outside_layer;
	private GameObject character_system;
    private RESOURCES resources;
    private LAYER _layer;

    void Start( ) {
        init( );

        _layer = LAYER.OUTSIDE;

        inside_layer = GameObject.Find( "InsideLayer" ).gameObject;
        outside_layer = GameObject.Find( "OutsideLayer" ).gameObject;
		character_system = GameObject.Find( "CharacterSystem" ).gameObject;
    }

    void Update( ) {
        updateLayer( );
        changeScene( );
    }

    void updateLayer( ) {
		Vector3 inside_layer_pos = inside_layer.transform.position;
        switch ( _layer ) {
            case LAYER.INSIDE:
				inside_layer_pos.x = 0;
				inside_layer.transform.position = inside_layer_pos;
                inside_layer.SetActive( true );
                outside_layer.SetActive( false );
                break;
            case LAYER.OUTSIDE:
                inside_layer.SetActive( false );
                outside_layer.SetActive( true );
                break;
        }
    }

    void init( ) {
        days = 1;
        resources.fuels = 100;
        resources.foods = 100;
        resources.water = 100;
        resources.guns = 1;
        resources.medical_kits = 1;
        resources.radios = 1;
        resources.repair_tools = 1;
    }

    void changeScene( ) {
        if ( gameOver( ) ) {
            SceneManager.LoadScene( "GameOverScene" );
        }
    }

    bool gameOver( ) {
        if ( resources.foods <= 0 ) {
            return true;
        }
        return false;
    }

    public void NextDay( ) {
		FatherStatus father = character_system.GetComponent<FatherStatus>( );
		MotherStatus mother = character_system.GetComponent<MotherStatus>( );
		SisterStatus sister = character_system.GetComponent<SisterStatus>( );
		BrotherStatus brother = character_system.GetComponent<BrotherStatus>( );
        days++;
        resources.fuels -= 10;

		father.setFoods( father.getFoods( ) - 1 );
		sister.setFoods( sister.getFoods( ) - 1 );
		mother.setFoods( mother.getFoods( ) - 1 );
		brother.setFoods( brother.getFoods( ) - 1 );
    }

    public LAYER getLayer( ) { return _layer; }
    public void setLayer( LAYER layer ) { _layer = layer; }

    public int getDays( )        { return days;                   }
    public int getFuels( )       { return resources.fuels;        }
    public int getFoods( )       { return resources.foods;        }
    public int getWater( )       { return resources.water;        }
    public int getGuns( )        { return resources.guns;         }
    public int getMedicalKits( ) { return resources.medical_kits; }
    public int getRadios( )      { return resources.radios;       }
    public int getRepairTools( ) { return resources.repair_tools; }
    public void setFuels( int fuels )              { resources.fuels = fuels;               }
    public void setFoods( int foods )              { resources.foods = foods;               }
    public void setWater( int water )              { resources.water = water;               }
    public void setGuns( int guns )                { resources.guns = guns;                 }
    public void setMedicalKits( int medical_kits ) { resources.medical_kits = medical_kits; }
    public void setRadios( int radios )            { resources.radios = radios;             }
    public void setRepairTools( int repair_tools ) { resources.repair_tools = repair_tools; }
}
>>>>>>> eb2275d70e12f63b1fcc8cb1e6367ab3e154508d
