using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour {

	private AudioSource AS;
	private AudioSource[] AllAudioSources;

		void Awake()
		{
			AS = GetComponent<AudioSource> (); //Audio source of this button
			AS.enabled = true;
			AS.Play ();
		}

	

	void Start () {

		//AS.Stop();
		AS.enabled = true;
		AS.loop = true;
		AllAudioSources = GameObject.FindObjectsOfType (typeof(AudioSource)) as AudioSource[]; //all audio sources
	}

	void StopAllAudio() {
		foreach (AudioSource Audio in AllAudioSources) {
			Audio.Stop();
			Audio.enabled = false;

		}

	}
	void Clicked() {
		if (AS.enabled == true) {
			StopAllAudio ();
		} else {
			AS.enabled = true;
			AS.Play ();
		}
	}


	public void OnMouseDown() {
		Clicked ();
	}

}



