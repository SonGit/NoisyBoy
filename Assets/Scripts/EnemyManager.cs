using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject buildingObj;

    public float rate;

    Door[] doors;

	// Use this for initialization
	IEnumerator Start () {
        doors = buildingObj.GetComponentsInChildren<Door>();
        yield return new WaitForSeconds(1);

        while(true)
        {
            Spawn();
            yield return new WaitForSeconds(rate);
        }
      
    }
	
	public void Spawn()
    {
        List<Door> freeWindow = GetFreeWindows();
        if(freeWindow.Count == 0)
        {
            Debug.Log("NO WINDOWS FOUND!");
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
