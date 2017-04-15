using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

#pragma warning disable 0618, 0649
public class PongPlayerControl : MonoBehaviour
{
	[SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the y axis.
	[SerializeField] private KeyCode moveUp;
	[SerializeField] private KeyCode moveDown;
	[SerializeField] private Camera CurrCam;
	private Vector3 wantedPos;
	private Rigidbody2D m_Rigidbody2D;

	private void Start()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
		

	private void FixedUpdate()
	{
		#if UNITY_EDITOR
		//PC platform input
		if (Input.GetKey(moveUp)){
			Debug.Log("PC Controls");
			m_Rigidbody2D.velocity = new Vector2(0, m_MaxSpeed);}
		else if (Input.GetKey(moveDown))
			m_Rigidbody2D.velocity = new Vector2(0, -1*m_MaxSpeed);
		else
			m_Rigidbody2D.velocity = new Vector2(0, 0);
		#endif

		#if UNITY_ANDROID
			//android input here
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);


			wantedPos = CurrCam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));

			if(m_Rigidbody2D.position.y < wantedPos.y + 0.2f && m_Rigidbody2D.position.y > wantedPos.y - 0.2f)
				m_Rigidbody2D.velocity = new Vector2(0, 0);
			else if(m_Rigidbody2D.position.y < wantedPos.y)
				m_Rigidbody2D.velocity = new Vector2(0, m_MaxSpeed);
			else if(m_Rigidbody2D.position.y > wantedPos.y)
				m_Rigidbody2D.velocity = new Vector2(0, -1*m_MaxSpeed);
			
		}
		else
		{
			m_Rigidbody2D.velocity = new Vector2(0, 0);	
		}

		
		#endif
	}
}