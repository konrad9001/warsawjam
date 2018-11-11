using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinView : BaseView {
    public Text foundVictims;
    public Text photographedMonsters;
    public Text timeOfTheGame;
    public Text killedMonsters;
    public IWinView listener;

    public override void HideView()
    {
        base.HideView();
    }

    public override void ShowView()
    {
        foundVictims.text = listener.FoundVictims()+"/4";
        photographedMonsters.text = listener.PhotographedMonsters()+"/3";
        timeOfTheGame.text = string.Format("{0:00.00}", listener.TimeOfTheGame());
        killedMonsters.text = listener.KilledMonsters();
        base.ShowView();
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
