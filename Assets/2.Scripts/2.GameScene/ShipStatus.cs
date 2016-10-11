using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct RESOURCES
{
    public int fuels;
    public int foods;
    public int water;
    public int guns;
    public int medical_kits;
    public int repair_tools;
    public int radios;
    public bool ship_break;
}

public class ShipStatus : MonoBehaviour {
    private RESOURCES resources;

	void Awake( ) {
		init( );
	}

    void init( ) {
        resources.fuels = 10;
        resources.foods = 20;
        resources.water = 20;
        resources.guns = 3;
        resources.medical_kits = 3;
        resources.repair_tools = 3;
        resources.radios = 1;
        PlayerPrefs.Save();
    }

    public bool isShipBreak() { return resources.ship_break; }
    public void setShipBreak(bool breaked) { resources.ship_break = breaked; }
    public RESOURCES getResources( ) { return resources; }

    public void setFuels( int fuels ) {
        resources.fuels = fuels;
        if ( resources.fuels <= 0 ) {
            resources.fuels = 0;
            return;
        }
    }
    public void setFoods( int foods ) {
        resources.foods = foods;
        if ( resources.foods <= 0 ) {
            resources.foods = 0;
            return;
        }
    }
    public void setWater( int water ) {
        resources.water = water;
        if ( resources.water <= 0 ) {
            resources.water = 0;
            return;
        }
    }
    public void setGuns( int guns ) {
        resources.guns = guns;
        if ( resources.guns <= 0 ) {
            resources.guns = 0;
            return;
        }
    }
    public void setMedicalKits( int medical_kits ) {
        resources.medical_kits = medical_kits;
        if ( resources.medical_kits <= 0 ) {
            resources.medical_kits = 0;
            return;
        }
    }
    public void setRadios( int radios ) {
        resources.radios = radios;
        if ( resources.radios <= 0 ) {
            resources.radios = 0;
            return;
        }
    }
    public void setRepairTools( int repair_tools ) {
        resources.repair_tools = repair_tools;
        if ( resources.repair_tools <= 0 ) {
            resources.repair_tools = 0;
            return;
        }
    }
}



//그냥 나중에 Player.Prefs로
/*public void saveGameDataCsv( ) {
		using ( var writer = new CsvFileWriter ("Assets/Resources/Game_Data.csv")) {
			List<string> columns = new List<string> () {
				"Days",
				"Selects",
				"Fuels",
				"Foods",
				"Water",
				"Guns",
				"Medikal Kits",
				"Repair Tools",
				"Radios",
			};// making Index Row
			writer.WriteRow (columns);
			columns.Clear ();

			columns.Add ("40"); // Name
			columns.Add ("99"); // Level
			columns.Add ("999"); // Hp
			columns.Add ("5000"); // Exp
			columns.Add ("99"); // Str
			columns.Add ("50"); // Dex
			columns.Add ("80"); // Con
			columns.Add ("40"); // Int
			columns.Add ("40"); // Int
			writer.WriteRow (columns);
			columns.Clear ();
		}
	}

	public void saveCharaDataCsv( ) { //그냥 나중에 Player.Prefs로
		using (var writer = new CsvFileWriter ("Assets/Resources/Chara_Data.csv")) {
			List<string> columns = new List<string> () {
				"Character",
				"Place",
				"Foods",
				"Water",
				"Health",
				"Loyalty",
				"Death",
				"Disease"
			};// making Index Row
			writer.WriteRow (columns);
			columns.Clear ();

			columns.Add ("Bbulle"); // Name
			columns.Add ("99"); // Level
			columns.Add ("999"); // Hp
			columns.Add ("5000"); // Exp
			columns.Add ("99"); // Str
			columns.Add ("50"); // Dex
			columns.Add ("80"); // Con
			columns.Add ("40"); // Int
			writer.WriteRow (columns);
			columns.Clear ();

			columns.Add ("Kukai"); // Name
			columns.Add ("50"); // Level
			columns.Add ("666"); // Hp
			columns.Add ("3500"); // Exp
			columns.Add ("66"); // Str
			columns.Add ("66"); // Dex
			columns.Add ("44"); // Con
			columns.Add ("22"); // Int
			writer.WriteRow (columns);
			columns.Clear ();
		}
	}*/
