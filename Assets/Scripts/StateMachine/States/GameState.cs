using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState, IGameView, IPlayer {

    public override void InitState(GameController controller)
    {
        base.InitState(controller);
        this.gameController.UIController.GameViewController.GameView.listener = this;
        this.gameController.UIController.GameViewController.GameView.ShowView();
        this.gameController.Player.listener = this;
    }

    public override void UpdateState(GameController controller)
    {
        base.UpdateState(controller);
        MovePlayerView();
    }

    public override void DeinitState(GameController controller)
    {
        base.DeinitState(controller);
    }

    public void SetMenuState()
    {
        gameController.ChangeState(new MenuState());
    }

    public void MovePlayerView()
    {
        gameController.Player.GetInputMovement();
    }

}
