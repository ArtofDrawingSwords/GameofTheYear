using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	Vector3 tempPosition;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		tempPosition = target.transform.position;
		tempPosition.z = transform.position.z;
		transform.position = tempPosition;
	}
}
