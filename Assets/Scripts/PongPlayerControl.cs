using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PongPlayerControl : MonoBehaviour
{
	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the y axis.

	private Rigidbody2D m_Rigidbody2D;

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
		// Read the inputs.
		float move = CrossPlatformInputManager.GetAxis("Vertical");
		// Pass all parameters to the character control script.

		// Move the character
		m_Rigidbody2D.velocity = new Vector2(0, move*m_MaxSpeed);

	}
}