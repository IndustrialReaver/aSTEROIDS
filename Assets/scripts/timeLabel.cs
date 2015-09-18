using UnityEngine;
using System.Collections;

public class timeLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.gameObject.GetComponent<GUIText>().text = "TIME: " + globals.time;
	}
}
