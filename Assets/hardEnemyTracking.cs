using UnityEngine;
using System.Collections;

public class hardEnemyTracking : MonoBehaviour {
	
	public float speedMin;
	public float speedMax;
	float speed;
	public GameObject target;
	public ParticleSystem effect;
	Vector3 vectorToTarget;
	float roatationalSpeed;
	
	// Use this for initialization
	void Start () {
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
			Destroy(this.gameObject);
			Destroy(coll.gameObject);
			ParticleSystem.Instantiate(effect, transform.position, Quaternion.identity);
			globals.score += 50;
		}
	}
}
