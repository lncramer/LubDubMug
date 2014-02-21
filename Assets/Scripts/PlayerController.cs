using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Player fields
	float move_force = 20f;
	float speed; // velocity vector magnitude
	public Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Update animator speed parameter
		speed = rigidbody2D.velocity.SqrMagnitude ();
		animator.SetFloat ("speed", speed);

		// Update direction
		if (speed > 0)
			transform.rotation = Quaternion.LookRotation(Vector3.forward, rigidbody2D.velocity);


		// TODO: Change key events to be handled with the input manager (using KeyCode) so player can remap keys in game
		if (Input.GetKey("up")) {
			rigidbody2D.AddForce(new Vector2(0f, move_force));
		}
		if (Input.GetKey("down")) {
			rigidbody2D.AddForce(new Vector2(0f, move_force * -1));
		}
		if (Input.GetKey("right")) {
			rigidbody2D.AddForce(new Vector2(move_force, 0f));
		}
		if (Input.GetKey("left")) {
			rigidbody2D.AddForce(new Vector2(move_force * -1, 0f));
		}
	}
}
