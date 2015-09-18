using UnityEngine;
using System.Collections;

public class globals : MonoBehaviour {

	public static int score = 0;
	public static float time = 0;
	public static float bestTime = 000000;
	public static int bestScore = 000000;
	public static int waitTime = 50;
	public static bool paused = false;

	public static GameObject playerShip = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
