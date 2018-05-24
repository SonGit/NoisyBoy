using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public static EnemyManager instance;

    public GameObject buildingObj;

    public float rate;

	[HideInInspector]
	public bool isSpawn;

    public float degradeRate;

    Door[] doors;

	void Awake()
	{
		instance = this;
		this.enabled = false;
	}

	public void OnEnable ()
	{
		isSpawn = true;
		StartCoroutine (StartSpawn());
	}

	public void OnDisable ()
	{
		isSpawn = false;
	}

    void Update()
    {
        if(isSpawn)
        rate -= Time.deltaTime * degradeRate;

        if (rate < .5f)
            rate = .5f;
    }
		
	public void PauseSpawn ()
	{
		isSpawn = false;
	}

	// Use this for initialization
	public IEnumerator StartSpawn () {
        doors = buildingObj.GetComponentsInChildren<Door>();
        yield return new WaitForSeconds(1);

		while(isSpawn)
        {
            Spawn();
            float sec = (rate + (Random.Range(0, 1000)) / 1000f);
            yield return new WaitForSeconds(sec);
        }
      
    }
	
	private void Spawn()
    {
        List<Door> freeWindow = GetFreeWindows();
        if(freeWindow.Count == 0)
        {
            Debug.Log("NO WINDOWS FOUND!");
            return;
        }

        int ran = Random.Range(0, freeWindow.Count);

        freeWindow[ran].isFree = false;

        RedEnemy redEnemy = ObjectPool.instance.GetRedEnemy();

        redEnemy.Attack(freeWindow[ran]);
    }

    List<Door> GetFreeWindows()
    {
        List<Door> freeWindows =new List<Door>();
        foreach (Door door in doors)
        {
            if (door.isFree)
            {
                freeWindows.Add(door);
            }
        }

        return freeWindows;
    }
}
