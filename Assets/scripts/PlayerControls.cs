using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public bool isMobile = false;
	public GameObject bullet;
	public GameObject death;
	public int modulous = 10;
	public bool canRotate = true;
	private int shootTime = 0;
	private int side = 1;
	string guntoshoot;

	// Use this for initialization
	void Start () {
		if(Application.isMobilePlatform){
			isMobile = true;
			Input.gyro.enabled = true;
		}
		globals.score = 0;
		globals.time = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		globals.time++;
		shootTime+=2;

		if(isMobile){
			Quaternion deviceRotation = DeviceRotation.Get();
			Quaternion referenceRotation = Quaternion.identity;
			Quaternion eliminationOfXY = Quaternion.Inverse(
			Quaternion.FromToRotation(referenceRotation * Vector3.forward, 
		                          deviceRotation * Vector3.forward)
			);
			Quaternion rotationZ = eliminationOfXY * deviceRotation;
			if(canRotate){
				transform.rotation = new Quaternion(rotationZ.x,rotationZ.y,-rotationZ.z,rotationZ.w);
			}
			if (shootTime % 10 == 0) {
				shootabunch(shootTime);
			}
		} else {
			var mouse = Input.mousePosition;
			var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
			var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
			var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
			if(canRotate){
				transform.rotation = Quaternion.Euler(0, 0, angle-90);
			}
			if ((shootTime % modulous == 0) && Input.GetMouseButton(0)) {
					shootabunch(shootTime);
			}
		}





	}

	private void shootabunch(int shootTime){
		Transform gun;
		if(side > 0) {
			//gun = transform.FindChild("RightGun");
			guntoshoot = "Right";
		} else {
			//gun = transform.FindChild ("LeftGun");
			guntoshoot = "Left";
		}
		transform.BroadcastMessage (guntoshoot, bullet, SendMessageOptions.DontRequireReceiver);
		//gun.gameObject.SendMessage("fire", bullet, SendMessageOptions.DontRequireReceiver);
		//Instantiate (bullet, new Vector3(transform.position.x+0.1f,transform.position.y+(0.1f * side),1f), transform.rotation);
		side = (side * -1);
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

	public static class DeviceRotation {
		private static bool gyroInitialized = false;
		
		public static bool HasGyroscope {
			get {
				return SystemInfo.supportsGyroscope;
			}
		}
		
		public static Quaternion Get() {
			if (!gyroInitialized) {
				InitGyro();
			}
			
			return HasGyroscope
				? ReadGyroscopeRotation()
					: Quaternion.identity;
		}
		
		private static void InitGyro() {
			if (HasGyroscope) {
				Input.gyro.enabled = true;                // enable the gyroscope
				Input.gyro.updateInterval = 0.0167f;    // set the update interval to it's highest value (60 Hz)
			}
			gyroInitialized = true;
		}
		
		private static Quaternion ReadGyroscopeRotation() {
			return new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
		}
	}

}
