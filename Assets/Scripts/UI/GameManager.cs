using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The Game manager is a state machine, that will switch between state according to current gamestate.
/// </summary>
public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject objScore;
	public GameObject objHighScore;

	public State[] states;
	public List<State> stateStack = new List<State>();
	protected Dictionary<string, State> stateDict = new Dictionary<string, State>();

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		objScore.SetActive (false);
		objHighScore.SetActive (false);

		// We build a dictionnary from state for easy switching using their name.
		stateDict.Clear();

		if (states.Length == 0)
			return;

		for(int i = 0; i < states.Length; ++i)
		{
			stateDict.Add(states[i].GetName(), states[i]);
		}

		stateStack.Clear();
		PushState(states[0].GetName());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			Application.Quit(); 
		}
	}
		
	public void ShowGamePlay()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		SwitchState("GamePLay");
	}

	public void ShowGameOver ()
	{
		SwitchState("GameOver");
	}

	public void ShowSetting ()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		SwitchState("Setting");
	}

	public void HideSetting ()
	{
		AudioManager_RB.instance.PlayClip (AudioManager_RB.SoundFX.ButtonPresses,transform.position);
		SwitchState("MainMenu");
	}
		
	public void ReStartGame ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Player.Score = 0;
	}

	public void SwitchState(string newState)
	{
		State state = FindState(newState);
		if (state == null)
		{
			Debug.LogError("Can't find the state named " + newState);
			return;
		}

		stateStack[stateStack.Count - 1].Exit(state);
		state.Enter(stateStack[stateStack.Count - 1]);
		stateStack.RemoveAt(stateStack.Count - 1);
		stateStack.Add(state);
	}

	public State FindState(string stateName)
	{
		State state;
		if (!stateDict.TryGetValue(stateName, out state))
		{
			return null;
		}

		return state;
	}

	public void PushState(string name)
	{
		State state;
		if(!stateDict.TryGetValue(name, out state))
		{
			Debug.LogError("Can't find the state named " + name);
			return;
		}

		if (stateStack.Count > 0)
		{
			stateStack[stateStack.Count - 1].Exit(state);
			state.Enter(stateStack[stateStack.Count - 1]);

		}
		else
		{
			state.Enter(null);
		}

		stateStack.Add(state);
	}
}
