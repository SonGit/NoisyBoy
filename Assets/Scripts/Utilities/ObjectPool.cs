using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH TO ObjectPool gameObject

public class ObjectPool : MonoBehaviour {

	public static ObjectPool instance;

	GenericObject<ThrowObject> sandalA;

    GenericObject<RedEnemy> redEnemies;

	GenericObject<PoofEffect> poofEffect;

	GenericObject<CFXM_Hit_Green> CFXM_Hit_Green;

    void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

		sandalA = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.Sandal,1);
        redEnemies = new GenericObject<RedEnemy>(ObjectFactory.PrefabType.Enemy,2);
		poofEffect = new GenericObject<PoofEffect>(ObjectFactory.PrefabType.PoofEffect,2);
		CFXM_Hit_Green = new GenericObject<CFXM_Hit_Green>(ObjectFactory.PrefabType.CFXM_Hit_Green,1);
    }
		
	public ThrowObject GetSandalA()
	{
		return sandalA.GetObj ();
	}

    public RedEnemy GetRedEnemy()
    {
        return redEnemies.GetObj();
    }

	public PoofEffect GetPoofEffect()
	{
		return poofEffect.GetObj();
	}

	public CFXM_Hit_Green GetCFXM_Hit_Green()
	{
		return CFXM_Hit_Green.GetObj();
	}
}
