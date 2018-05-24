using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour {

	public static Player instance;

	public GameObject rendererPlace;
	public int currentLife;
	public static int Score = 0;
	public static int highScore;
	[HideInInspector]
	public bool isPlayerUndying;
	public TextMeshProUGUI scoreText;

    private int maxLife = 3;
	private float playerUndyingTimeCount;
	private Renderer[] playerRenderers;

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		highScore = Score;
		currentLife = maxLife;
		playerRenderers = rendererPlace.GetComponentsInChildren<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
       
        if(scoreText != null)
        scoreText.text = "Score: " + Score;

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
			currentLife -= 3;

			if (currentLife > 0)
			{
				if (AudioManager_RB.instance != null) {
					AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.hitSound,transform.position);
					StartCoroutine (MusicThemeManager.instance.PauseMusicTrumpet());
				}
					
				PlayerUndying ();
			}
			else
			{
				DataController.instance.SubmitNewPlayerScore (Player.Score);
				GameManager.instance.objHighScore.SetActive (true);
				StartCoroutine( ScreenShot.Instance.TakeScreenShot ());
				GameManager.instance.ShowGameOver ();
				StartCoroutine( WaitDestroyPlayer ());
				AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.PlayerDeath,transform.position);

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

    ThrowObject throwObj;
    void OnTriggerStay(Collider other)
    {
		if (currentLife <= 0) {
			return;
		}

        throwObj = other.GetComponent<ThrowObject>();
        if(throwObj != null)
        {
            if(!throwObj.isKillPlayer)
            {
                throwObj.PickedUp();
                Score++;
            }
        }

    }

	private IEnumerator WaitDestroyPlayer ()
	{

		foreach (Renderer renderer in playerRenderers) 
		{
			yield return new WaitForSeconds (0.05f);
			renderer.gameObject.SetActive (false);
		}
	}
}
