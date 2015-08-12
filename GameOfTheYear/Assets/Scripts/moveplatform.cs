using UnityEngine;
using System.Collections;

public class moveplatform : MonoBehaviour {
	public float movementspeed;
	public Transform movehere;
	private Vector3 defaultlocation;
	private Vector3 endlocation;
	private bool isMoving;
	private GameObject spineboy;
	public GameObject thisthing;

	// Use this for initialization
	void Start () {
		defaultlocation = this.transform .position;
		endlocation = movehere.position;
		spineboy = GameObject.Find ("spineboy");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		float move = movementspeed * Time.deltaTime;
		
		if (isMoving == false) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, endlocation, move);
		}else{
			this.transform.position = Vector3.MoveTowards (this.transform.position, defaultlocation, move);
		}
		if (this.transform.position.x == endlocation.x && this.transform.position.y == endlocation.y && isMoving == false) {
			isMoving = true;
		}else if (this.transform.position.x == defaultlocation.x && this.transform.position.y == defaultlocation.y && isMoving == true) {
			isMoving = false;
		}

	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "spineboy") {
			spineboy.transform.parent = thisthing.transform;  
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "spineboy") {
			spineboy.transform.parent = null;
		}
	}
}
