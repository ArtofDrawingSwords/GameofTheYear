using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float xVelocity;
	public ParticleSystem cloudjump;
    public float moveSpeed;
    public float jumpSpeed;

    public bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundCheckLayerMask;

    private bool doubleJumped;

	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayerMask);
    }
	
	// Update is called once per frame
	void Update () {

        xVelocity = Input.GetAxis("Horizontal");
            
        if(grounded)
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
        if(xVelocity > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if(xVelocity < 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
	
	}

    private void jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
    }
}
