using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    public SkeletonAnimation skeletonAnimation;

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
            if (velocity.y > 0)
                skeletonAnimation.AnimationName = jumpAnimation;
            else
                skeletonAnimation.AnimationName = fallAnimation;
        }
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
