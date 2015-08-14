using UnityEngine;
using System.Collections;


public class BlingPickup : MonoBehaviour {
	private bool Blinged;
	public GameObject Sprite;
	public ParticleSystem Particles;
	public SpriteRenderer SpriteRender;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
        if ((coll.gameObject.GetComponent("PlayerController") as PlayerController) != null && Blinged == false) {
			Blinged = true;
			SpriteRender.enabled = false;
			Particles.Emit(10);
			Invoke ("DestroyMe", 0.5f);
            God.Kamisama.Blingerino();
		}
	}
	void DestroyMe(){
		Destroy (this.gameObject);
	}
}
