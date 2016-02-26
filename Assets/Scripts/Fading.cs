using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {


	public Texture2D startTexture;// Will overlay scene
	public Texture2D secondSceneTexture;// Will overlay scene
	public Texture2D thirdSceneTexture;// Will overlay scene
	public Texture2D fourthSceneTexture;// Will overlay scene
	public Texture2D fifthSceneTexture;// Will overlay scene
	public Texture2D finalTexture;// Will overlay scene
	public float fadeSpeed = 0.3f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1; //-1 is fading in, 1 is fading out
	public int level = 1;

	void OnGUI () {
		if (level != 6) {
			// fade in and out alpha
			alpha += fadeDir * fadeSpeed * Time.deltaTime;
		}
		// clamp value from 0-1
		alpha = Mathf.Clamp01(alpha);

		//set gui color
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		Texture2D texture = currentTexture ();
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), texture);
	}

	// sets fadeDir to the direction parameter
	public float BeginFade (int direction) {
		fadeDir = direction;
		return (fadeSpeed);  // do this to time Application.LoadLevel
	}
		

	Texture2D currentTexture() {
		switch (level) {
		case 1:
			return startTexture;
		case 2:
			return secondSceneTexture;
		case 3:
			return thirdSceneTexture;
		case 4:
			return fourthSceneTexture;
		case 5:
			return fifthSceneTexture;
		default:
			return finalTexture;
		}
	}

	public IEnumerator LoadNextLevel() {
		BeginFade (-1);
		yield return new WaitForSeconds (.2f);
		SceneManager.LoadScene ("Level" + (level + 1));
		yield return new WaitForSeconds (3);
	}
}
