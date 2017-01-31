using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

	[SerializeField]private BoxCollider2D leftWall; //collider for player1 keep
	[SerializeField]private BoxCollider2D rightWall; //collider for player2 keep
	[SerializeField]private Camera mainCam; //variable for storing the main camera
	[SerializeField]private CircleCollider2D ball; //collider for ball

	// Use this for initialization
	void Start () {

		leftWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
		leftWall.offset = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x - 0.5f, 0f);

		rightWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
		rightWall.offset = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x + 0.5f, 0f);


	}
	
	// Update is called once per frame
	void Update () {
		//do nothing
	}
}
