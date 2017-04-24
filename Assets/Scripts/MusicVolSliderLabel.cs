using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolSliderLabel : MonoBehaviour {

    Text txt;
    private float currentMusicVolume = 0;

    // Use this for initialization
    void Start () {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Volume : " + currentMusicVolume;
    }

    // Update is called once per frame
    void Update () {
        txt.text = "Volume : " + currentMusicVolume;
        currentMusicVolume = centralPrefs.Instance.MusicVolume;
        PlayerPrefs.SetFloat("Slider Label", currentMusicVolume);
    }
}
