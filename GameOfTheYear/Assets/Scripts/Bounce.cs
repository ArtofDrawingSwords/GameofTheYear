using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
	private GameObject player;
	public float powa;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("spineboy");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "spineboy") {
			player.SendMessage("Bounce", powa);
		}

	}
}
