using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public  class visibilityCommandController : MonoBehaviour {

	private Canvas visibilityAdjustmentCanvas;

	private float canvasAlpha;

	public bool dragging;

	private bool inCoroutine;

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

		inCoroutine = true;

		while (canvasAlpha > 0) {

			canvasAlpha -= canvasAplphaDecrement;

			visibilityAdjustmentCanvas.GetComponent <CanvasGroup> ().alpha = canvasAlpha;	

			yield return new WaitForSeconds (timeBetweenDecrements);

		}

		if (canvasAlpha <= 0)
			inCoroutine = false;

	}

	public void commandExecuted () {

		if (dragging) {

			visibilityAdjustmentCanvas.GetComponent <CanvasGroup> ().alpha = 1;
			return;

		}


		if (inCoroutine)
			return;

		canvasAlpha = 1;

		visibilityAdjustmentCanvas.GetComponent <CanvasGroup> ().alpha = canvasAlpha;	

		StartCoroutine (transitionToTransparent ());

	}

}
