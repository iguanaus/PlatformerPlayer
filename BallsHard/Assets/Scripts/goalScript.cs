using UnityEngine;
using System.Collections;

public class goalScript : MonoBehaviour {
	private bool solved;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == tag) {
			solved = true;
			other.rigidbody.isKinematic = true;
		}
	}

	void OnGUI() {
		if (solved) {
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), "YOU SOLVED IT!!!! GRATS NERD");
		}
	}



}
