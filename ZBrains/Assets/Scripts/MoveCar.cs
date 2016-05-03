using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveCar : MonoBehaviour {
	public Vector3 pointB; // enter on Unity

	IEnumerator Start()
	{
		var pointA = transform.position; // starting position
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 7.0f)); // move from point A to point B
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 7.0f)); // move back to point A
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}


} // end MoveCar