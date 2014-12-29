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
	public GameObject spawnPoint;
	public GameObject character;
	public GameObject sphereSpawnPoint;
	public float levelOn = 1;
	public bool levelWon;

	// Use this for initialization
	void Start () {
		degreesturned = 0;
		levelWon = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			sphereObject.gameObject.rigidbody.velocity = Vector3.zero;
			sphereObject.transform.position = sphereSpawnPoint.transform.position;
			print("You pressed enter!");
			character.transform.position = spawnPoint.transform.position;
		}

		//lets make it spin
		degreesturned += 0.1f;
		//transform.Rotate (.1f,.0f,.1f);
		if (degreesturned >= 360) {
			degreesturned = 0;
		}

	}

	void OnGUI() {
		if (!levelWon) {
			GUI.Label(new Rect(0,0,20,20),"" + levelOn);
		} else {
			if (GUI.Button (new Rect(Screen.width/2-100,Screen.height/2-100,200,200),"Grats! Next Level!")) {
				nextLevel();		
			}

		}

	}

	void nextLevel() {
		//this will change the scene/settings
		levelOn++;
		levelWon = false;
		setUpNextLevel(levelOn);
	}
	void setUpNextLevel(float level) {

		sphereObject.rigidbody.isKinematic = false;
		character.transform.position = spawnPoint.transform.position;

		sphereObject.gameObject.rigidbody.velocity = Vector3.zero;
		sphereObject.transform.position = sphereSpawnPoint.transform.position;

	
	}
}
