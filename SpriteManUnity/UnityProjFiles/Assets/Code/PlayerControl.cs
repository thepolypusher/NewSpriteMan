﻿using UnityEngine;
using System.Collections;

namespace Assets.Code
{
public class PlayerControl : MonoBehaviour 
{

	public float maxSpeed = 10f;
	private bool facingRight = true;
	public float jumpForce = 700f;

	public Gun _gun;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2(move*maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();


	}
	void Update()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce (new Vector2(0, jumpForce));
		}
		bool fire = Input.GetButton ("Fire1");

		if (fire)
		{
			_gun.TryShoot(facingRight);
		}


            

	}

    void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
}

