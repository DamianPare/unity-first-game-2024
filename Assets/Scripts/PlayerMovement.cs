using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// movement
	public float moveSpeed;
	public float groundDrag;

	public Transform orientation;
	float horizontalInput;
	float verticalInput;
	Vector3 moveDirection;

	public float jumpForce;
	public float jumpCooldown;
	public float airMultiplier;
	bool readyToJump;

    // keys
	public KeyCode jumpKey = KeyCode.Space;

	// ground check
	public float playerHeight;
	public float groundDistance = 0.4f;
	public LayerMask whatIsGround;
	public LayerMask ground;
	bool grounded;
	bool running; 

	Rigidbody rb;

	public AudioSource audioSource;
	public AudioClip runClip;

	private void Start()
	{
		rb = GetComponent<Rigidbody>(); // player object
		rb.freezeRotation = true; // player object doesnt fall over

		readyToJump = true; // allows player to jump on start of game
	}

	private void Update()
	{
		// ground check
		grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f, whatIsGround);

		MyInput();
		SpeedControl();
		
		// drag so no ice rink
		if (grounded)
			rb.drag = groundDrag;
		else
			rb.drag = 0;
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}


	// player input
	private void MyInput() 
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");

		if(Input.GetKey(jumpKey) && readyToJump && grounded)
		{
			readyToJump = false;

			Jump();

			Invoke(nameof(ResetJump), jumpCooldown);
		}
	}

	// movement logic
	private void MovePlayer()
	{
		// movement direction
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

		// on ground
		if(grounded)
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

		// in air 
		else if(!grounded)
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

	}

	// jump logic
	private void Jump()
	{
		rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
	}

	// caps player speed
	private void SpeedControl()
	{
		Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

		// limit velocity
		if(flatVel.magnitude > moveSpeed)
		{
			Vector3 limitedVel = flatVel.normalized * moveSpeed;
			rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
		}

		if (running == false && IsRunning(flatVel))
		{
			running = true;
			audioSource.PlayOneShot(runClip);
			Debug.Log("Running");
		}
		else if(running && IsRunning(flatVel) == false)
		{
			running = false;
			audioSource.Stop();
		}
	}

	private void ResetJump()
	{
		readyToJump = true;
	}

	public bool IsRunning(Vector3 flatVel)
	{
		return (flatVel.magnitude > 1);
	}
}