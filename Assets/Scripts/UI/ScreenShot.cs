using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Threading;

public class ScreenShot : MonoBehaviour {

	private static ScreenShot _instance;

	public static ScreenShot Instance
	{
		get { return _instance; }
	}
		
	private void Awake ()
	{
		if (_instance == null) 
		{
			_instance = this;
		}
	}

	[HideInInspector]
	public Texture2D screenTexture;

	public Image screenShot;


	// Use this for initialization
	void Start () {
	}

	public IEnumerator TakeScreenShot ()
	{
		// Take the screenshot

		// wait for graphics to render
		yield return new WaitForEndOfFrame();

		// put buffer into texture
		screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);
	

		for (int i = 0; i < 9; i++)
		{
			yield return null;
		}

		// apply
		screenTexture.Apply();
	

		for (int i = 0; i < 9; i++)
		{
			yield return null;
		}

		Sprite sprite = Sprite.Create (screenTexture, new Rect (0, 0, screenTexture.width, screenTexture.height), new Vector2 (0.5f, 0.5f));
		screenShot.GetComponent<Image>().sprite = sprite;
	
	}
		

}
