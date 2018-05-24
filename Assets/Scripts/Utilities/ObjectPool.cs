using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH TO ObjectPool gameObject

public class ObjectPool : MonoBehaviour {

	public static ObjectPool instance;

	GenericObject<ThrowObject> sandalA;

	GenericObject<ThrowObject> sandalB;

	GenericObject<ThrowObject> bread;

	GenericObject<ThrowObject> hammer;

	GenericObject<ThrowObject> pot;

    GenericObject<RedEnemy> redEnemies;

	GenericObject<PoofEffect> poofEffect;

    GenericObject<PickupParticle> pickupEffect;

    GenericObject<CFXM_Hit_Green> CFXM_Hit_Green;

    void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
        redEnemies = new GenericObject<RedEnemy>(ObjectFactory.PrefabType.Enemy,2);
		poofEffect = new GenericObject<PoofEffect>(ObjectFactory.PrefabType.PoofEffect,4);
		CFXM_Hit_Green = new GenericObject<CFXM_Hit_Green>(ObjectFactory.PrefabType.CFXM_Hit_Green,2);
		sandalA = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.SandalA,1);
		sandalB = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.SandalB,1);
		bread = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.Bread,1);
		hammer = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.Hammer,1);
		pot = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.Pot,1);
        pickupEffect = new GenericObject<PickupParticle>(ObjectFactory.PrefabType.PickupParticle, 3);
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

	public ThrowObject GetSandalA()
	{
		return sandalA.GetObj ();
	}

	public ThrowObject GetSandalB()
	{
		return sandalB.GetObj ();
	}

	public ThrowObject GetBread()
	{
		return bread.GetObj ();
	}

	public ThrowObject GetHammer()
	{
		return hammer.GetObj ();
	}

	public ThrowObject GetPot()
	{
		return pot.GetObj ();
	}

    public PickupParticle GetPickupParticle()
    {
        return pickupEffect.GetObj();
    }
}
