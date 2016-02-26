using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	private Rigidbody rb;
	public float speed;
	private string colorAddMode = "add";
	public GameObject portal;
	public ColorManager cm;
	public AudioClip collectSound;
	public AudioClip portalSound;
	public AudioClip boomSound;
	public AudioClip showerSound;

	// Use this for initialization
	public void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveUp = 0f;
		if (Input.GetButton ("Jump")) {
			moveUp = 1f;
		}
		if (Input.GetButtonDown ("Jump")) {
			ToggleColorMode ();
		}


		Vector3 movement = new Vector3 (moveHorizontal, moveUp, moveVertical) * speed;
		rb.AddForce (movement);
	}

	public void ToggleColorMode ()
	{
		colorAddMode = (colorAddMode == "add") ? "subtract" : "add";
	}

	public bool getColorAddMode ()
	{
		return colorAddMode == "add";
	}

	public void ResetColor ()
	{
		if (getColorAddMode ()) {
			cm.setColor ("white");
		} else {
			cm.setColor ("black");
		}
		;
	}

	IEnumerator OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("showermat")) {
			ResetColor ();
			AudioSource.PlayClipAtPoint(showerSound, transform.position);
			GameObject showerObject = other.gameObject.transform.parent.gameObject;
			showerObject.GetComponent<Shower> ().resetAssociatedObjects ();
			yield break;
		}
//		if (other.gameObject.CompareTag ("winportal")) {
//			AudioSource.PlayClipAtPoint(portalSound, transform.position);
//			yield return GameObject.Find ("GM").GetComponent<Fading> ().LoadNextLevel ();
//		}
			

		if (other.gameObject.CompareTag ("pickup")) {
			string otherColor = other.gameObject.GetComponent<ColorManager> ().color;
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
			other.gameObject.SetActive (false);
			if (getColorAddMode ()) {
				cm.addColor (otherColor);
			} else {
				cm.subtractColor (otherColor);
			}
		}
		if (other.gameObject.CompareTag ("portal")) {
			string otherColor = other.gameObject.GetComponent<ColorManager> ().color;
			if (cm.color == otherColor) {
				AudioSource.PlayClipAtPoint (portalSound, transform.position);
				GameObject portalObject = other.gameObject;
				portalObject.GetComponent<Portal> ().deleteAssociatedObjects ();
				portalObject.SetActive (false);
				ResetColor ();
				if (portalObject.GetComponent<Portal> ().portalType == "win") {
					AudioSource.PlayClipAtPoint(portalSound, transform.position);
					yield return GameObject.Find ("GM").GetComponent<Fading> ().LoadNextLevel ();
				}
			} else {
				AudioSource.PlayClipAtPoint(boomSound, transform.position);
			}
		}
	}
}