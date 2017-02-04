using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
	private int couter;

	public Canvas MainCanvas;
	public Canvas OptionsCanvas;

	void Awake(){
		OptionsCanvas.enabled = false;
	}

	public void OptionsOn(){
		OptionsCanvas.enabled = true;
		MainCanvas.enabled = false;
	}

	public void ReturnOn(){
		OptionsCanvas.enabled = false;
		MainCanvas.enabled = true;
	}
		
	public void LoadOn(){
		SceneManager.LoadScene (1);
	}

}
