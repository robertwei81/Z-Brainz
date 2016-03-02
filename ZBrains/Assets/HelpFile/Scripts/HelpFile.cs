/// <summary>
/// Help file.
/// Attached to Help Camera
/// </summary>


using UnityEngine;
using System.Collections;

public class HelpFile : MonoBehaviour {

	public Texture backgroundTexture; // public so you can drag background image on unity

	void OnGUI(){
		// display background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
	}
	  

}