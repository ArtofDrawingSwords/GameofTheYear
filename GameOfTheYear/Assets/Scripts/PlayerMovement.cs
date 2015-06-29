using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
		
	public float maxSpeed = 5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0, 0);
		pos += velocity;
		transform.position = pos;
	}
}
