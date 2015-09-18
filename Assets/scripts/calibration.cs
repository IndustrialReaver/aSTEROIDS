using UnityEngine;
using System.Collections;

public class calibration : MonoBehaviour {

	public static float calibrate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
						calibrate = Input.acceleration.x / 90;
						Application.LoadLevel ("aSteroidsIntro");
				}
	}
}
