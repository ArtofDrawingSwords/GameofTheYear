using UnityEngine;
using System.Collections;


public class Chest : MonoBehaviour {
	public Sprite ChestOpenSprite;
	private bool Opened;
	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
        /*  -- Changed to Trigger, we don't need this :> --
		if (coll.gameObject.tag == "spineboy" && !Opened) {
        OpenChest ();
		}
        */
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if ((coll.gameObject.GetComponent("PlayerController") as PlayerController) != null && !Opened)
        {
            {
                OpenChest();
            }
        }
    }

	void OpenChest()
	{
		Opened = true;
		GetComponent<SpriteRenderer>().sprite = ChestOpenSprite;
        God.Kamisama.Chesterino();
	}
}
