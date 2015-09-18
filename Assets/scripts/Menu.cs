using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void OnMouseDown(){
		//Application.LoadLevel("aSteroidsMainMenu");
		globals.paused = !globals.paused;
		if (globals.paused) {
			Time.timeScale = 0.0f;
		} else {
			Time.timeScale = 1.0f;
		}
	}

}
