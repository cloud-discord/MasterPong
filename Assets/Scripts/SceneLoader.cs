using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	private bool loadScene = false;

	[SerializeField]
	private int scene;
	private bool sceneLoaded = false;
	[SerializeField]
	private Text loadingText;
	AsyncOperation async;

	void Start()
	{
		Time.timeScale = 1;
	}

	// Updates once per frame
	void Update() {

		if (sceneLoaded && loadScene == false)
		{
			if (Input.touchCount > 0)
				activateScene();
		}
		// If the player has pressed the space bar and a new scene is not loading yet...
		else if (loadScene == false) {

			// ...set the loadScene boolean to true to prevent loading a new scene more than once...
			loadScene = true;

			// ...change the instruction text to read "Loading..."
			loadingText.text = "Loading...";

			// ...and start a coroutine that will load the desired scene.
			StartCoroutine(LoadNewScene());

		}

		// If the new scene has started loading...
		else if (loadScene == true) {

			// ...then pulse the transparency of the loading text to let the player know that the computer is still working.
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));


		}

	}


	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene() {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		async = SceneManager.LoadSceneAsync(scene);
		async.allowSceneActivation = false;

		if (!async.isDone) {
			yield return new WaitForSeconds (3);
		}
		sceneLoaded = true;
		loadScene = false;
		loadingText.text = "Touch to continue!";
		loadingText.color = Color.white;
		yield return async;
		


	}

	private void activateScene()
	{
		async.allowSceneActivation = true;
	}

}