using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour {

	public abstract void Enter(State from);
	public abstract void Exit(State to);

	public abstract string GetName();
}
