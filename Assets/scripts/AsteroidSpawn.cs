using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour {
	
	public GameObject baseEnemy;
	public GameObject hardEnemy;

	float padding = 4f;

	float hardenemyspawntimer = 1;
	float hardenemyspawnnumber = 0;

	public float spawnTime = 5f;
	public float spawnInc = 0.5f;

	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", 0, spawnTime);
		InvokeRepeating ("IncreaseSpawnSpeed", 5, 5);

	}

	void Update () {
		if ((globals.score / 10000) > hardenemyspawntimer) {
			hardenemyspawnnumber = 0;
			InvokeRepeating("spawnHard", hardenemyspawntimer, 0.5f);
			hardenemyspawntimer++;
		}
	}
	
	void IncreaseSpawnSpeed(){

		CancelInvoke ("Spawn");

		if ((spawnTime - spawnInc) < spawnInc) {
				spawnTime = spawnInc;
		} else {
				spawnTime -= spawnInc;
		}

		InvokeRepeating ("Spawn", 0, spawnTime);

	}

	void Spawn() {
		Instantiate(baseEnemy, NewLocation(), Quaternion.identity);
	}

	void spawnHard(){
		Instantiate (hardEnemy, NewLocation (), Quaternion.identity);
		if (((globals.score / 10000) - hardenemyspawntimer) < hardenemyspawnnumber) {
			CancelInvoke ("spawnHard");
		}
		hardenemyspawnnumber++;
		
	}

	Vector2 NewLocation(){
		Vector2 newLocation = new Vector3(Random.Range(-padding,padding),Random.Range(-padding,padding));
		
		while(Vector2.Distance(new Vector3(0,0), newLocation) < 2.5f){
			newLocation = new Vector3(Random.Range(-padding,padding),Random.Range(-padding,padding));
		}
		
		return newLocation;
	}


}
