﻿using UnityEngine;
using System.Collections;

public class newGame : MonoBehaviour {

	int time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time++;
	}
	
	void OnMouseDown(){
		if (time > globals.waitTime) {
			Application.LoadLevel ("aSteroidsStaging");
		}
	}
	
}
