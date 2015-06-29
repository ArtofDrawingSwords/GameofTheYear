using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	SkeletonAnimation skeletonAnimation;
	public string idleAnimation = "idle";
	public string walkAnimation = "walk";
	public string runAnimation = "run";
	public string hitAnimation = "hit";
	public string deathAnimation = "death";
	public string currentAnimation = "";
		
	public float maxSpeed = 5f;
	float horiVelocity;
	float vertVelocity;
	Vector3 velocity;

	float x;
	float y;

	// Use this for initialization
	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation>();
	}
	
	// Update is called once per frame
	void Update () {

		x = Input.GetAxis ("Horizontal");
		y = Input.GetAxis ("Jump");

		Vector3 pos = transform.position;

		//calculates velocity
		if (Input.GetAxis("Jump") > 0) {
			SetAnimation ("jump", false);
		}
		else if(x != 0){
			if(x > 0)
				skeletonAnimation.skeleton.flipX = false;
			else 
				skeletonAnimation.skeleton.flipX = true;
			SetAnimation ("walk", true);
			horiVelocity = x * maxSpeed * Time.deltaTime;
		}
		else {
			SetAnimation ("idle", true);
		}


		//stores velocity in vector3
		velocity = new Vector3 (horiVelocity, vertVelocity, 0);

		//calculates new position and stores in Vector3
		pos += velocity;

		//update position of player
		transform.position = pos;

	}

	void SetAnimation(string anim, bool loop) {
		if (currentAnimation != anim) {
			skeletonAnimation.state.SetAnimation(0, anim, loop);
			currentAnimation = anim;
		}
	}
}
