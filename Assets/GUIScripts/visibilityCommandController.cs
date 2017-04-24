using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public  class visibilityCommandController : MonoBehaviour {

	private Canvas visibilityAdjustmentCanvas;

	private float canvasAlpha;

	[Header ("transition to transparent feature controll")]

	[Tooltip ("this should be very low")]
	public float canvasAplphaDecrement;

	[Tooltip ("this is the time (in seconds) between the decrements")]
	public float timeBetweenDecrements;

	void Awake () {

		DontDestroyOnLoad (gameObject);

		GameObject findCanvas = GameObject.FindGameObjectWithTag ("temporarelyVisibleCanvas");


		visibilityAdjustmentCanvas = findCanvas.GetComponent <Canvas> ();

		canvasAlpha = visibilityAdjustmentCanvas.GetComponent <CanvasGroup> ().alpha;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (canvasAlpha);

	}

	public IEnumerator transitionToTransparent () {

		while (canvasAlpha > 0) {

			canvasAlpha -= canvasAplphaDecrement;

			visibilityAdjustmentCanvas.GetComponent <CanvasGroup> ().alpha = canvasAlpha;	

			yield return new WaitForSeconds (timeBetweenDecrements);

		}

	}

	public void commandExecuted () {

		canvasAlpha = 1;

		visibilityAdjustmentCanvas.GetComponent <CanvasGroup> ().alpha = canvasAlpha;	

		StartCoroutine (transitionToTransparent ());

	}

}
