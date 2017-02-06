using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDownWallCollision : MonoBehaviour {

	[SerializeField]private AudioSource ballBump;

	void OnCollisionEnter2D (Collision2D collInfo) {
		if (collInfo.collider.name == "pongBall") 
		{
			ballBump.Play ();
		}
	}
}
