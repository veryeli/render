using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour
{

	public string color = "white";
	private Renderer rend;
	public Color white = new Color(1.0f, 1.0f, 1.0f);
	public Color black = new Color(0.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.material.color = currentColor ();
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
		case "bluegreen":
			return "cyan";
		case "greenred":
			return "yellow";
		case "cyanmagenta":
			return "blue";
		case "magentayellow":
			return "red";
		case "cyanyellow":
			return "green";
		case "cyanred":
			return "black";
		case "greenmagenta":
			return "black";
		case "blueyellow":
			return "black";
		default:
			return name;
		}
	}

	static string subtractiveColorName (string name)
	{
		print ("mushy subtractive name " + name);
		switch (name) {
		case "blackred":
			return "cyan";
		case "blackgreen":
			return "magenta";
		case "blackblue":
			return "yellow";
		case "blackcyan":
			return "red";
		case "blackmagenta":
			return "green";
		case "blackyellow":
			return "blue";
		case "cyangreen":
			return "magenta";
		case "cyanblue":
			return "yellow";
		case "redyellow":
			return "cyan";
		case "greenyellow":
			return "magenta";
		case "magentared":
			return "cyan";
		case "bluemagenta":
			return "yellow";
		case "greenmagenta":
			return "white";
		case "cyanred":
			return "white";
		case "blueyellow":
			return "white";
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
			return colorName (two + one);
		}

	}

	static string subtractiveComboFor (string one, string two)
	{
		if (one == two) {
			return two;
		} 
		else if (two == "white" || one == "white") {
			return "white";
		} else if (string.Compare (one, two) < 0) {
			return subtractiveColorName (one + two);
		} else {
			return subtractiveColorName (two + one);
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
		rend = GetComponent<Renderer>();
		color = newColor;
		rend.material.color = currentColor ();
	}
}