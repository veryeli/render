using UnityEngine;
using System.Collections;

public class MakeAllChildrenSomeColor : MonoBehaviour {

	public void SetColor(Color c) {
		foreach (Renderer child in GetComponentsInChildren(typeof(Renderer))) {
			if (child.sharedMaterial) {
				child.sharedMaterial.color = c;
			}
		}
	}
}
