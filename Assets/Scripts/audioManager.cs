using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class audioManager : MonoBehaviour {

	public Slider mainSoundSlider;

	public Slider musicSoundSlider;

	private  GameObject[] audioObjects;

	private GameObject musicAudioObject;

	public float storedMusicVolumeValue;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake () {

		audioObjects = GameObject.FindGameObjectsWithTag ("withAudioSource");

		musicAudioObject = GameObject.FindGameObjectWithTag ("withMusicAudioSource");

		DontDestroyOnLoad (gameObject);
		
	}

	void Start () {

		storedMusicVolumeValue = centralPrefs.Instance.MusicVolume;

		mainSoundSlider.value = centralPrefs.Instance.MasterVolume;

		musicSoundSlider.value = storedMusicVolumeValue;

		musicAudioObject.GetComponent <AudioSource> ().volume = storedMusicVolumeValue;

		foreach (GameObject audioObject in audioObjects) {

			audioObject.GetComponent <AudioSource> ().volume = centralPrefs.Instance.MasterVolume;

		}
			

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void changeVolume () {

		centralPrefs.Instance.MasterVolume = mainSoundSlider.value;

		centralPrefs.Instance.MusicVolume = musicSoundSlider.value;

		foreach (GameObject audioObject in audioObjects) {

			audioObject.GetComponent <AudioSource> ().volume = centralPrefs.Instance.MasterVolume;

		}

		musicAudioObject.GetComponent <AudioSource> ().volume = centralPrefs.Instance.MusicVolume;

	}

}
