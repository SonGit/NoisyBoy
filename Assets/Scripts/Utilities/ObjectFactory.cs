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
		SandalA,
		SandalB,
		Bread,
		Hammer,
		Pot,
        PickupParticle,
        CFXM_Hit_Green
	}

	public Dictionary<PrefabType,string> PrefabPaths = new Dictionary<PrefabType, string> {
		
		{ PrefabType.None, "" },
		{ PrefabType.Enemy, "Prefabs/Enemy" },
		{ PrefabType.AudioSource, "Prefabs/AudioSource" },
		{ PrefabType.PoofEffect, "Prefabs/PoofEffect" },
		{ PrefabType.CFXM_Hit_Green, "Prefabs/CFXM_Hit_Green" },
		{ PrefabType.SandalA, "Prefabs/SandalA" },
		{ PrefabType.SandalB, "Prefabs/SandalB" },
		{ PrefabType.Bread, "Prefabs/Bread" },
		{ PrefabType.Hammer, "Prefabs/Hammer" },
		{ PrefabType.Pot, "Prefabs/Pot" },
        { PrefabType.PickupParticle, "Prefabs/PickupParticle" },
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
