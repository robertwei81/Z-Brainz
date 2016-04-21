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
		if (lvl1 == true) {
			button1 = "Level 1 - Cleared";
		} else {
			button1 = "Level 1 - Not Cleared";
		}
		if (lvl2 == true) {
			button2 = "Level 2 - Cleared";
		} else {
			button2 = "Level 2 - Not Cleared";
		}
		if (lvl3 == true) {
			button3 = "Level 3 - Cleared";
		} else {
			button3 = "Level 3 - Not Cleared";
		}
		if (lvl4 == true) {
			button4 = "Level 4 - Cleared";
		} else {
			button4 = "Level 4 - Not Cleared";
		}
		if (lvl5 == true) {
			button5 = "Level 5 - Cleared";
		} else {
			button5 = "Level 5 - Not Cleared";
		}
		// display background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);

		// Create Level One cleared button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .35f, Screen.width * .3f, Screen.height * .1f), button1)) {
			// Change scene to "Level1" when this button is clicked.
			//SceneManager.LoadScene ("Level 1");
		}
		// Create level two cleared button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .45f, Screen.width * .3f, Screen.height * .1f), button2)) {
			// Change scene to "Level1" when this button is clicked.
			//SceneManager.LoadScene ("Level 1");
		}
		// Create level three cleared button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .55f, Screen.width * .3f, Screen.height * .1f), button3)) {
			// Change scene to "Level1" when this button is clicked.
			//SceneManager.LoadScene ("Level 1");
		}
		// Create level four cleared button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .65f, Screen.width * .3f, Screen.height * .1f), button4)) {
			// Change scene to "Level1" when this button is clicked.
			//SceneManager.LoadScene ("Level 1");
		}
		// Create level five cleared button
		if (GUI.Button (new Rect (Screen.width * .35f, Screen.height * .75f, Screen.width * .3f, Screen.height * .1f), button5)) {
			// Change scene to "Level1" when this button is clicked.
			//SceneManager.LoadScene ("Level 1");
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
