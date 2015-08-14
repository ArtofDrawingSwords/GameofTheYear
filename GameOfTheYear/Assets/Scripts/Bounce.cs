using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
    private GameObject Killua;
	public float powa;
	// Use this for initialization
	void Start () {
		Killua = GameObject.Find("KilluaPlayer");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
       if ((collider.gameObject.GetComponent("PlayerController") as PlayerController) != null) {
            Killua.GetComponent<PlayerController>().Bounce(powa);
		}

	}
}
