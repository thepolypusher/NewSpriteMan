using UnityEngine;
using System.Collections;

namespace Assets.Code
{
public class PlayerControl : MonoBehaviour 
{

	public float maxSpeed = 10f;
	private bool facingRight = true;
	public float jumpForce = 700f;
    public float jetpackfuel = 4f,
        maxjetpackfuel = 4f,
        jetpackforce = 40f;
    private bool stillholdingjump = true;

	public Gun _gun;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
    private SceneManager SceneMan;
    private bool _canFlip = true;

	void Start () 
	{
		anim = GetComponent<Animator>();
        SceneMan = FindObjectOfType<SceneManager>();
	}
	
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2(move*maxSpeed, rigidbody2D.velocity.y);

		if (_canFlip && move > 0 && !facingRight)
			Flip ();
        else if (_canFlip && move < 0 && facingRight)
			Flip ();


	}
	void Update()
	{
        // Controls

        bool fire = Input.GetButton("Fire1");
        bool resetCanFire = Input.GetButtonUp("Fire1");
        bool use = Input.GetButtonDown("Fire2");
        bool jump = Input.GetButtonDown("Jump");
        bool holdjump = Input.GetButton("Jump");

        if(grounded && jump)
		{
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce (new Vector2(0, jumpForce));
            stillholdingjump = true;
		}

        if (Input.GetButtonUp("Jump"))
        {
            stillholdingjump = false;         
        }

        if (!grounded && holdjump && !stillholdingjump && jetpackfuel > 0f)
        {
            rigidbody2D.AddForce(new Vector2(0, jetpackforce));
            jetpackfuel -= Time.deltaTime;
        }


		if (fire)
		{
            _canFlip = false;
			_gun.TryShoot(facingRight);
		}

        if (resetCanFire)
            _canFlip = true;


        if (use)
        {
            foreach (InteractByProximity intobj in SceneMan.SceneInteractiveObjects)
            {
                if (intobj.PlayerCanInteract)
                    intobj.UseObject();
            }
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

