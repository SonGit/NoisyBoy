using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH TO ObjectPool gameObject

public class ObjectPool : MonoBehaviour {

	public static ObjectPool instance;

	GenericObject<Sandal> sandal;

    GenericObject<RedEnemy> redEnemies;

    void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

		sandal = new GenericObject<Sandal>(ObjectFactory.PrefabType.Sandal,2);
        redEnemies = new GenericObject<RedEnemy>(ObjectFactory.PrefabType.Enemy,5);

    }
		
	public Sandal GetSandal()
	{
		return sandal.GetObj ();
	}

    public RedEnemy GetRedEnemy()
    {
        return redEnemies.GetObj();
    }
}
