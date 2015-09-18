using UnityEngine;
using System.Collections;

public class scoreLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.gameObject.GetComponent<GUIText>().text = "SCORE: " + globals.score;
	}
}
