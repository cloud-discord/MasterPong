using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

#pragma warning disable 0618, 0649
public class PongPlayerControl : MonoBehaviour
{
	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the y axis.
	[SerializeField] private KeyCode moveUp;
	[SerializeField] private KeyCode moveDown;

	private Rigidbody2D m_Rigidbody2D;

	private void Start()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		//do nothing
	}

	private void FixedUpdate()
	{
		#if UNITY_EDITOR 
		//PC platform input
		if (Input.GetKey(moveUp))
			m_Rigidbody2D.velocity = new Vector2(0, m_MaxSpeed);
		else if (Input.GetKey(moveDown))
			m_Rigidbody2D.velocity = new Vector2(0, -1*m_MaxSpeed);
		else
			m_Rigidbody2D.velocity = new Vector2(0, 0);
		#endif

		#if UNITY_ANDROID && !UNITY_EDITOR
			//android input here
		#endif
	}
}