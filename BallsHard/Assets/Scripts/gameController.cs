using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
	/*
	 * Time for the fun stuff.
	 * I want to add two things:
	 * 1: The Escape key resets the ball
	 * 2: The ball needs to be pushed into the given area, if you accomplish it it says "Well done!"
	 */
	public GameObject sphereObject;
	private float degreesturned;
	// Use this for initialization
	void Start () {
		degreesturned = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			sphereObject.gameObject.rigidbody.velocity = Vector3.zero;
			sphereObject.transform.position = new Vector3 (6.3627f, 10.06f, -5f);
		}
		//lets make it spin
		degreesturned += 0.1f;
		transform.Rotate (.1f,.0f,.1f);
		if (degreesturned >= 360) {
			degreesturned = 0;
		}

	}
}
