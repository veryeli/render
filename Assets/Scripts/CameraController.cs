using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {



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