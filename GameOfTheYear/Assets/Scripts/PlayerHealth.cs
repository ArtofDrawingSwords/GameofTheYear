using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public GameObject lastcheckpoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Dead()
    {
        this.gameObject.transform.position = lastcheckpoint.transform.position;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        God.Kamisama.Deaderino();
        God.Kamisama.lastcheckpoint = lastcheckpoint;
    }
}
