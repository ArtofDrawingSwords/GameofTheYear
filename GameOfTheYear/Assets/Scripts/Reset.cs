using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
	public MeshRenderer reset;
    private GameObject Killua;
	// Use this for initialization
	void Start () {
		reset.enabled = false;
        Killua = GameObject.Find("KilluaPlayer");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "spineboy") {
            //Check for PlayerHealth, for checkpoints. Scene1 has no checkpoints, so our Player doesn't need it :>
            if ((Killua.GetComponent("PlayerHealth") as PlayerHealth) != null)
            {
                Killua.GetComponent<PlayerHealth>().Dead();
            } 
            else
            {
                //Reset level if no checkpoints yo.
                Application.LoadLevel(Application.loadedLevel);
            }
		}
	}
}
