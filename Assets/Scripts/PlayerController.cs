using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Movement fields
	float move_force = 20f; // force to apply to player when movement key is pressed
	float speed; // velocity vector magnitude
	Vector2 direction = new Vector2(0f,0f); // player direction
	public Animator animator; // Mechanim animator for the player

	// Grabbing mechanic fields
	float grab_radius = 0.15f;
	public Transform grab_check;
	public LayerMask stealable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Update animator speed parameter
		speed = rigidbody2D.velocity.SqrMagnitude ();
		animator.SetFloat ("speed", speed);

		// Update direction
		direction.x = Input.GetAxis ("Horizontal");
		direction.y = Input.GetAxis ("Vertical");
		Quaternion qTo = Quaternion.LookRotation(Vector3.forward, direction);
		if (direction.SqrMagnitude() > 0.1f)
			transform.rotation = Quaternion.Slerp(transform.rotation, qTo, 15f * Time.deltaTime);

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

		// Start stealing
		if (Input.GetKeyDown("space")) {
			animator.SetBool("grab", true);
		}
	}

	void grab() {
		animator.SetBool ("grab", false);
		// Check overlap between GrabPoint and objects on Grabable layer
		Collider2D temp = Physics2D.OverlapCircle (grab_check.position, grab_radius, stealable);
		// Check if temp is not null, if it is not then destroy the associated object
		if (temp) {
			// TODO: Store the object or object value
			temp.gameObject.animation.Play ("Destroy");
			Destroy (temp.gameObject, 0.03);
		}
	}
}
