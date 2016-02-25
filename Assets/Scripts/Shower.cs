using UnityEngine;
using System.Collections;

public class Shower : MonoBehaviour {

	private GameObject[] pickups;

	// very enterprise
	public void setPickups (GameObject[] p) {
		pickups = p;
	}

	public void resetAssociatedObjects () {
		for (int i = 0; i < pickups.Length; ++i) {
			GameObject pickupObject = pickups [i];
			pickupObject.SetActive (true);
		}
	}

}
