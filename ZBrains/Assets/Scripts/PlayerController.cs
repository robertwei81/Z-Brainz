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
	public Text timeText;
	private int starting_count;
	static public int difficultyTimeVar=3;// default factor is 3*
	private bool isPaused;
	public Vector3 pointRestart;
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
		if (SceneManager.GetActiveScene ().buildIndex == 5) {
			starting_count = 10;
		}
		if (SceneManager.GetActiveScene ().buildIndex == 6) {
			starting_count = 10;
		}
		setTimeText ();
		setCountText ();
		isPaused = false;
		//--------------------------------------------------------------------------
		//Initialize timer with 1 second intervals
		LeTimer = new System.Timers.Timer (1000);
		LeTimer.Elapsed +=
			//This function decreases BoomDown every second
			(object sender, System.Timers.ElapsedEventArgs e) => BoomDown--;
		//--------------------------------------------------------------------------
	}

	void setCountText(){
		countText.text = "Brains Left: " + (starting_count - count).ToString();
	}
	void setTimeText(){
		timeText.text = "Time: " + (BoomDown).ToString ();
	}
	void Update(){

		//-------------------------------------
		setTimeText();
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


	void OnGUI(){
		// show pause button when isPaused is false
		if (!isPaused) {
			if (GUI.Button (new Rect (Screen.width * .87f, Screen.height * .01f, Screen.width * .1f, Screen.height * .1f), "||")) {
				isPaused = true;
				Time.timeScale = 0f;
				pauseText.text = "PAUSED";
			}
		}

		// show start button when isPaused is true
		else {
			if (GUI.Button (new Rect (Screen.width * .87f, Screen.height * .01f, Screen.width * .1f, Screen.height * .1f), "►")) {
				isPaused = false;
				Time.timeScale = 1f;
				pauseText.text = "";
			}
		}
	}


	void FixedUpdate () 
	{
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = Input.acceleration.y;
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
		if (Input.GetKeyDown (KeyCode.Escape)) // on return go to Main Menu
		{
			SceneManager.LoadScene("MainMenu");
		}
	} // end FixedUpdate

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Car")) 
		{
			transform.position = pointRestart;//new Vector3(-21.68f, 12.85f, 0);
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
			SceneManager.LoadScene("Level4");
		}
		if (other.gameObject.CompareTag ("Door") && count == 10 && SceneManager.GetActiveScene().buildIndex == 5) 
		{
			other.gameObject.GetComponent<SpriteRenderer> ().sprite = openedDoor;
			SceneManager.LoadScene("Level5");
		}
		if (other.gameObject.CompareTag ("Door") && count == 10 && SceneManager.GetActiveScene().buildIndex == 6) 
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
