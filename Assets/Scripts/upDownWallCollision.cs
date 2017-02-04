using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDownWallCollision : MonoBehaviour {

	[SerializeField]private AudioClip wallBump;

	void OnCollisionEnter2D (Collision2D collInfo) {
		if (collInfo.collider.name == "pongBall") 
		{
			AudioSource.PlayClipAtPoint (wallBump, transform.position);
		}
	}
}
