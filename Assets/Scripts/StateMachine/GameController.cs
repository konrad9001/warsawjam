using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField]
    UIController uiController;
    public UIController UIController { get {return uiController; } }

    [SerializeField]
    Player player;
    public Player Player { get { return player; } }

    [SerializeField]
    EnemyController enemyController;
    public EnemyController EnemyController { get { return enemyController; } }


    private void Awake()
    {
        Initialization();
    }

    void Initialization()
    {
        ChangeState(new MenuState());
    }

    BaseState currentState;

    public void ChangeState(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.DeinitState(this);
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.InitState(this);
        }
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }
}
