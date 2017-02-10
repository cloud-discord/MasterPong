using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour {

	private AudioSource AS;
	private AudioSource[] AllAudioSources;
	private static music instance;

	void Awake(){
		if (instance != null && instance != this){
			//Debug.Log ("kek");
			//AS.enabled = false;
			}
			//Destroy(this.gameObject);
			//return;
		else{
			instance = this;
			AS = GetComponent<AudioSource> (); //Audio source of this button
			AS.Play();
			AS.enabled = true;
			AS.loop = true;
		}
		DontDestroyOnLoad(this.gameObject);

	}

	void Start (){
		AS = GetComponent<AudioSource> (); //Audio source of this button
		//AS.Stop();
		AS.enabled = true;
		AS.loop = true;
		AllAudioSources = GameObject.FindObjectsOfType (typeof(AudioSource)) as AudioSource[]; //all audio sources
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
			//Debug.Log ("leeeeeeeeeeeeeeeeeeeeel");
			StopAllAudio ();
		} 
		else{
			//Debug.Log ("bur");
			AS.enabled = true;
			AS.Play ();
		}
	}
		
	public void OnMouseDown(){
		Clicked ();
	}
}



