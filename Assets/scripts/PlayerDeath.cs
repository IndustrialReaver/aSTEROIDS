using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	public ParticleSystem effect;
	public int waitTime = 90;
	int counter = 0;

	// Use this for initialization
	void Start () {
		ParticleSystem.Instantiate(effect, transform.position, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
		if (counter > waitTime && Input.touchCount > 0) {
			Application.LoadLevel ("aSteroidsMainMenu");
		}
		if (Input.GetMouseButtonDown(0) && counter > globals.waitTime) {
			Application.LoadLevel ("aSteroidsMainMenu");
		}
		counter++;
	}

}
