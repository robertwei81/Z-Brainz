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
		// help button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .85f, Screen.width * .3f, Screen.height * .1f), "Help")) 
		{
			SceneManager.LoadScene("HelpFile");  // change scene based on name
		}
		// Create "Start Game" button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .6f, Screen.width * .3f, Screen.height * .1f), "Start Game")) 
		{
			// Change scene to "Level1" when this button is clicked.
			SceneManager.LoadScene("Level1");
		}
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) // on return exit game
		{
			Application.Quit ();
		}
	}

		
}
