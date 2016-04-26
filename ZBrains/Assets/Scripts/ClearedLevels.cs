using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClearedLevels : MonoBehaviour {

	public Texture background;
	public Game current = SaveLoad.savedGame;
	public bool lvl1, lvl2, lvl3, lvl4, lvl5;
	public string button1, button2, button3, button4, button5;
	void OnGUI(){
		// Load saved game data
		//SaveLoad.Load (); causing bug , will fix later
		// Get cleared level values
		lvl1 = current.levelOne;
		lvl2 = current.levelTwo;
		lvl3 = current.levelThree;
		lvl4 = current.levelFour;
		lvl5 = current.levelFive;
		// Set button strings
		button1 = "Play level 1.";
		if (lvl1 == true) {
			button2 = "Play level 2.";
		} else {
			button2 = "Level 1 is not cleared.";
		}
		if (lvl2 == true) {
			button3 = "Play level 3.";
		} else {
			button3 = "Level 2 is not cleared.";
		}
		if (lvl3 == true) {
			button4 = "Play level 4.";
		} else {
			button4 = "Level 3 is not cleared.";
		}
		if (lvl4 == true) {
			button5 = "Play level 5.";
		} else {
			button5 = "Level 4 is not cleared.";
		}
		// display background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);

		// Create Level One cleared button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .35f, Screen.width * .3f, Screen.height * .1f), button1)) {
			// Start level 1 when clicked.
			SceneManager.LoadScene("Level1");
		}
		// Create level two cleared button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .45f, Screen.width * .3f, Screen.height * .1f), button2)) {
			// Start level 2 when clicked if level 1 is cleared.
			if (lvl1 = true) {
				SceneManager.LoadScene ("Level2");
			}
		}
		// Create level three cleared button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .55f, Screen.width * .3f, Screen.height * .1f), button3)) {
			// Start level 3 when clicked if level 2 is cleared.
			if (lvl2 == true) {
				SceneManager.LoadScene("Level3");
			}
		}
		// Create level four cleared button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .65f, Screen.width * .3f, Screen.height * .1f), button4)) {
			// Start level 4 when clicked if level 3 is cleared.
			if (lvl3 == true) {
				SceneManager.LoadScene ("Level4");
			}
		}
		// Create level five cleared button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .75f, Screen.width * .3f, Screen.height * .1f), button5)) {
			// Start level 5 when clicked if level 4 is cleared.
			if (lvl4 == true) {
				SceneManager.LoadScene ("Level5");
			}
		}
		// Create reset cleared levels button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .85f, Screen.width * .3f, Screen.height * .1f), "Reset Cleared Levels")) {
			// Reset cleared level values and reload the scene
			current.levelOne = false;
			current.levelTwo = false;
			current.levelThree = false;
			current.levelFour = false;
			current.levelFive = false;
			SceneManager.LoadScene ("ClearedLevels");
		}

	}
	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) // on return exit game
		{
			SceneManager.LoadScene ("MainMenu");
		}
	}
}
