using UnityEngine;
using System.Collections;

public class enemyTracking : MonoBehaviour {

	public float speedMin;
	public float speedMax;
	float speed;
	public GameObject target;
	public ParticleSystem effect;
	Vector3 vectorToTarget;
	float roatationalSpeed;

	public AudioClip boom;

	// Use this for initialization
	void Start () {
		if (!(globals.playerShip == null)) {
			target = globals.playerShip;
		}
		speed = Random.Range (speedMin, speedMax);
		vectorToTarget = target.transform.position - this.transform.position;
		vectorToTarget = vectorToTarget.normalized * speed;

		roatationalSpeed = Random.Range(-100, 100);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		transform.position = this.transform.position + vectorToTarget * Time.deltaTime;
		transform.Rotate (Vector3.forward * roatationalSpeed * Time.deltaTime);

		if (Vector2.Distance (new Vector3 (0, 0), transform.position) > 5) {
						Destroy (this.gameObject);
				}


	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "bullet") {
			AudioSource.PlayClipAtPoint (boom, transform.position, 0.5f);
			Destroy(this.gameObject);
			Destroy(coll.gameObject);
			ParticleSystem.Instantiate(effect, transform.position, Quaternion.identity);
			globals.score += 50;
		}
	}
}
