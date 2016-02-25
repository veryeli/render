using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private bool colorAddMode = true;
	public GameObject portal;
	public ColorManager cm;

	// Use this for initialization
	void Start () {
		colorAddMode = true;
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveUp = 0f;
		if (Input.GetButton("Jump")) {
			moveUp = 1f;
		}
		if (Input.GetButtonDown("Jump")) {
			ToggleColorMode();
		}


		Vector3 movement = new Vector3 (moveHorizontal, moveUp, moveVertical) * speed;
		rb.AddForce (movement);
	}

	public void ToggleColorMode() {
		colorAddMode = !colorAddMode;
	}

	public bool getColorAddMode() {
		return colorAddMode;
	}

	void ResetColor() {
		if (colorAddMode) {
			cm.setColor ("white");
		} else {
			cm.setColor ("black");
		}
	}

	IEnumerator OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("showermat")) {
			ResetColor();
			GameObject showerObject = other.gameObject.transform.parent.gameObject;
			showerObject.GetComponent<Shower>().resetAssociatedObjects ();
			yield break;
		}
		if (other.gameObject.CompareTag ("winportal")) {
			yield return GameObject.Find ("GM").GetComponent<Fading> ().LoadNextLevel();
		}
			

		if (other.gameObject.CompareTag ("pickup")) {
			string otherColor = other.gameObject.GetComponent<ColorManager> ().color;
			other.gameObject.SetActive (false);
			print ("Just bumped into a yummy snack...");
			print (cm.color);
			print (otherColor);
			print (colorAddMode);
			if (colorAddMode) {
				cm.addColor (otherColor);
			} else {
				cm.subtractColor (otherColor);
			}
		}
		if (other.gameObject.CompareTag ("portal")) {
			string otherColor = other.gameObject.GetComponent<ColorManager> ().color;
//			print("bumped into a portal");
			if (cm.color == otherColor) {
				GameObject portalObject = other.gameObject;
				portalObject.GetComponent<Portal>().deleteAssociatedObjects ();
				portalObject.SetActive (false);
				ResetColor ();
			}
		}
	}
}