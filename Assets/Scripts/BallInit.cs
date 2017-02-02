using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInit : MonoBehaviour {

	bool showStart; //flag to control Start Label

	private Rigidbody2D m_Rigidbody2D;
	// Use this for initialization
	void Start()
	{
		showStart = true;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		Invoke ("ballReset", 2f); //Calls ball reset in 2 seconds
	}

	//Resets all ball Properties
	private void ballReset()
	{
		Debug.Log ("Reset Ball!");
		transform.position = new Vector3(0f, 0f, 0f);
		m_Rigidbody2D.velocity = new Vector2(0f, 0f);

		Invoke ("playBall", 1f);

	}

	//Plays the Ball
	private void playBall()
	{
		showStart = false;
		int randomNumber = Random.Range (0, 2);
		if (randomNumber <= 0.5)
			m_Rigidbody2D.AddForce(new Vector2 (-40, -20));
		else
			m_Rigidbody2D.AddForce(new Vector2 (40, 20));
	}
		

	void OnCollisionEnter2D(Collision2D collInfo)
	{
		//ball mechanics here, should make constants
		if (collInfo.collider.name == ("Player1") || collInfo.collider.name == ("Player2")) 
		{
			float velY = m_Rigidbody2D.velocity.y;
			float velX = m_Rigidbody2D.velocity.x;
			velY = velY / 2 + collInfo.rigidbody.velocity.y / 2;
			if (m_Rigidbody2D.velocity.x < 30f) 
			{
				if (velX > 0)
					velX = 15f;
				else
					velX = -15f;
			}
				m_Rigidbody2D.velocity = new Vector2(velX, velY);

		}
	}

	private void OnGUI()
	{
		//draw Start Label (THIS IS PLACEHOLDER)
		if (showStart)
			GUI.Label(new Rect (Screen.width / 2 - 10f , Screen.height / 2 + 100f, 100f, 100f), "START");
	}
}
