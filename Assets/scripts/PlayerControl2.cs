using UnityEngine;
using System.Collections;

public class PlayerControl2 : MonoBehaviour {
	
	public GameObject bullet;
	public GameObject death;
	private int shootTime = 0;
	Quaternion bulletrotation;

	Quaternion rotoration;
	
	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		Input.gyro.updateInterval = 0.0167f;
		globals.score = 0;
		globals.time = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		globals.time++;
		shootTime++;

		rotoration = new Quaternion(0.5f, 0.5f, 0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
		//transform.rotation = rotoration;//new Quaternion(0,0,rotoration.z,0);
		transform.rotation = new Quaternion(0,0,rotoration.x,0);
		//transform.Rotate (0,0,-rotoration.x);
		
		if (shootTime % 10 == 0) {
			Instantiate (bullet, transform.position + new Vector3(0,0,1), transform.rotation);
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "enemy") {
			//print ("dead");
			if(globals.time > globals.bestTime){
				globals.bestTime = globals.time;
			}
			if(globals.score > globals.bestScore){
				globals.bestScore = globals.score;
			}
			
			Destroy(this.gameObject);
			Instantiate( death, transform.position, Quaternion.identity);
			
		}
	}
}
