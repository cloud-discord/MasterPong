using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInit : MonoBehaviour {


	private Rigidbody2D m_Rigidbody2D;
	private int scoreP1; //score for player 1
	private int scoreP2; //score for player 2
	// Use this for initialization
	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		int randomNumber = Random.Range (0, 2);
		if (randomNumber <= 0.5)
			m_Rigidbody2D.AddForce(new Vector2 (-40, -20));
		else
			m_Rigidbody2D.AddForce(new Vector2 (40, 20));
		scoreP1 = 0;
		scoreP2 = 0;
		Debug.Log ("ScoreP1:" + scoreP1);
	}


	void OnCollisionEnter2D(Collision2D collInfo)
	{
		if (collInfo.collider.name == "leftWall") 
		{
			scoreP2 += 1;
			Debug.Log ("ScoreP2:" + scoreP2);
		}
		if (collInfo.collider.name == "rightWall")
		{
			scoreP1 += 1;
			Debug.Log ("ScoreP1" + scoreP1);
		}
		if (collInfo.collider.name == ("Player1") || collInfo.collider.name == ("Player2")) 
		{
			float velY = m_Rigidbody2D.velocity.y;
			velY = velY / 2 + collInfo.rigidbody.velocity.y / 3;
			m_Rigidbody2D.velocity.Set (m_Rigidbody2D.velocity.x, velY); 

		}
	}
}
