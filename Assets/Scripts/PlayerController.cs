using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Player fields
	float move_force = 20f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: Change key events to be handled with the input manager so player can remap keys in game
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
