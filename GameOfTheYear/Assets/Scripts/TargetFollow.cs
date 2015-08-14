using UnityEngine;
using System.Collections;

public class TargetFollow : MonoBehaviour {

    public Animator animator;

    public Transform target;

    public float followSpeed;
    public float activationDistance;
    public float attackRange;

    private float xVelocity;
    private bool facingRight;
    private bool attacking;

	// Use this for initialization
	void Start () {
        facingRight = true;
        attacking = false;
	}
	
	// Update is called once per frame
	void Update () {

        xVelocity = GetComponent<Rigidbody2D>().velocity.x;
        animator.SetFloat("xVelocity", Mathf.Abs(xVelocity));
        animator.SetBool("attacking", attacking);

        if (target.position.x > transform.position.x && (target.position.x - transform.position.x) < attackRange)
        {
            attacking = true;
        }
        else if(target.position.x < transform.position.x && (transform.position.x - target.position.x) < attackRange)
        {
            attacking = true;
        }
        else if(target.position.x > transform.position.x && (target.position.x - transform.position.x) < activationDistance)
        {
            attacking = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(followSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (target.position.x < transform.position.x && (transform.position.x - target.position.x) < activationDistance)
        {
            attacking = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-followSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (xVelocity > 0)
        {
            if (!facingRight)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                facingRight = true;
            }
        }

        if (xVelocity < 0)
        {
            if (facingRight)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                facingRight = false;
            }
        }

    }

        
}
