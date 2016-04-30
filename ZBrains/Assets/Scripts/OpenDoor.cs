using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour {

	SpriteRenderer sr;
	public Sprite openedDoor;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerController.count == 6 && SceneManager.GetActiveScene().buildIndex == 3) 
		{
			sr.sprite = openedDoor;
		}
		if (PlayerController.count == 10 && ((SceneManager.GetActiveScene().buildIndex == 4)||(SceneManager.GetActiveScene().buildIndex == 5)||(SceneManager.GetActiveScene().buildIndex == 6)||(SceneManager.GetActiveScene().buildIndex == 7))) 
		{
			sr.sprite = openedDoor;
		}
	}
}
