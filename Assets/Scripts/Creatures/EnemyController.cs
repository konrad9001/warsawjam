using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    List<BaseEnemy> listOfEnemies;

    [SerializeField]
    private GameObject dynamicParent;


    public void UpdateEnemies(Transform playerTransform)
    {
        foreach(BaseEnemy b in listOfEnemies)
        {
            Debug.Log("Updating Enemies");
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
