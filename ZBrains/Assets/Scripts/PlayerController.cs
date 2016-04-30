using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float speed;
	public bool paused = false;
	public Sprite bloodPool;
	static public int count;
	public Text pauseText;
	public Text countText;
	public Text timeText;
	public Game current = Game.current;
	private int starting_count;
	static public int difficultyTimeVar=5;// default factor is 3*
	private bool isPaused;
	public Vector3 pointRestart;
	//------------timer variables ----------------
	private float timeLeft = difficultyTimeVar*60;
	static public bool PlayGame = true;
	//--------------------------------------------
	void Start()
	{
		
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.freezeRotation = true;
		count = 0;
		pauseText.text = "";
		if (SceneManager.GetActiveScene ().buildIndex == 3) {
			starting_count = 6;
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
		if (SceneManager.GetActiveScene ().buildIndex == 7) {
			starting_count = 10;
		}
		setTimeText ();
		setCountText ();
		isPaused = true;
		Time.timeScale = 0f;
		pauseText.text = "PAUSED";
	}

	void setCountText(){
		countText.text = "Brains Left: " + (starting_count - count).ToString();
	}
	void setTimeText(){
		timeText.text = "Time: " + timeLeft.ToString("F0");
	}
	void Update(){
		setTimeText();
		if (timeLeft < 0)
			GameOver();
		else
			timeLeft -= Time.deltaTime;
	}
	void GameOver(){
		//todo: need to pause and display game over
		//todo: need to set a if tap then if (paused and time ==0) return to main menu
		PlayGame = false;
	}

	void OnGUI(){
		// show pause button when isPaused is false
		GUI.backgroundColor = Color.black;
		GUI.contentColor = Color.white;
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

		if (other.gameObject.CompareTag ("Door") && count == 6 && SceneManager.GetActiveScene().buildIndex == 3) 
		{
			SceneManager.LoadScene("Level2");
		}

		if (other.gameObject.CompareTag ("Door") && count == 10 && SceneManager.GetActiveScene().buildIndex == 4) 
		{
			SceneManager.LoadScene("Level3");
		}

		if (other.gameObject.CompareTag ("Door") && count == 10 && SceneManager.GetActiveScene().buildIndex == 5) 
		{
			SceneManager.LoadScene("Level4");
		}
		if (other.gameObject.CompareTag ("Door") && count == 10 && SceneManager.GetActiveScene().buildIndex == 6) 
		{
			SceneManager.LoadScene("Level5");
		}
		if (other.gameObject.CompareTag ("Door") && count == 10 && SceneManager.GetActiveScene().buildIndex == 7) 
		{
			SceneManager.LoadScene("MainMenu");
		}

		if (other.gameObject.CompareTag ("PickUp")) {
			//other.gameObject.SetActive (false);
			other.gameObject.GetComponent<SpriteRenderer> ().sprite = bloodPool;
			other.gameObject.tag = "Blood";
			other.gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "Blood";
			other.gameObject.transform.localScale = new Vector2 (1f, 1f);
			count = count + 1;
			setCountText ();
		}
			
	} //end OnTriggerEnter2D

}
