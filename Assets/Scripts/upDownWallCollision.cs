using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0618, 0649
public class upDownWallCollision : MonoBehaviour {

	[SerializeField]private AudioSource ballBump;

	void OnCollisionEnter2D (Collision2D collInfo) {
		if (collInfo.collider.name == "pongBall") 
		{
			ballBump.Play ();
		}
	}
}
