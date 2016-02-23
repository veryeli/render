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

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		SetText();
		winText.text = "";
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
			
		Vector3 movement = new Vector3 (moveHorizontal, moveUp, moveVertical) * speed;
		rb.AddForce (movement);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("pickup")) {
			other.gameObject.SetActive (false);
			score++;
			SetText();
			addColor(other.gameObject);
		}
		if (other.gameObject.CompareTag ("portal")) {
			if (matchesPortalColor()) {
				other.gameObject.SetActive (false);
			}
		}
	}

	void addColor(GameObject other) 
	{
		if (colorAddMode) {
			AddColor(colorOf(other));
		}
		else {
			AddColor(-1 * colorOf(other));
		}
	}

	Color colorOf(GameObject other) {
		return other.GetComponent<Renderer>().material.color;;
	}

	bool matchesPortalColor() {
		return colorOf (portal).Equals(rend.material.color);
	}

	void AddColor(Color otherColor) {
		rend.material.color += otherColor;
		Color c = rend.material.color;
		rend.material.color = new Color (
			(c.r >= 0) ? c.r : 0,
			c.g,
			c.b
		);
	}

	void SetText()
	{
		scoreText.text = "Score: " + score.ToString ();
		if (score >= PickUpSpawner.numberOfObjects) {
			winText.text = "You Win";
		}
	}
}