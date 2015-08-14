using UnityEngine;
using System.Collections;

public class KnockBackBarrel : MonoBehaviour {
	public float KnockbackPower;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
        if ((coll.gameObject.GetComponent("PlayerController") as PlayerController) != null)
		{
			Knockback(coll.transform);
		}
	}

	void Knockback (Transform Victim)
	{
		Vector3 V3 = transform.position - Victim.position + Vector3.up *5f;
		GetComponent<Rigidbody2D>().AddForce(V3 * KnockbackPower);
		Debug.Log ("KnockbackTest!");
	}
}
