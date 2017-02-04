using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCollision : MonoBehaviour {

	[SerializeField]private AudioClip playerScore;

	void OnCollisionEnter2D (Collision2D collInfo) {
		if (collInfo.collider.name == "pongBall") 
		{
			GameLogic.scoring (transform.name);
			AudioSource.PlayClipAtPoint (playerScore, transform.position);
		}
		collInfo.gameObject.SendMessage ("Start");
	}


}
