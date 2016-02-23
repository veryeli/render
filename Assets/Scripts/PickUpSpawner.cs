using UnityEngine;
using System.Collections;

public class PickUpSpawner : MonoBehaviour {
	public GameObject pickup;
	public static int numberOfObjects = 20;
	public float radius = 7f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfObjects; i++) {
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3(Mathf.Cos(angle), 0.5f / radius, Mathf.Sin(angle)) * radius;
			GameObject pu = (GameObject) Instantiate(pickup, pos, Quaternion.identity);
			Renderer rend = pu.GetComponent<Renderer>();
			rend.material.color = new Color (i / (float) numberOfObjects, 0, 0, 1);
		}
	}
}
