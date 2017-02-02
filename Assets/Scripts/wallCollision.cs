using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCollision : MonoBehaviour {


	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D collInfo) {
		if (collInfo.collider.name == "pongBall")
			GameLogic.scoring (transform.name);
		collInfo.gameObject.SendMessage ("ballReset");
	}
}
