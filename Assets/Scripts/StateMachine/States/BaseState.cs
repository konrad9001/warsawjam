using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState {

    protected GameController gameController;

    public virtual void InitState(GameController controller)
    {
        this.gameController = controller;
    }

    public virtual void UpdateState(GameController controller) { }

    public virtual void DeinitState(GameController controller) { }
}
