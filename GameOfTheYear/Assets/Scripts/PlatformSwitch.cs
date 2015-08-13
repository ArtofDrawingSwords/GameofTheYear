using UnityEngine;
using System.Collections;

public class PlatformSwitch : MonoBehaviour {
	public Sprite OnSwitchSprite;
	private bool Started;
	private God God;
	public GameObject SwitchedPlatform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "spineboy" && !Started) {
			GoGoGo ();
		}

	}

	void GoGoGo()
	{
		Started = true;
		GetComponent<SpriteRenderer>().sprite = OnSwitchSprite;
		SwitchedPlatform.SendMessage("StartMoving");
		if (God == null)
		{
			God = GameObject.FindGameObjectWithTag ("God").GetComponent<God>();
		}
		God.Switcherino();
	}

}
