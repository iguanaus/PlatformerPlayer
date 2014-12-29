using UnityEngine;
using System.Collections;

public class goalScript : MonoBehaviour {
	private bool solved;
	public gameController controller;
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
			controller.levelWon = solved;
		}
	}




}
