using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    public SkeletonAnimation skeletonAnimation;

    public Transform playerTransform;
    Quaternion flippedRotation = Quaternion.Euler(0, 180, 0);
    public string idleAnimation = "idle";
    public string walkAnimation = "walk";
    public string runAnimation = "run";
    public string hitAnimation = "hit";
    public string deathAnimation = "death";
    public string jumpAnimation = "jump";
    public string fallAnimation = "jump";
    public string crouchAnimation = "idle";
    public string currentAnimation  = "";
    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (player.grounded)
        {
            {
                if (x == 0)
                    skeletonAnimation.AnimationName = idleAnimation;
                else //Start walking into running
                    skeletonAnimation.AnimationName = Mathf.Abs(x) > 0.6f ? runAnimation : walkAnimation;
            }
        }
        else
        {
            if (y > 0)
                skeletonAnimation.AnimationName = jumpAnimation;
            else
                skeletonAnimation.AnimationName = fallAnimation;
        }

        if (x > 0)
            playerTransform.localRotation = Quaternion.identity;
        else if (x < 0)
            playerTransform.localRotation = flippedRotation;
    }

    void SetAnimation(string anim, bool loop)
    {
        if (currentAnimation != anim)
        {
            skeletonAnimation.state.SetAnimation(0, anim, loop);
            currentAnimation = anim;
        }
    }
}
