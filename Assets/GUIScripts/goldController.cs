using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class goldController : MonoBehaviour {

	private Text text;

	public Text secondaryGoldText;

	public Slider slider;

	public float maxGoldAmount;

	public static float currentGold;

	private visibilityCommandController visibilityController;

	// Use this for initialization
	void Awake () {

		visibilityController = GameObject.FindObjectOfType <visibilityCommandController> ();

		text = GetComponent <Text> ();

	}

	void Start () {

		updateGoldAmount ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddGold (int goldAmount) {

		centralPrefs.Instance.lastUpdatedGoldAmount += goldAmount;

		updateGoldAmount ();

	}

	private void updateGoldAmount () {

		text.text = centralPrefs.Instance.lastUpdatedGoldAmount.ToString() + " gold";

		currentGold = centralPrefs.Instance.lastUpdatedGoldAmount;

		secondaryGoldText.text = "starting money " + centralPrefs.Instance.lastUpdatedGoldAmount.ToString ();

		visibilityController.commandExecuted();

	}

	public void DecreaseGold (int deacreaseAmount) {

		centralPrefs.Instance.lastUpdatedGoldAmount -= deacreaseAmount;

		updateGoldAmount ();


	}

	public void sliderGoldChange () {

		visibilityController.dragging = true;

		centralPrefs.Instance.lastUpdatedGoldAmount = (int) (slider.value * maxGoldAmount);

		updateGoldAmount ();

	}

}
