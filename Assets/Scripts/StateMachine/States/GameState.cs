using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState, IGameView, IPlayer{

    public override void InitState(GameController controller)
    {
        base.InitState(controller);
        this.gameController.UIController.GameViewController.GameView.listener = this;
        this.gameController.UIController.GameViewController.GameView.ShowView();
        this.gameController.Player.listener = this;
        gameController.EnemyController.DisableRenderers();
        gameController.gun.gameObject.SetActive(true);
    }

    public override void UpdateState(GameController controller)
    {
        base.UpdateState(controller);
        if (Cursor.lockState != CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.Locked;
        GetPlayerInput();
        UpdateEnemyStatus();
        if (gameController.Player.GetWieldedWeapon().Equals(Keys.Weapons.SHOTGUN))
            gameController.Player.GetShotgun().Reload();
        gameController.Player.GetPlayerShooting().UpdateTime();
        gameController.Player.GetNegativeCamera().UpdateTimer();
        gameController.EnemyController.UpdateEnemySeenStatus();
    }

    public override void DeinitState(GameController controller)
    {
        base.DeinitState(controller);
        if (Cursor.lockState != CursorLockMode.None)
            Cursor.lockState = CursorLockMode.None;
        gameController.cam.gameObject.SetActive(false);
        gameController.gun.gameObject.SetActive(false);
    }

    public void SetMenuState()
    {
        gameController.ChangeState(new MenuState());
    }

    public void GetPlayerInput()
    {
        gameController.Player.GetPlayerInput();
    }

    public void UpdateEnemyStatus()
    {
        if (gameController.Player.GetWieldedWeapon().Equals(Keys.Weapons.SHOTGUN))
        {
            gameController.EnemyController.DisableRenderers();
        }
        else
        {
            gameController.EnemyController.EnableMeshes();
        }

        gameController.EnemyController.UpdateEnemies(gameController.Player.gameObject.transform);
    }

}
