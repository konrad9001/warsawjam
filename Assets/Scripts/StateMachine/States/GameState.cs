using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState, IGameView, IPlayer, INegativeCamera, IWinView, IGameOverView{
    float dead = 2f;
    bool start = false;
    public override void InitState(GameController controller)
    {
        base.InitState(controller);
        this.gameController.UIController.GameViewController.GameView.listener = this;
        this.gameController.UIController.GameViewController.GameView.ShowView();
        this.gameController.Player.listener = this;
        gameController.EnemyController.DisableRenderers();
        gameController.gun.gameObject.SetActive(true);
        this.gameController.UIController.GameViewController.WinView.listener = this;
        this.gameController.Player.GetComponent<PlayerWeapon>().GetCamera().listener = this;
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
        gameController.Player.GetComponent<PlayerWeapon>().GetCamera().UpdateNumberOfDeathOponent();
        if (start)
        {
            dead -= Time.deltaTime;
            if (dead < 0)
            {
                gameController.UIController.GameViewController.GameOverView.ShowView();
                Cursor.lockState = CursorLockMode.None;
            }
                
        }
           
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

    public void PlayerIsDead()
    {
        start = true;
    }

    public bool CheckMutant()
    {
        return gameController.EnemyController.CheckIfMutant();
    }

    public bool CheckNormal()
    {
        return gameController.EnemyController.CheckIfSlow();
    }

    public bool CheckFast()
    {
        return gameController.EnemyController.CheckIfFast();
    }

    public int GetNumberOfDeathOponent()
    {
        return gameController.EnemyController.GetNumberOfDeathOponent();
    }

    public string FoundVictims()
    {
        return gameController.negativeCamera.GetChallenges().photographyOfTheVictimsCounter.ToString();
    }

    public string PhotographedMonsters()
    {
        int sum = 0;
        if (gameController.negativeCamera.GetChallenges().fastEnemyPhotoTaken)
            sum++;
        if (gameController.negativeCamera.GetChallenges().slowEnemyPhotoTaken)
            sum++;
        if (gameController.negativeCamera.GetChallenges().mutantPhotoTaken)
            sum++;
        return sum.ToString();
    }

    public float TimeOfTheGame()
    {
        return gameController.negativeCamera.GetChallenges().timeOfTheGame;
    }

    public string KilledMonsters()
    {
        return gameController.negativeCamera.GetChallenges().enemyKillCounter.ToString();
    }

    public void WinOfTheGame()
    {
        gameController.UIController.GameViewController.WinView.ShowView();
    }

}
