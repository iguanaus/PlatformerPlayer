using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {

	CharacterController controller;
	Vector3 movement = Vector3.zero;
	public float speed = 8.0f;
	public float jumpHeight = 15.0f;
	public float pushPower = 2.0f;

	/* I want to add three things:
	 *    left/right movement (aka see in the horizontal axis is down and respond appropriately
	 *    gravtiy/jumping (use the physics gravity to pull it down, spacebar is jump
	 *    collision with the sphere - add a collision detector
	 * 
	 * If I get all of this done, i will add a "goal" for the ball to get to. Fairly basic and straightforward game.
	 * 
	 */


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

		if (Input.GetKeyDown(KeyCode.UpArrow) && controller.isGrounded == true) {
			movement.y = jumpHeight;
		}



		controller.Move (movement * Time.deltaTime);

	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.gameObject.rigidbody;
		if (body == null || body.isKinematic) {
			return;
		}
		if (hit.moveDirection.y < -0.3f) {
			return;
		}
		Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0f, 0f);
		body.velocity = pushDir * pushPower;
	}
}
