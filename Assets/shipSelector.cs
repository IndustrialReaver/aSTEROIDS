﻿using UnityEngine;
using System.Collections;

public class shipSelector : MonoBehaviour {

	public GameObject ship;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSelected() {
		globals.playerShip = ship;
	}



}
