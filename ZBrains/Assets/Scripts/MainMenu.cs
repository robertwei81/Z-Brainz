﻿/// <summary>
/// Main menu.
/// Attached to Main Camera
/// </summary>

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Texture splashScreenBackground;
	public Texture backgroundTexture; // public so you can drag background image on unity

	void OnGUI(){
		// display background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), splashScreenBackground);
		// after 3 seconds, display Game Name
		if (Time.time > 1f) 
		{
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		}


		if (Time.time > 2f) {
			// Create "Start Game" button
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .65f, Screen.width * .3f, Screen.height * .1f), "Start Game")) {
				// Change scene to "Level1" when this button is clicked.
				SceneManager.LoadScene ("Level1");
			}
		}


		if (Time.time > 2.5f) {
			// Create "Exit Game" button
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .75f, Screen.width * .3f, Screen.height * .1f), "Exit Game")) {
				// Exit application when button is clicked.
				Application.Quit ();
			}
		}

		//wait for 5 seconds before displaying the buttons
		if (Time.time > 3f) {
			// help button
			if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .85f, Screen.width * .3f, Screen.height * .1f), "Help")) {
				SceneManager.LoadScene ("HelpFile");  // change scene based on name
			}
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