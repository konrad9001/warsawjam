using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState, IMenuView {

    public override void InitState(GameController controller)
    {
        base.InitState(controller);
        this.gameController.UIController.MenuViewController.MenuView.listener = this;
        this.gameController.UIController.MenuViewController.MenuView.ShowView();
    }

    public override void UpdateState(GameController controller)
    {
        base.UpdateState(controller);
    }

    public override void DeinitState(GameController controller)
    {
        base.DeinitState(controller);
    }

    public void SetGameState()
    {
        gameController.ChangeState(new GameState());
    }
}
