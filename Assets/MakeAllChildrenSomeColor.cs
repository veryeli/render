using UnityEngine;
using System.Collections;

public class MakeAllChildrenSomeColor : MonoBehaviour {

	// Use this for initialization
	void Start () {

		foreach (Renderer child in GetComponentsInChildren(typeof(Renderer))) {
			child.material.color = new Color (1, 0, 0);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
