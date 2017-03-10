using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0618, 0649
public class BallLogic : MonoBehaviour {

	bool showStart; //flag to control Start Label
	private float countdown = 10f;
	private float roundTime= 10f;
	private float lastRoundTime = -1f;
	private bool contactDelta; // true if delta is positive
	private float contactDeltaNum;
	private ContactPoint2D contactPoint;
	private Rigidbody2D m_Rigidbody2D;
	private bool velocityisZero;
	[SerializeField]private AudioSource playerBump;
	[SerializeField]private AudioSource countdownSound1;
	[SerializeField]private AudioSource countdownSound2;
	[SerializeField]private Text countdownText;
	public static bool resetBall = false;

	// Use this for initialization
	void Start()
	{
		resetBall = false;
		//get postion and velocity
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_Rigidbody2D.velocity = new Vector2(0f, 0f);
		transform.position = new Vector3(0f, 0f, 0f);
		StartCoroutine(waitfor3Seconds());
		ballReset ();

	}

	//Resets all ball Properties
	private void ballReset()
	{
		StartCoroutine(waitforaSecond());
		if (GameLogic.scoreP1 < GameLogic.winScore && GameLogic.scoreP2 < GameLogic.winScore) 
		{
			Debug.Log ("Reset Ball!");
			countdown = 4f;
			m_Rigidbody2D.velocity = new Vector2(0f, 0f);
			transform.position = new Vector3(0f, 0f, 0f);
			Invoke ("playBall", 4f);
		}


	}

	//Plays the Ball
	private void playBall()
	{
		showStart = false;

		float randomNumber = Random.Range (-2, 2);
		float dir = Random.Range (-1, 2);
		Debug.Log ("rand: " + randomNumber);
		Debug.Log ("dir: " + dir);
		float multiplier = Random.value;

		if (randomNumber <= 0.5)
			m_Rigidbody2D.AddForce(new Vector2 (-40, 30f * multiplier * dir));
		else
			m_Rigidbody2D.AddForce(new Vector2 (40, 30f * multiplier * dir));
	}
		

	void OnCollisionEnter2D(Collision2D collInfo)
	{
		//ball mechanics here, should make constants
		if (collInfo.collider.name == ("Player1") || collInfo.collider.name == ("Player2")) 
		{
			//randomize pitch to avoid the same exact sound
			float randomPitchMult = Random.Range (0.8f, 1.2f);
			playerBump.pitch = 1 * randomPitchMult;
			playerBump.Play ();

			//ball behaviour
			float velY = m_Rigidbody2D.velocity.y;
			float velX = m_Rigidbody2D.velocity.x;

			//check if velocity in Y axis is close to zero, because floats right!
			velocityisZero = Mathf.Abs((collInfo.gameObject.GetComponent<Rigidbody2D>().velocity.y - 0)) < 0.0001f;
			contactPoint = collInfo.contacts [0];
			contactDelta = collInfo.rigidbody.position.y < contactPoint.point.y;
			contactDeltaNum = Mathf.Abs(collInfo.rigidbody.position.y - contactPoint.point.y);

			if (m_Rigidbody2D.velocity.x < 20f) 
			{
				if (velX > 0)
					velX = 10f;
				else
					velX = -10f;
			}


			if (collInfo.collider.name == ("Player2")) {
				m_Rigidbody2D.velocity = new Vector2 (velX * 1.4f, velY * 1.2f); //should make variables
			}
			else if (collInfo.collider.name == ("Player1")) 
			{
				if (contactDeltaNum < collInfo.collider.bounds.size.y / 35f)
				{
						m_Rigidbody2D.velocity = new Vector2(velX, 0f);		
				}
				else
				{
					if (contactDelta) 
					{
						m_Rigidbody2D.velocity = new Vector2 (velX, velocityisZero ? 5f:(collInfo.rigidbody.velocity.y/4 + velY/2));
					} 
					else
					{
						m_Rigidbody2D.velocity = new Vector2 (velX, velocityisZero ? -5f:(collInfo.rigidbody.velocity.y/4 + velY/2));
					}		
				}
			}



				

			/*

			velY = velY / 2 + collInfo.rigidbody.velocity.y / 2;
			if (m_Rigidbody2D.velocity.x < 30f) 
			{
				if (velX > 0)
					velX = 15f;
				else
					velX = -15f;
			}
			m_Rigidbody2D.velocity = new Vector2(velX, velY);
			*/

		}
	}

	void Update()
	{
		if (resetBall) 
		{
			resetBall = false;
			ballReset();
		}
		countdown -= Time.deltaTime;
		roundTime = Mathf.Round (countdown);
		if (roundTime < 4 && roundTime > 0) 
		{
			showStart = true;	
		}
		if (showStart) 
		{
			if (lastRoundTime != roundTime) 
			{
				countdownText.text = roundTime.ToString();
				lastRoundTime = roundTime;

				if (lastRoundTime > 0) 
				{
					countdownSound1.Play ();
				}
				else 
				{
					countdownSound2.Play ();
				}
			}

		}
		else
		{
			countdownText.text = "";
		}
	}
		
	IEnumerator waitforaSecond()
	{
		Debug.Log("Before Waiting 1 seconds");
		yield return new WaitForSeconds(2);
		Debug.Log("After Waiting 1 Seconds");
	}

	IEnumerator waitfor3Seconds()
	{
		Debug.Log("Before Waiting 1 seconds");
		yield return new WaitForSeconds(3);
		Debug.Log("After Waiting 1 Seconds");
	}
}
