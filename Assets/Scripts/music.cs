using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour {

	private AudioSource AS;
	private AudioSource[] AllAudioSources;
	private static music instance;
	public static int counter;

	void Awake(){
		if (instance != null && instance != this){
			//Do nothing
			}

		else{
			instance = this;
			AS = GetComponent<AudioSource> (); //Audio source of this button
			AS.Play();
			AS.enabled = true;
			AS.loop = true;
			counter = 1;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void Start (){
		if (instance != null && instance != this){
			AS = GetComponent<AudioSource> ();
			if (counter == 0){
				//Debug.Log ("false");
				AS.enabled = false;
			}
			else{
				//Debug.Log ("true");
				AS.enabled = true;
			}
			AllAudioSources = GameObject.FindObjectsOfType (typeof(AudioSource)) as AudioSource[]; //all audio sources
		} 

		else{
			AS = GetComponent<AudioSource> (); //Audio source of this button
			//AS.Stop();
			AS.enabled = true;
			AS.loop = true;
			AllAudioSources = GameObject.FindObjectsOfType (typeof(AudioSource)) as AudioSource[]; //all audio sources
		}
	}

	void StopAllAudio(){
		foreach (AudioSource Audio in AllAudioSources){
			Audio.enabled = false;
			Audio.Stop();
			AS.enabled = false;
		}
	}

	void Clicked(){
		if (AS.enabled == true){
			counter = 0;
			//Debug.Log ("som off");
			StopAllAudio ();
		} 
		else{
			//Debug.Log ("som on");
			counter = 1;
			AS.enabled = true;
			AS.Play ();
		}
	}
		
	public void OnMouseDown(){
		Clicked ();
	}
}



