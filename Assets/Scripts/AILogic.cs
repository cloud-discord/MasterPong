using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0618, 0649
public class AILogic : MonoBehaviour {

	[SerializeField] private float m_MaxSpeed = 5f; 
	[SerializeField] private GameObject ball;
	private Rigidbody2D m_Rigidbody2D;
	public static float difficulty;

	// Use this for initialization
	void Start () {
		
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (difficulty < 0.9f) {
			if (ball.transform.position.x < 0) {
				m_Rigidbody2D.velocity = new Vector2 (0, (m_Rigidbody2D.position.y % 1) * m_MaxSpeed);
			}
			else
			{
				if (m_Rigidbody2D.position.y < ball.transform.position.y + 0.2f && m_Rigidbody2D.position.y > ball.transform.position.y - 0.2f)
					m_Rigidbody2D.velocity = Vector2.zero;	
				else if (m_Rigidbody2D.position.y < ball.transform.position.y)
					m_Rigidbody2D.velocity = new Vector2(0, m_MaxSpeed* difficulty);
				else if (m_Rigidbody2D.position.y > ball.transform.position.y)
					m_Rigidbody2D.velocity = new Vector2(0, -1*m_MaxSpeed * difficulty);
			}


		}
		else
		{
			if (m_Rigidbody2D.position.y < ball.transform.position.y + 0.2f && m_Rigidbody2D.position.y > ball.transform.position.y - 0.2f)
				m_Rigidbody2D.velocity = Vector2.zero;	
			else if (m_Rigidbody2D.position.y < ball.transform.position.y)
				m_Rigidbody2D.velocity = new Vector2(0, m_MaxSpeed* difficulty);
			else if (m_Rigidbody2D.position.y > ball.transform.position.y)
				m_Rigidbody2D.velocity = new Vector2(0, -1*m_MaxSpeed * difficulty);	
		}


	}
}
