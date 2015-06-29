using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour {

	public string LEFTRIGHT = "Horizontal";
	public string UPDOWN = "Vertical";
	public string JumpButton = "Jump";
	public float walkvelocity = 2;
	public float runvelocity = 5;
	public float gravity = 50;
	public Transform CharacterBase;
	public SkeletonAnimation skeletonAnimation;
	public string idleAnimation = "idle";
	public string walkAnimation = "walk";
	public string runAnimation = "run";
	public string hitAnimation = "hit";
	public string deathAnimation = "death";
	public string jumpAnimation = "jump";
	public string fallAnimation = "jump";
	public string crouchAnimation = "idle";
	public string currentAnimation = "";
	public AudioSource jumpsound;
	public AudioSource hardfallsound;
	public AudioSource stepsound;
	public string groundcollide = "Footstep";
	public float jumpSpeed = 25;
	public float jumpDuration = 0.5f;
	public float jumpInterruptFactor = 100;
	public float forceCrouchVelocity = 25;
	public float forceCrouchDuration = 0.5f;
	CharacterController Player;
	Vector2 velocity = Vector2.zero;
	Vector2 lastvelocity = Vector2.zero;
	bool lastground = false;
	float endofjump = 0;
	bool jumpstatus = false;
	float groundflinch;
	Quaternion FlipMe = Quaternion.Euler(0, 180, 0);
	void Awake () {
		Player = GetComponent<CharacterController>();
	}
	void Start () {
		skeletonAnimation.state.Event += HandleEvent;
	}
	void HandleEvent (Spine.AnimationState state, int trackIndex, Spine.Event e) {
		if (e.Data.Name == groundcollide) {
			stepsound.Stop();
			stepsound.Play();
		}
	}
	void SetAnimation(string anim, bool loop) {
		if (currentAnimation != anim) {
			skeletonAnimation.state.SetAnimation(0, anim, loop);
			currentAnimation = anim;
		}
	}
	void Update () {
		//Controls
		float x = Input.GetAxis(LEFTRIGHT);
		float y = Input.GetAxis(UPDOWN);
		//JumpIntoGroundFlinch
		bool hitground = (Player.isGrounded && y < -0.5f) || (groundflinch > Time.time);
		velocity.x = 0;
		//calculates velocity
		if (!hitground) { 
			if (Input.GetButtonDown(JumpButton) && Player.isGrounded) {
				jumpsound.Stop();
				jumpsound.Play();
				velocity.y = jumpSpeed;
				endofjump = Time.time + jumpDuration;
			} else if (Time.time < endofjump && Input.GetButtonUp(JumpButton)) {
				jumpstatus = true;
			}
			if (x != 0) {
				velocity.x = Mathf.Abs(x) > 0.6f ? runvelocity : walkvelocity;
				velocity.x *= Mathf.Sign(x);
			}
			if (jumpstatus) {
				if (velocity.y > 0) {
					velocity.y = Mathf.MoveTowards(velocity.y, 0, Time.deltaTime * 100);
				} else { 
					jumpstatus = false;
				}
			}
		}
		velocity.y -= gravity * Time.deltaTime;
		//Movement
		Player.Move(new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime);
		if (Player.isGrounded) {
			velocity.y = -gravity * Time.deltaTime;
			jumpstatus = false;
		}
		Vector2 deltaVelocity = lastvelocity - velocity;
		if (!lastground && Player.isGrounded) {
			if ((gravity * Time.deltaTime) - deltaVelocity.y > forceCrouchVelocity) {
				groundflinch = Time.time + forceCrouchDuration;
				hardfallsound.Play();
			} else {
				stepsound.Play();
			}
		}
		//SetAnimations
		if (Player.isGrounded) {
			if (hitground) {
				skeletonAnimation.AnimationName = crouchAnimation;
			} else {
				if (x == 0)
					skeletonAnimation.AnimationName = idleAnimation;
				else //Start walking into running
					skeletonAnimation.AnimationName = Mathf.Abs(x) > 0.6f ? runAnimation : walkAnimation; 
			}
		} else {
			if (velocity.y > 0) 
				skeletonAnimation.AnimationName = jumpAnimation;
			else
				skeletonAnimation.AnimationName = fallAnimation;
		}
		//Flip
		if (x > 0)
			CharacterBase.localRotation = Quaternion.identity;
		else if (x < 0)
			CharacterBase.localRotation = FlipMe;
		lastvelocity = velocity;
		lastground = Player.isGrounded;
	}
}