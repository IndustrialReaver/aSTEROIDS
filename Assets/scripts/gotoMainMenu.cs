using UnityEngine;
using System.Collections;

public class gotoMainMenu : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		time++;
		if (Input.touchCount > 0 && time > globals.waitTime) {
			Application.LoadLevel ("aSteroidsMainMenu");
		}

		if (Input.GetMouseButtonDown(0) && time > globals.waitTime) {
			Application.LoadLevel ("aSteroidsMainMenu");
		}
	}
}
