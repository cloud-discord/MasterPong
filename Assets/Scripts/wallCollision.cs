using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0618, 0649
public class wallCollision : MonoBehaviour {

	[SerializeField]private AudioSource playerScore;

	void OnCollisionEnter2D (Collision2D collInfo) {
		if (collInfo.collider.name == "pongBall") 
		{
			GameLogic.scoring (transform.name);
			playerScore.Play ();
		}
		collInfo.rigidbody.velocity = Vector2.zero;
		BallLogic.resetBall = true;
	}


}
