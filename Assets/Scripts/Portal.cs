using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	private GameObject[] pickups;
	public GameObject shower;
	public string portalType = "normal";

	// very enterprise
	public void setPickups (GameObject[] p) {
		pickups = p;
	}


	public void deleteAssociatedObjects () {
		for (int i = 0; i < pickups.Length; ++i) {
			GameObject pickupObject = pickups [i];
			pickupObject.SetActive (false);
		}

		shower.SetActive (false);
	}
		
}
