using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInit : MonoBehaviour {


	private Rigidbody2D m_Rigidbody2D;
	// Use this for initialization
	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_Rigidbody2D.velocity = new Vector2 (-5, -5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
