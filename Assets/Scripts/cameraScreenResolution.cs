using UnityEngine;
using System.Collections;

public class cameraScreenResolution : MonoBehaviour {
	
	public new Camera camera;

	// Use this for initialization
	void Start () {

		camera.aspect = 16f / 9f;
	}

	// Update is called once per frame
	void Update () {
		camera.aspect = 16f / 9f;
	}
}
