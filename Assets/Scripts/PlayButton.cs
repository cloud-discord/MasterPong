using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
	private int couter;

	public GameObject MainCanvas;
	public GameObject OptionsCanvas;
	public GameObject PlayOptionsCanvas;

	void Awake(){
		try{
			MainCanvas.SetActive (true);
			OptionsCanvas.SetActive(false);
			PlayOptionsCanvas.SetActive(false);
		}
		catch(Exception ex) {
			Debug.Log (ex.ToString ());
		}
	}

	public void OptionsOn(){
		try{
			MainCanvas.SetActive (false);
			OptionsCanvas.SetActive(true);
			PlayOptionsCanvas.SetActive(false);
		}
		catch(Exception ex) {
			Debug.Log (ex.ToString ());
		}
	}

	public void ReturnOn(){
		try{
		OptionsCanvas.gameObject.SetActive(false);
		MainCanvas.gameObject.SetActive(true);
		PlayOptionsCanvas.SetActive(false);
		}
		catch(Exception ex){
			Debug.Log (ex.ToString ());
		}
	}
	public void PlayOptions(){
		try{
		OptionsCanvas.SetActive(false);
		MainCanvas.SetActive(false);
		PlayOptionsCanvas.SetActive(true);
		}
		catch(Exception ex){
			Debug.Log (ex.ToString ());
		}
	}
		

	public void easyMode()
	{
		AILogic.difficulty = 0.75f;
		BallLogic.difficulty = 0.75f; 
		SceneManager.LoadScene (1);
	}

	public void mediumMode()
	{
		AILogic.difficulty = 0.9f;
		BallLogic.difficulty = 0.85f; 
		SceneManager.LoadScene (1);
	}

	public void hardMode()
	{
		AILogic.difficulty = 1f;
		BallLogic.difficulty = 1f; 
		SceneManager.LoadScene (1);
	}
}
