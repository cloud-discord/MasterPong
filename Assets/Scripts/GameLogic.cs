using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0618, 0649
public class GameLogic : MonoBehaviour {

	[SerializeField]private BoxCollider2D leftWall; //collider for player1 keep
	[SerializeField]private BoxCollider2D rightWall; //collider for player2 keep
	[SerializeField]private GameObject upWall; //collider for player1 keep
	[SerializeField]private GameObject downWall; //collider for player2 keep
	[SerializeField]private Camera mainCam; //variable for storing the main camera
	[SerializeField]private CircleCollider2D ball; //collider for ball
	static int scoreP1;
	static int scoreP2;


	// Use this for initialization
	void Start () {
		//Initialize Scores
		scoreP1 = 0;
		scoreP2 = 0;

		//Initiallize Walls
		leftWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
		leftWall.offset = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x - 0.5f, 0f);

		rightWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
		rightWall.offset = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x + 0.5f, 0f);

		upWall.transform.localScale = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width,0f,0f)).x , 0.5f, 1f);
		upWall.transform.position = new Vector3 (mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x-1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height, 0f)).y-0.5f, 0f);

		downWall.transform.localScale = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width,0f,0f)).x , 0.5f, 1f);
		downWall.transform.position = new Vector3 (mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x-1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).y, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		//do nothing
	}

	public static void scoring(string wallName)
	{
		if (wallName == "leftWall") {
			scoreP2 += 1;
		} 
		else if (wallName == "rightWall") 
		{
			scoreP1 += 1;
		}
		Debug.Log ("ScoreP1 is :" + scoreP1);
		Debug.Log ("ScoreP2 is :" + scoreP2);
	}

	void OnGUI ()
	{
		//draw scores (THIS IS PLACEHOLDER)
		GUI.Label (new Rect (Screen.width / 2 - 150f, 20f, 100f, 100f), scoreP1.ToString());
		GUI.Label (new Rect (Screen.width / 2 + 150f, 20f, 100f, 100f), scoreP2.ToString());
	}
}