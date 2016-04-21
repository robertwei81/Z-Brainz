using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game {

	public static Game current;
	public bool levelOne, levelTwo, levelThree, levelFour, levelFive;

	public Game(){
		levelOne = false;
		levelTwo = false;
		levelThree = false;
		levelFour = false;
		levelFive = false;
	}
}
