using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour
{

	public string color = "white";
	private Renderer rend;
	public GameObject stuff;
	public Color white = new Color(1.0f, 1.0f, 1.0f);
	public Color black = new Color(0.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
		setColor (color);
	}

	public void addColor (string c)
	{
		setColor(colorComboFor (color, c));
	}

	public void subtractColor (string c)
	{
		setColor(subtractiveComboFor (color, c));
	}

	static string colorName (string name)
	{
//		print ("mushy name " + name);
		switch (name) {
		case "bluered":
			return "magenta";
		case "redblue":
			return "magenta";
		case "bluegreen":
			return "cyan";
		case "greenblue":
			return "cyan";
		case "greenred":
			return "yellow";
		case "redgreen":
			return "yellow";
		case "cyanmagenta":
			return "blue";
		case "magentacyan":
			return "blue";
		case "magentayellow":
			return "red";
		case "yellowmagenta":
			return "red";
		case "cyanyellow":
			return "green";
		case "yellowcyan":
			return "green";
		case "cyanred":
			return "black";
		case "redcyan":
			return "black";
		case "greenmagenta":
			return "black";
		case "magentagreen":
			return "black";
		case "blueyellow":
			return "black";
		case "yellowblue":
			return "black";
		default:
			return name;
		}
	}

	// (Actually additive lol)
	static string subtractiveColorName (string name)
	{
		print ("mushy subtractive name " + name);
		switch (name) {
		case "whitered":
			return "cyan";
		case "whitegreen":
			return "magenta";
		case "whiteblue":
			return "yellow";
		case "cyanred":
			return "cyan";
		case "magentared":
			return "blue";
		case "yellowred":
			return "green";
		case "cyangreen":
			return "blue";
		case "magentagreen":
			return "magenta";
		case "yellowgreen":
			return "red";
		case "cyanblue":
			return "green";
		case "magentablue":
			return "red";
		case "yellowblue":
			return "yellow";
		default:
			return name;
		}

	}

	static string colorComboFor (string one, string two)
	{
		if (one == "white" || one == two) {
			return two;
		} else if (two == "white") {
			return one;
		} else if (string.Compare (one, two) < 0) {
			return colorName (one + two);
		} else {
			return colorName (one + two);
		}

	}

	static string subtractiveComboFor (string one, string two)
	{
		if (one == two || one == "black" || two == "white") {
			return "black";
		} else if (two == "black") {
			return one;
		} else {
			return subtractiveColorName (one + two);
		}

	}

	Color currentColor ()
	{
		switch (color) {
		case "red":
			return new Color(1f, 36.0f/255.0f, 31.0f/255.0f);
		case "green":
			return new Color(55.0f/255.0f,  186.0f/255.0f, 51.0f/255.0f);
		case "blue":
			return new Color(18.0f/255.0f,  123.0f/255.0f, 242.0f/255.0f);
		case "cyan":
			return new Color(0.0f, 1.0f, 1.0f);
		case "magenta":
			return new Color(1.0f, 0.0f, 1.0f);
		case "yellow":
			return new Color(1.0f, 1.0f, 0.0f);
		case "black":
			return new Color(73.0f/255.0f,  73.0f/255.0f, 73.0f/255.0f);
		default:
			return white;
		}
	}
		
	public void setColor(string newColor) {
		if (!rend) {
			rend = GetComponent<Renderer> ();
		}
		color = newColor;
		rend.material.color = currentColor ();
		if (stuff) {
			stuff.GetComponent<MakeAllChildrenSomeColor> ().SetColor (currentColor ());
		}
	}

}