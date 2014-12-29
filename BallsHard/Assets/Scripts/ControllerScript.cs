using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

		CharacterController controller;

	public float speed = 5.0f;
	Vector3 movement = Vector3.zero;
	public float jumpSpeed = 8.0f;
	public float pushPower = 2.0f;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		movement.x = Input.GetAxis ("Horizontal") * speed;

		if (controller.isGrounded == false) {
			movement.y += Physics.gravity.y * Time.deltaTime;
		}
		if (Input.GetButton ("Jump") && controller.isGrounded == true) {
			movement.y = jumpSpeed;
		}
	

		controller.Move (movement * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		if (hit.moveDirection.y < -0.3f)
			return;
		Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0f, 0f);
		body.velocity = pushDir * pushPower;
	}

}
