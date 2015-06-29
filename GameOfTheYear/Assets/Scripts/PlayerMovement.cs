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

	public Transform groundCheck;
	public float groundCheckRadius = 0.1f;
	public LayerMask groundLayer;
	bool onGround;
	float idleTimer = 0;

	// Use this for initialization
	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation>();
	}

	void FixedUpdate() {
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
	}
	
	// Update is called once per frame
	void Update () {

		x = Input.GetAxis ("Horizontal");
		y = Input.GetAxis ("Jump");

		Vector3 pos = transform.position;

		idleTimer -= Time.deltaTime;
		//calculates velocity
		if (Input.GetKeyDown("space")) {
			SetAnimation ("jump", false);
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
			idleTimer = 0.5f;
		}
		else if(Input.GetKeyDown("space") && x != 0) {
			SetAnimation ("jump", false);
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
			idleTimer = 0.5f;
		}
		else if(x != 0 && onGround){
			if(x > 0)
				skeletonAnimation.skeleton.flipX = false;
			else 
				skeletonAnimation.skeleton.flipX = true;
			SetAnimation ("walk", true);
			horiVelocity = x * maxSpeed * Time.deltaTime;
		}
		else if(onGround && idleTimer <= 0){
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
