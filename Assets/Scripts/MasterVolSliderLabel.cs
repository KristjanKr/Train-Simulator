using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolSliderLabel : MonoBehaviour {

    Text txt;
    private float currentMusicVolume = 0;

	// Use this for initialization
	void Start () {
        currentMusicVolume = 0;
        txt = gameObject.GetComponent<Text>();
        txt.text = "Volume : " + currentMusicVolume;
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "Volume : " + currentMusicVolume;
        currentMusicVolume = audioManager.storedMusicVolumeValue;
        PlayerPrefs.SetFloat("Slider Label", currentMusicVolume);
    }
}
