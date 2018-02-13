using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectmovement : MonoBehaviour {


	public int playerSpeed = 50;
	public int playerHealth = 5;
	public bool isFacingRight = true;
	public int playerJumpPower = 4000;
	public float moveX;
	private GameObject heart1, heart2, heart3, heart4, heart5;

	public Transform playerGround;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool isGrounded;



	void Start()
	{
		isGrounded = true;

		heart1 = GameObject.FindGameObjectWithTag ("Heart1");
		heart2 = GameObject.FindGameObjectWithTag ("Heart2");
		heart3 = GameObject.FindGameObjectWithTag ("Heart3");
		heart4 = GameObject.FindGameObjectWithTag ("Heart4");
		heart5 = GameObject.FindGameObjectWithTag ("Heart5");

		heart1.SetActive (true);
		heart2.SetActive (true);
		heart3.SetActive (true);
		heart4.SetActive (true);
		heart5.SetActive (true);
	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (playerGround.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		PlayerMove ();
		PlayerHealthState (0);
		IsPlayerDead ();
	}

	void PlayerMove()
	{
		//Controls Player
		moveX = Input.GetAxis("Horizontal");

		if(Input.GetButtonDown("Jump") && isGrounded == true)
		{
				Jump();
		}

		//PlayerDirection
		if (moveX < 0.0f && isFacingRight == true) {
			FlipPlayer();
		} else if (moveX > 0.0f && isFacingRight == false) 
		{
			FlipPlayer ();
		}

		//Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void FlipPlayer()
	{
		isFacingRight = !isFacingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;

	}

	void Jump()
	{
			
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);

	}

	public void IsPlayerDead()
	{
		if(gameObject.transform.position.y < -7)
		{
			gameObject.transform.position = new Vector2 (0, 50);
			playerHealth -= 1;
		}	

	}

	public void PlayerHealthState(int damage)
	{
		playerHealth -= damage;
		if (playerHealth >= 5) 
		{
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
			heart4.SetActive (true);
			heart5.SetActive (true);
		}
		if (playerHealth == 4) 
		{
			heart5.SetActive (false);
		}
		if (playerHealth == 3) 
		{
			heart4.SetActive (false);
		}
		if (playerHealth == 2) 
		{
			heart3.SetActive (false);
		}
		if (playerHealth == 1) 
		{
			heart2.SetActive (false);
		}
		if (playerHealth == 0)
		{
			heart1.SetActive (false);
		}
	}


}
