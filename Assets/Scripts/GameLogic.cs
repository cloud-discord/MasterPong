using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

#pragma warning disable 0618, 0649
public class GameLogic : MonoBehaviour {

	[SerializeField]private BoxCollider2D leftWall; //collider for player1 keep
	[SerializeField]private BoxCollider2D rightWall; //collider for player2 keep
	[SerializeField]private GameObject upWall; //collider for player1 keep
	[SerializeField]private GameObject downWall; //collider for player2 keep
	[SerializeField]private Camera mainCam; //variable for storing the main camera
	[SerializeField]private CircleCollider2D ball; //collider for ball
	[SerializeField]private GameObject player1; //collider for player1
	[SerializeField]private GameObject player2; //collider for player1
	[SerializeField]private Canvas pauseMenu;
	[SerializeField]private Text scoreP1Text;
	[SerializeField]private Text scoreP2Text;
	static int scoreP1;
	static int scoreP2;
	private bool paused = false;

	// Use this for initialization
	void Start () {

		//Initialize Pause Menu to not appear
		paused = false;

		//Initialize Scores
		scoreP1 = 0;
		scoreP2 = 0;

		//Initiallize Walls
		leftWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
		leftWall.offset = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x - 0.5f, 0f);

		rightWall.size = new Vector2 (1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height * 2f, 0f)).y);
		rightWall.offset = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width, 0f, 0f)).x + 0.5f, 0f);

		upWall.transform.localScale = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width,0f,0f)).x , 0.5f, 1f);
		upWall.transform.position = new Vector3 (mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x-1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height, 0f)).y, 0f);

		downWall.transform.localScale = new Vector3(mainCam.ScreenToWorldPoint(new Vector3(Screen.width,0f,0f)).x , 0.5f, 1f);
		downWall.transform.position = new Vector3 (mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).x-1f, mainCam.ScreenToWorldPoint (new Vector3 (0f, 0f, 0f)).y, 0f);

		//Initialize Players
		player1.transform.position = new Vector3 (mainCam.ScreenToWorldPoint (new Vector3 (30f, 0f, 0f)).x, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height/2, 0f)).y, 0f);
		player2.transform.position = new Vector3 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width - 30f, 0f, 0f)).x, mainCam.ScreenToWorldPoint (new Vector3 (0f, Screen.height/2, 0f)).y, 0f);
	}
	
	//Update is called once per frame
	void Update () {

		//Update score text
		scoreP1Text.text = scoreP1.ToString ();
		scoreP2Text.text = scoreP2.ToString ();

		//Update Pause Menu
		if (Input.GetButtonDown("Pause") || CrossPlatformInputManager.GetButtonDown("PauseButton")) 
		{
			paused = !paused;
		}

		if (paused) 
		{
			pauseMenu.gameObject.SetActive(true);
			Time.timeScale = 0;
		}

		if (!paused) 
		{
			pauseMenu.gameObject.SetActive(false);
			Time.timeScale = 1;
		}
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

		if (scoreP1 > 4 || scoreP2 > 4) 
		{
				SceneManager.LoadScene (0);
		}
	}

	//methods for pause menu

	public void restartScript()
	{
		SceneManager.LoadScene (1); //loads current scene
	}

	public void resumeScript()
	{
		paused = false;
	}

	public void mainmenuScript()
	{
		SceneManager.LoadScene (0);//loads main menu
	}
}