using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    List<BaseEnemy> listOfEnemies;

    [SerializeField]
    private GameObject dynamicParent;
    [SerializeField]
    private Camera playerCamera;

    public void UpdateEnemySeenStatus()
    {
        foreach (BaseEnemy b in listOfEnemies)
            b.UpdateSeenStatus(playerCamera);

    }

    public bool CheckIfMutant()
    {
        foreach (var val in listOfEnemies)
            if (val.name.Equals("mutant"))
                return val.GetSeen();
        return false;
    }

    public bool CheckIfSlow()
    {
        foreach (var val in listOfEnemies)
            if (val.name.Equals("normalEnemy"))
                return val.GetSeen();
        return false;
    }

    public bool CheckIfFast()
    {
        foreach (var val in listOfEnemies)
            if (val.name.Equals("fastEnemy"))
                return val.GetSeen();
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
