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
		Explosion2,
		Explosion3,
		Explosion4,
		ScoreAddText
	}

	public Dictionary<PrefabType,string> PrefabPaths = new Dictionary<PrefabType, string> {
		
		{ PrefabType.None, "" },
		{ PrefabType.Enemy, "Prefabs/Enemy" },
		{ PrefabType.AudioSource, "Prefabs/AudioSource" },
		{ PrefabType.Explosion1, "Prefabs/Explosion1" },
		{ PrefabType.Explosion2, "Prefabs/Explosion2" },
		{ PrefabType.Explosion3, "Prefabs/Explosion3" },
		{ PrefabType.Explosion4, "Prefabs/Explosion4" },
		{ PrefabType.ScoreAddText, "Prefabs/ScoreAddText" },
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
