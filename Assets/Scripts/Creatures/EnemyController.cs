using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    List<BaseEnemy> listOfEnemies;

    [SerializeField]
    private GameObject dynamicParent;

    void OnEnable()
    {
        listOfEnemies = new List<BaseEnemy>();
    }
	
    
}
