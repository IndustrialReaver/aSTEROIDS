using UnityEngine;
using System.Collections;

public class GameplayMasterController : MonoBehaviour {

	public GameObject defaultShip;

	// Use this for initialization
	void Start () {
		if (globals.playerShip == null) {
			Instantiate (defaultShip, new Vector3 (0, 0, 0), transform.rotation);
		} else {
			Instantiate (globals.playerShip, new Vector3 (0, 0, 0), transform.rotation);
		}

		globals.paused = false;
		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
