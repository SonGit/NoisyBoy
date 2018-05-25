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
		redEnemy,
		AudioSource,
		PoofEffect,
		SandalA,
		SandalB,
		Bread,
		Hammer,
		Pot,
        PickupParticle,
		HitEffect,

	}

	public Dictionary<PrefabType,string> PrefabPaths = new Dictionary<PrefabType, string> {
		
		{ PrefabType.None, "" },
		{ PrefabType.redEnemy, "Prefabs/Enemy" },
		{ PrefabType.AudioSource, "Prefabs/AudioSource" },
		{ PrefabType.PoofEffect, "Prefabs/PoofEffect" },
		{ PrefabType.HitEffect, "Prefabs/HitEffect" },
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
