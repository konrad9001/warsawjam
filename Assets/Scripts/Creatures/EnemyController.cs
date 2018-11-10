using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    List<BaseEnemy> listOfEnemies;

    [SerializeField]
    private GameObject dynamicParent;

    public void UpdateEnemySeenStatus()
    {
        foreach (var val in listOfEnemies)
            val.UpdateSeenStatus();
    }

    public bool CheckIfMutantIsSeen()
    {
        foreach (var val in listOfEnemies)
        {
            if (val.name.Equals("mutant"))
                return val.GetSeen();
        }
        return false;
    }

    public bool CheckIfNormalIsSeen()
    {
        foreach (var val in listOfEnemies)
        {
            if (val.name.Equals("normalEnemy"))
                return val.GetSeen();
        }
        return false;
    }

    public bool CheckIfFastIsSeen()
    {
        foreach (var val in listOfEnemies)
        {
            if (val.name.Equals("fastEnemy"))
                return val.GetSeen();
        }
        return false;
    }

    public void UpdateEnemies(Transform playerTransform)
    {
        foreach(BaseEnemy b in listOfEnemies)
        {
            b.UpdateEnemy(playerTransform);
        }
    }

    public void DisableRenderers()
    {
        foreach(BaseEnemy b in listOfEnemies)
        {
            b.GetRenderer().enabled = false;
        }
    }

    public void EnableMeshes()
    {
        foreach(BaseEnemy b in listOfEnemies)
        {
            b.GetRenderer().enabled = true;
        }
    }
	
    
}
