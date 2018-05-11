using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cacheable : MonoBehaviour {

	private bool isInPool;
	public bool _isInPool
	{
		get 
		{
			return isInPool;
		}

		set 
		{
			isInPool = value;
		}
	}

	void Start()
	{
	//	Destroy ();// default state
	}

	public void Destroy()
	{
		OnDestroy ();
		_isInPool = false;
		//gameObject.hideFlags = HideFlags.HideInHierarchy;
	}

	public void Live()
	{
		OnLive ();
		_isInPool = true;
		//gameObject.hideFlags = HideFlags.HideInHierarchy;
	}

	public abstract void OnDestroy ();
	public abstract void OnLive ();
}
