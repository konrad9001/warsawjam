using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState, IMenuView {
    float time = 2.5f;
    bool start = false;
    public override void InitState(GameController controller)
    {
        base.InitState(controller);
        this.gameController.UIController.MenuViewController.MenuView.listener = this;
        this.gameController.UIController.MenuViewController.MenuView.ShowView();
    }

    public override void UpdateState(GameController controller)
    {
        base.UpdateState(controller);
        if (start)
            SettingGameState();
    }

    public override void DeinitState(GameController controller)
    {
        base.DeinitState(controller);
    }

    public void SetGameState()
    {
        //gameController.ChangeState(new GameState());
        start = true;
    }

    void SettingGameState()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            gameController.UIController.MenuViewController.MenuView.HideView();
            gameController.ChangeState(new GameState());
            start = false;
        }
    }
}
