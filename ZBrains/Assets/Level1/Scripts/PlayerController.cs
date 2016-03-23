﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	public bool paused = false;
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () 
	{
		// If screen is tapped more than once in a frame
		if (Input.touches[0].tapCount == 2) {
			// Check if game is paused already
			if (paused == false) {
				// set paused flag 
				paused = true;
				// pause game
				Time.timeScale = 0;
			} else {
				// reset paused flag
				paused = false;
				// continue game
				Time.timeScale = 1;
			}
		}
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = Input.acceleration.y;
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
		if (Input.GetKeyDown (KeyCode.Escape)) // on return go to Main Menu
		{
			SceneManager.LoadScene("MainMenu");
		}

	}
}
