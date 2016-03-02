/// <summary>
/// Main menu.
/// Attached to Main Camera
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture; // public so you can drag background image on unity

	void OnGUI(){
		// display background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .9f, Screen.width * .3f, Screen.height * .1f), "Help")) 
		{
			print("Clicked!"); // testing purposes
			SceneManager.LoadScene("HelpFile");  // change scene based on name
		}
			
	}

		
}
