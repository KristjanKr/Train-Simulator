using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolSliderLabel : MonoBehaviour {

    Text txt;
    private float currentMasterVolume = 0;

	// Use this for initialization
	void Start () {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Volume : " + currentMasterVolume;
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "Volume : " + currentMasterVolume;
        currentMasterVolume = centralPrefs.Instance.MasterVolume;
        PlayerPrefs.SetFloat("Slider Label", currentMasterVolume);
    }
}
