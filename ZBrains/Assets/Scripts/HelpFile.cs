/// <summary>
/// Help file.
/// Attached to Help Camera
/// </summary>


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HelpFile : MonoBehaviour {

	public Texture backgroundTexture; // public so you can drag background image on unity

	public Texture Help0;
	public Texture Help1;
	public Texture Help2;
	public Texture Help3;

	private int index = 0;

	private Texture[] HelpSlides = new Texture[4];

	public enum SwipeDirection{Up,Down,Right,Left,Stayput}

	//public static event Action<SwipeDirection> Swipe;
	public static SwipeDirection Swipe;
	private bool swiping = false;
	private bool eventSent = false;
	private Vector2 LastPosition;

	void OnGUI(){
		// assignment should be outside of this and should be static
		HelpSlides [0] = Help0;
		HelpSlides [1] = Help1;
		HelpSlides [2] = Help2;
		HelpSlides [3] = Help3;

		// display background texture
		backgroundTexture = HelpSlides[index];
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
	}

	void Update(){
		int duration = 5;
		if (Input.touchCount==0) 
			return;
		if (Input.GetTouch (0).deltaPosition.sqrMagnitude != 0) {
			if (swiping == false) {
				swiping = true;
				LastPosition = Input.GetTouch (0).position;
			} else {
				if (!eventSent) {
					if (Swipe != null) {
						Vector2 direction = Input.GetTouch (0).position - LastPosition;
						if (Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) {
							if (direction.x > duration) {
								direction.Set (0, 0); //reset value to zero so that it stops sliding
								Swipe = SwipeDirection.Right;
								SlideRight ();
							} else {
								direction.Set (0, 0); //reset value to zero so that it stops sliding
								Swipe = SwipeDirection.Left;
								SlideLeft ();
							}
						} else {
							if (direction.y > duration) {
								direction.Set (0, 0); //reset value to zero so that it stops sliding
								Swipe = SwipeDirection.Up;
							} else {
								direction.Set (0, 0); //reset value to zero so that it stops sliding
								Swipe = SwipeDirection.Down;
							}

						}
						eventSent = true;
					}
				}
			}
		} 
		else {
			swiping = false;
			eventSent = false;
		}
	}


	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.Escape)) { // on return go to Main Menu
			SceneManager.LoadScene("MainMenu");
		}
	}

	void SlideLeft(){
		if (index < 3)
			index = index + 1;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), HelpSlides[index]);
	}
	void SlideRight(){
		if (index > 0)
			index = index - 1;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), HelpSlides[index]);
	}
}

/*
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HelpFile : MonoBehaviour {

	public Texture backgroundTexture; // public so you can drag background image on unity

	void OnGUI(){
		// display background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
	}

	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.Escape)) // on return go to Main Menu
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}
*/