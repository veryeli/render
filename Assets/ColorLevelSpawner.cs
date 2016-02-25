using UnityEngine;
using System.Collections;

public class ColorLevelSpawner : MonoBehaviour {

	public GameObject pickup;
	public GameObject portal;
	public GameObject shower;
	public int level;
	public static int numberOfObjects = 20;
	public float radius = 7f;
	public static string[] primaries = new string[]{"yellow", "magenta", "cyan"};

	// Use this for initialization
	void Start () {
		print (level);
		if (level == 1) {
			SpawnFirstRoom ();
		}
		if (level == 2) {
			SpawnShowerRoom ();
		}
		if (level == 3) {
			SpawnSecondShowerRoom ();
		}
		if (level == 4 || level == 0) {
			SpawnFirstRoom ();
			SpawnRedRoom ();
			SpawnGreenRoom ();
			SpawnBlueRoom ();
			SpawnWinRoom ();
		}
		if (level == 5 || level == 0) {
			SpawnFirstRoom ();
			SpawnRedRoom ();
			SpawnGreenRoom ();
			SpawnBlueRoom ();
			SpawnWinRoom ();
		}
	
	}

	void SpawnFirstRoom() {
		GameObject[] pickups = SpawnPickUps(new string[]{"cyan"}, 0);
		SpawnPortal ("cyan", 0, pickups);
	}
	void SpawnShowerRoom() {
		SpawnPickupCircle ("magenta");
		SpawnPortal ("white", 0, new GameObject[]{});
	}
	void SpawnSecondShowerRoom() {
		SpawnFirstRoom ();
		SpawnPickupCircle ("magenta");
	}
	void SpawnRedRoom() {
		int offset = 20;
		GameObject[] pickups = SpawnPickUps(primaries, offset);
		SpawnPortal ("red", offset, pickups);
	}
	void SpawnGreenRoom() {
		int offset = 40;
		GameObject[] pickups = SpawnPickUps(primaries, offset);
		SpawnPortal ("green", offset, pickups);
	}
	void SpawnBlueRoom() {
		int offset = 60;
		GameObject[] pickups = SpawnPickUps(primaries, offset);
		SpawnPortal ("blue", offset, pickups);
	}
	void SpawnWinRoom() {
		int offset = 80;
		GameObject[] pickups = SpawnPickUps(primaries, offset);
		SpawnPortal ("black", offset, pickups);
	}

	GameObject[] SpawnPickUps(string[] puColors, float zOffset) {
		GameObject[] pickups;
		pickups = new GameObject[puColors.Length];

		for (int i = 0; i < puColors.Length; i++) {
			Vector3 pos = new Vector3(4 * (puColors.Length / 2 - i), 0.5f, zOffset + 4);
			GameObject pu = (GameObject) Instantiate(pickup, pos, Quaternion.identity);
			pu.GetComponent<ColorManager>().addColor(puColors[i]);
			pickups [i] = pu;
		}

		return pickups;
	}

	void SpawnPickupCircle(string color) {
		numberOfObjects = 16;
		for (int i = 0; i < numberOfObjects; i++) {
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			pickup.transform.position = transform.position; 
			Vector3 pos = new Vector3(Mathf.Cos(angle), 0.5f, Mathf.Sin(angle)) * 2; // original line
			GameObject show = (GameObject) Instantiate(pickup , pos, Quaternion.identity);
			show.GetComponent<ColorManager>().addColor(color);
		}

	}

	void SpawnPortal(string color, float zOffset, GameObject[] pickups) {
		Vector3 showerPos = new Vector3(5f, 0.0f, zOffset + 9);
		GameObject showerObject = (GameObject) Instantiate(shower, showerPos, new Quaternion(0, 210, 0, 0));
		showerObject.GetComponent<Shower>().setPickups (pickups);

		Vector3 pos = new Vector3(0, 0.5f, zOffset + 10);
		GameObject portalObject = (GameObject) Instantiate(portal, pos, Quaternion.identity);
		portalObject.GetComponent<ColorManager>().addColor(color);
		portalObject.GetComponent<Portal>().setPickups (pickups);
		portalObject.GetComponent<Portal> ().shower = showerObject;
	}

}
