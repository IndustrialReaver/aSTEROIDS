using UnityEngine;
using System.Collections;

public class bestTimeLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.gameObject.GetComponent<GUIText>().text = "BEST TIME: " + globals.bestTime;
	}
}
