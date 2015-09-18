using UnityEngine;
using System.Collections;

public class highScoreLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.gameObject.GetComponent<GUIText>().text = "BEST SCORE: " + globals.bestScore;
	}
}
