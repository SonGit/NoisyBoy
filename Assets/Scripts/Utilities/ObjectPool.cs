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

	GenericObject<HitEffect> hitEffect;

	GenericObject<AudioSource_RB> audioSource;

    void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		redEnemies = new GenericObject<RedEnemy>(ObjectFactory.PrefabType.redEnemy,2);
		poofEffect = new GenericObject<PoofEffect>(ObjectFactory.PrefabType.PoofEffect,2);
		hitEffect = new GenericObject<HitEffect>(ObjectFactory.PrefabType.HitEffect,2);
		sandalA = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.SandalA,2);
		sandalB = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.SandalB,2);
		bread = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.Bread,2);
		hammer = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.Hammer,2);
		pot = new GenericObject<ThrowObject>(ObjectFactory.PrefabType.Pot,2);
        pickupEffect = new GenericObject<PickupParticle>(ObjectFactory.PrefabType.PickupParticle, 3);
		audioSource = new GenericObject<AudioSource_RB>(ObjectFactory.PrefabType.AudioSource,6);
    }
		

    public RedEnemy GetRedEnemy()
    {
        return redEnemies.GetObj();
    }

	public PoofEffect GetPoofEffect()
	{
		return poofEffect.GetObj();
	}

	public HitEffect GetHitEffect()
	{
		return hitEffect.GetObj();
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

	public AudioSource_RB GetAudioSource()
	{
		return audioSource.GetObj ();
	}
}
