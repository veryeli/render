using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int score;
	public Text scoreText;
	public Text winText;
	public Renderer rend;
	public bool colorAddMode;
	public GameObject portal;
	public ColorManager cm;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		rend = GetComponent<Renderer>();
		colorAddMode = true;
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
			colorAddMode = !colorAddMode;
		}

		cm.setColor (cm.color);
			
		Vector3 movement = new Vector3 (moveHorizontal, moveUp, moveVertical) * speed;
		rb.AddForce (movement);
	}

	IEnumerator OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("shower")) {
			cm.setColor ("white");
			yield break;
		}
		if (other.gameObject.CompareTag ("winportal")) {
			yield return GameObject.Find ("GM").GetComponent<Fading> ().LoadNextLevel();
		}
			string otherColor = other.gameObject.GetComponent<ColorManager> ().color;
		if (other.gameObject.CompareTag ("pickup")) {
			other.gameObject.SetActive (false);
			score++;
//			print ("Just bumped into a yummy snack...");
//			print (cm.color);
//			print (otherColor);
			cm.addColor(otherColor);
		}
		if (other.gameObject.CompareTag ("portal")) {
//			print("bumped into a portal");
			if (cm.color == otherColor) {
				GameObject portalObject = other.gameObject;
				portalObject.GetComponent<Portal>().deleteAssociatedObjects ();
				portalObject.SetActive (false);
				cm.setColor ("white");
			}
		}
	}
}