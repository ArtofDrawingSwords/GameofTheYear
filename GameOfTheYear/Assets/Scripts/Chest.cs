using UnityEngine;
using System.Collections;


public class Chest : MonoBehaviour {
	public Sprite ChestOpenSprite;
	private bool Opened;
	private God God;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject .tag == "spineboy" && !Opened) {
			OpenChest ();
		}
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "spineboy" && !Opened)
        {
            OpenChest();
        }
    }

	void OpenChest()
	{
		Opened = true;
		GetComponent<SpriteRenderer>().sprite = ChestOpenSprite;
		if (God == null)
		{
			God = GameObject.FindGameObjectWithTag ("God").GetComponent<God>();
		}
		God.Chesterino();
	}
}
