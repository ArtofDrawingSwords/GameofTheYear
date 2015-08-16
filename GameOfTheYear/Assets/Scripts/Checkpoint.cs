using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if ((coll.gameObject.GetComponent("PlayerController") as PlayerController) != null)
        {
            coll.GetComponent<PlayerHealth>().lastcheckpoint = this.gameObject;
            God.Kamisama.lastcheckpoint = this.gameObject;
        }
    }
}
