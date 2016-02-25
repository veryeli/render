using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


//	public Transform target;
//	public float damp = 0.2f;
//	public float distance = 50;
//
//	void Update(){
//
//		damp = Mathf.Clamp(damp, 0.01f, 10f); // clamps damping factor
//		Vector3 pCam = transform.position;
//		Vector3 pTarget = target.position;
//		Vector3 diff = pTarget - pCam;  // diff = difference between positions
//		float dist = diff.magnitude;  // dist = distance between them
//		if (Mathf.Abs(diff.y) < 0.7 * distance){
//			diff.y = 0;  // doesn't modify camera height unless angle > 45
//		} 
//		if (dist>distance){ // if distance too big...
//			diff *= 1-distance/dist; // diff = position error
//			// move a FPS independent little step towards the ideal position
//			transform.position = pCam + diff * Time.deltaTime/damp;
//		}
//		transform.LookAt(pTarget);
//	}
//}
	public GameObject player;
	public Camera cam;
	private Vector3 offset;
	public bool colorAddMode;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		cam = GetComponent<Camera>();
		cam.clearFlags = CameraClearFlags.SolidColor;
	}

	void Update() {
		bool colorAddMode = player.GetComponent<PlayerController>().colorAddMode;

		if (colorAddMode) {
			cam.backgroundColor = Color.white;
		}
		else {
			cam.backgroundColor = Color.black;
		}
	}

	// LateUpdate is called once per frame
	void LateUpdate () {
		transform.position = player.transform.transform.position + offset;
	}
}



// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
//
//using UnityEngine;
//using System.Collections;
//
//public class CameraController : MonoBehaviour
//{
//	/*
//     This camera smoothes out rotation around the y-axis and height.
//     Horizontal Distance to the target is always fixed.
//     
//     There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.
//     
//     For every of those smoothed values we calculate the wanted value and the current value.
//     Then we smooth it using the Lerp function.
//     Then we apply the smoothed values to the transform's position.
//     */
//
//	// The target we are following
//	public Transform target;
//	// The distance in the x-z plane to the target
//	public float distance = 10.0f;
//	// the height we want the camera to be above the target
//	public float height = 5.0f;
//	// How much we 
//	public float heightDamping = 2.0f;
//	public float rotationDamping = 3.0f;
//
//	void  LateUpdate ()
//	{
//		// Early out if we don't have a target
//		if (!target)
//			return;
//
//		// Calculate the current rotation angles
//		float wantedRotationAngle = target.eulerAngles.y;
//		float wantedHeight = target.position.y + height;
//		float currentRotationAngle = transform.eulerAngles.y;
//		float currentHeight = transform.position.y;
//
//		// Damp the rotation around the y-axis
//		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
//
//		// Damp the height
//		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
//
//		// Convert the angle into a rotation
//		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
//
//		// Set the position of the camera on the x-z plane to:
//		// distance meters behind the target
//		transform.position = target.position;
//		transform.position -= currentRotation * Vector3.forward * distance;
//
//		// Set the height of the camera
//		transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
//
//		// Always look at the target
//		transform.LookAt (target);
//	}
//}