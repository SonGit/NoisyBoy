using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public static Player instance;

	public GameObject rendererPlace;
	public int currentLife;
	public static int Score = 0;
	public static int highScore;
	public Text lifeText;


	private int maxLife = 100;
	private bool isPlayerUndying;
	private float playerUndyingTimeCount;
	private Renderer[] playerRenderers;

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		currentLife = maxLife;
		playerRenderers = rendererPlace.GetComponentsInChildren<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		lifeText.text = "Live: " + currentLife;

		if (!isPlayerUndying) {
			return;
		}

		playerUndyingTimeCount += Time.deltaTime;


	}


	public void OnHitThrowObj (ThrowObject throwObj)
	{
		if (currentLife <= 0 || !throwObj.isKillPlayer) {
			return;
		}
	
		Killed ();
		throwObj.CFXM_Hit_GreenEffect (throwObj.transform);
	}


	private void Killed()
	{
		if (!isPlayerUndying) 
		{
			currentLife -= 1;

			if (currentLife > 0)
			{
				PlayerUndying ();
			}
			else
			{
				Debug.Log ("Die");

			}
		}

	}

	private IEnumerator RendererPlayer()
	{
		isPlayerUndying = true;
		while (isPlayerUndying && playerUndyingTimeCount < 2.9f) {
			foreach (Renderer renderer in playerRenderers) 
			{
				yield return new WaitForSeconds (0.2f);
				renderer.gameObject.SetActive (false);
				yield return new WaitForSeconds (0.2f);
				renderer.gameObject.SetActive (true);
			}
		}
		playerUndyingTimeCount = 0;
		isPlayerUndying = false;

	}

	public void PlayerUndying ()
	{
		StartCoroutine (RendererPlayer());
	}

	Player player;
	public bool CheckIfAPlayer(Transform targetTransform)
	{
		player = targetTransform.GetComponent<Player> ();

		if (player != null)
			return true;

		return false;
	}


}
