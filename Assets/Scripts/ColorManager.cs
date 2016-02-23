using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour {

	public Renderer renderer;
	public Color color;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
	}

	void setColor(Color c) {
		renderer.material.color = c;
	}

	Color getColor () {
		return renderer.material.color;
	}
}
