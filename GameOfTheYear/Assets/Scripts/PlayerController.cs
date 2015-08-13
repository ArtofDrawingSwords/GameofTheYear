using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour {

    private float xMovement;
    public float moveSpeed;
    public float jumpSpeed;
    public bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundCheckLayerMask;
    public Animator animator;

    public float yVelocity;

    private bool doubleJumped;

	public ParticleSystem cloudjump;

    private bool facingRight;
    public Transform playerTransform;
    Quaternion flippedRotation = Quaternion.Euler(0, 180, 0);

    // Use this for initialization
    void Start () {
        facingRight = true;
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayerMask);
    }
	
	// Update is called once per frame
	void Update () {

        animator.SetBool("grounded", grounded);
        yVelocity = GetComponent<Rigidbody2D>().velocity.y;
        animator.SetFloat("yVelocity", Mathf.Abs(yVelocity));

        xMovement = Input.GetAxis("Horizontal");
        animator.SetFloat("xSpeed", Mathf.Abs(xMovement));

        if (grounded)
        {
            doubleJumped = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump();
			cloudjump.Emit(10);
        }
        if(Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            jump();
            doubleJumped = true;
			cloudjump.Emit(10);
        }
        if(xMovement > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if(!facingRight)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                transform.position = new Vector2(transform.position.x - 1.19f, transform.position.y);
                facingRight = true;
            }
        }

        if(xMovement < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if(facingRight)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                transform.position = new Vector2(transform.position.x + 1.19f, transform.position.y);
                facingRight = false;
            }
        }

        //flips player
        /*
        if (xMovement > 0)
            playerTransform.localRotation = Quaternion.identity;
        else if (xMovement < 0)
            playerTransform.localRotation = flippedRotation;
            */

    }

    private void jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
    }
	//Bouncy Platforms
	public void Bounce(float powa)
	{
		cloudjump.Emit (15);
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed + powa);
	}



}
