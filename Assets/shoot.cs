using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
	
	public bool canRotate = false;
	public bool isMobile = false;
	public AudioClip pewpew;
	AudioSource playpew;

	void Start () {
		if(Application.isMobilePlatform){
			isMobile = true;
			Input.gyro.enabled = true;
		}
		globals.score = 0;
		globals.time = 0;
		playpew = gameObject.AddComponent<AudioSource>() as AudioSource;

	}

	void FixedUpdate () {

		if(isMobile){
			Quaternion deviceRotation = PlayerControls.DeviceRotation.Get();
			Quaternion referenceRotation = Quaternion.identity;
			Quaternion eliminationOfXY = Quaternion.Inverse(
				Quaternion.FromToRotation(referenceRotation * Vector3.forward, 
			                          deviceRotation * Vector3.forward)
				);
			Quaternion rotationZ = eliminationOfXY * deviceRotation;
			if(canRotate){
				transform.rotation = new Quaternion(rotationZ.x,rotationZ.y,-rotationZ.z,rotationZ.w);
			}
		} else {
			var mouse = Input.mousePosition;
			var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
			var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
			var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
			if(canRotate){
				transform.rotation = Quaternion.Euler(0, 0, angle-90);
			}
		}

	}

	public void Right(GameObject bullet) {
		if (transform.gameObject.name == "RightGun") {
			Instantiate (bullet, transform.position + new Vector3 (0, 0, 1f), transform.rotation);
			playpew.PlayOneShot (pewpew);
		}
	}
	public void Left(GameObject bullet) {
		if (transform.gameObject.name == "LeftGun") {
			Instantiate (bullet, transform.position + new Vector3 (0, 0, 1f), transform.rotation);
			playpew.PlayOneShot (pewpew);
		}
	}



}
