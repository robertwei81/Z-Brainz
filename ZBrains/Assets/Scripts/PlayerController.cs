using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	public bool paused = false;
	public Sprite openedDoor;
	private int count;
	public Text pauseText;
	public Text countText;
	private int starting_count;
	static public int difficultyTimeVar=3;// default factor is 3*
	//------------timer variables ----------------
	public System.Timers.Timer LeTimer;
	private int BoomDown = difficultyTimeVar*100;
	//--------------------------------------------
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		pauseText.text = "";
		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			starting_count = 6;
		}
		if (SceneManager.GetActiveScene ().buildIndex == 3) {
			starting_count = 10;
		}
		if (SceneManager.GetActiveScene ().buildIndex == 4) {
			starting_count = 10;
		}
		setCountText ();
		//--------------------------------------------------------------------------
		//Initialize timer with 1 second intervals
		LeTimer = new System.Timers.Timer (1000);
		LeTimer.Elapsed +=
			//This function decreases BoomDown every second
			(object sender, System.Timers.ElapsedEventArgs e) => BoomDown--;
		//--------------------------------------------------------------------------
	}

	void setCountText(){
		countText.text = "Brainzzz Remaining: " + (starting_count - count).ToString();
	}
	void Update(){
		// check for pausing here instead of FixedUpdate bec. it doesn't call FixedUpdate after pausing
		foreach(Touch touch in Input.touches){
			if (touch.tapCount == 2) 
			{
				print ("Double tapped!" + touch.tapCount); //testing purposes 
				if (paused) {
					Time.timeScale = 0f;
					pauseText.text = "PAUSED";
				} else {
					Time.timeScale = 1f;
					pauseText.text = "";
				}
				paused = !paused;
			}
		}
		//-------------------------------------

		if (BoomDown <= 0) {
			//set text for timer here
			//then pause the game; 
			//2 options here, tap screen to restart
			//tap screen to main menu ; bob favors restart the level
			Debug.Log ("Boom!");//this is just an example
		} else {
			//set text for timer here
		}
		//-------------------------------------
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = Input.acceleration.y;
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
		if (Input.GetKeyDown (KeyCode.Escape)) // on return go to Main Menu
		{
			SceneManager.LoadScene("Level2");
		}
	} // end FixedUpdate

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Car")) 
		{
			transform.position = new Vector3(-21.68f, 12.85f, 0);
		}

		if (other.gameObject.CompareTag ("Door") && count == 6 && SceneManager.GetActiveScene().buildIndex == 2) 
		{
			other.gameObject.GetComponent<SpriteRenderer> ().sprite = openedDoor;
			SceneManager.LoadScene("Level2");
		}

		if (other.gameObject.CompareTag ("Door") && count == 10 && SceneManager.GetActiveScene().buildIndex == 3) 
		{
			other.gameObject.GetComponent<SpriteRenderer> ().sprite = openedDoor;
			SceneManager.LoadScene("Level3");
		}

		if (other.gameObject.CompareTag ("Door") && count == 10 && SceneManager.GetActiveScene().buildIndex == 4) 
		{
			other.gameObject.GetComponent<SpriteRenderer> ().sprite = openedDoor;
			SceneManager.LoadScene("MainMenu");
		}

		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText ();
		}
			
	} //end OnTriggerEnter2D

}
