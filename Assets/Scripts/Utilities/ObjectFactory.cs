using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH TO ObjectFactory gameObject
public class ObjectFactory: MonoBehaviour {

	public static ObjectFactory instance;

	void Awake()
	{
		instance = this;
	}

	void Start () {
	}

	public enum PrefabType
	{
		None,
		Enemy,
		AudioSource,
		Explosion1,
		PoofEffect,
		Sandal,
		CFXM_Hit_Green
	}

	public Dictionary<PrefabType,string> PrefabPaths = new Dictionary<PrefabType, string> {
		
		{ PrefabType.None, "" },
		{ PrefabType.Enemy, "Prefabs/Enemy" },
		{ PrefabType.AudioSource, "Prefabs/AudioSource" },
		{ PrefabType.Explosion1, "Prefabs/Explosion1" },
		{ PrefabType.PoofEffect, "Prefabs/PoofEffect" },
		{ PrefabType.Sandal, "Prefabs/SandalA" },
		{ PrefabType.CFXM_Hit_Green, "Prefabs/CFXM_Hit_Green" },
	};

	public GameObject MakeObject(PrefabType type)
	{
		string path;
		if (PrefabPaths.TryGetValue (type, out path)) {
			return (Instantiate (Resources.Load (path, typeof(GameObject))) as GameObject);
		}
		print ("NULL");
		return null;
	}

}
