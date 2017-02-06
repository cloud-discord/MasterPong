using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCollision : MonoBehaviour {

	[SerializeField]private AudioSource playerScore;

	void OnCollisionEnter2D (Collision2D collInfo) {
		if (collInfo.collider.name == "pongBall") 
		{
			GameLogic.scoring (transform.name);
			playerScore.Play ();
		}
		collInfo.gameObject.SendMessage ("Start");
	}


}
