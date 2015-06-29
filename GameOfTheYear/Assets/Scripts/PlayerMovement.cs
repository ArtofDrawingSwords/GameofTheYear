using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
		
	public float maxSpeed = 5f;
	float horiVelocity;
	float vertVelocity;
	Vector3 velocity;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;

		//calculates velocity
		horiVelocity = Input.GetAxis ("Horizontal") * maxSpeed * Time.deltaTime;
		vertVelocity = Input.GetAxis ("Jump") * maxSpeed * Time.deltaTime;

		//stores velocity in vector3
		velocity = new Vector3 (horiVelocity, vertVelocity, 0);

		//calculates new position and stores in Vector3
		pos += velocity;

		//update position of player
		transform.position = pos;

	}
}
