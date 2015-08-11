using UnityEngine;
using System.Collections;

public class lolnope : MonoBehaviour {
	public float delay = 0.5f;
	private Rigidbody2D ground;
	
	void Awake()
	{
		ground = GetComponent<Rigidbody2D>();
	}
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag("spineboy"))
		{
			Invoke ("nope", delay);
		}
	}
	void nope()
	{
		ground.isKinematic = false;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
