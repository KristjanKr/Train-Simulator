using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class centralPrefs : MonoBehaviour {

	public static centralPrefs Instance;

	public void Awake () {

		Instance = this;

	}

	public float MasterVolume {

		get { return PlayerPrefs.GetFloat ("masterVolume", 5f); }

		set	{ PlayerPrefs.SetFloat ("masterVolume", value);}

	}

	public float MusicVolume {

		get { return PlayerPrefs.GetFloat ("musicVolume", 5f); }

		set	{ PlayerPrefs.SetFloat ("musicVolume", value);}

	}
	

	public int LastUpdatedScore {

		get { return PlayerPrefs.GetInt ("lastScore", 0); }

		set	{ PlayerPrefs.SetInt ("lastScore", value); }

	}

	public bool Mute {

		get { return PlayerPrefs.GetInt ("muteStatus", 1) != 0; }
		set { PlayerPrefs.SetInt ("muteStatus", value?  1:0); }

	}
		

}