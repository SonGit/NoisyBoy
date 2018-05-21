using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofEffect : Cacheable {

	ParticleSystem[] particles;

	void Start () {
		particles = this.GetComponentsInChildren<ParticleSystem> ();

	}

	public override void OnLive ()
	{
        gameObject.SetActive(true);
        particles = this.GetComponentsInChildren<ParticleSystem> ();
		foreach (ParticleSystem particle in particles) {
			particle.Play ();
		}
        StartCoroutine(Countdown());
    }

	public override void OnDestroy ()
	{
        gameObject.SetActive(false);
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Destroy();
    }
}
