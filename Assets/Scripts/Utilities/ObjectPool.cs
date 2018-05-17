using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH TO ObjectPool gameObject

public class ObjectPool : MonoBehaviour {

	public static ObjectPool instance;

	GenericObject<Sandal> sandal;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

		sandal = new GenericObject<Sandal>(ObjectFactory.PrefabType.Sandal,20);
	}
		


	public Sandal GetSandal()
	{
		return sandal.GetObj ();
	}
}
