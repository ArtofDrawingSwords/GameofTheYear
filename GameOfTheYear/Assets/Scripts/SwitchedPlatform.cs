using UnityEngine;
using System.Collections;

public class SwitchedPlatform : MonoBehaviour {
	public float movementspeed;
	public Transform movehere;
	private Vector3 defaultlocation;
	private Vector3 endlocation;
	private bool isMoving;
	private GameObject Player;
	public GameObject thisthing;

	private bool isStarted;

	// Use this for initialization
	void Start () {
		defaultlocation = this.transform .position;
		endlocation = movehere.position;
		Player = GameObject .Find("KilluaPlayer");
	}
	
	// Update is called once per frame
	void Update () {
	if (!isStarted)
		{
			//Do nothing
		} else {
			GoGoGo();
		}
	}

	
	void StartMoving()
	{
		isStarted = true;
	}

	void GoGoGo()
	{
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
			Player.transform.parent = thisthing.transform;  
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "spineboy") {
			Player.transform.parent = null;
		}
	}

}
