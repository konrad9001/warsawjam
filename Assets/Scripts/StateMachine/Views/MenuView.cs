using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : BaseView {

    public IMenuView listener;
    [SerializeField] Animator menuViewAnimator;


    public override void ShowView()
    {
        base.ShowView();
    }

    public override void HideView()
    {
        base.HideView();
    }

    public void SetGameState()
    {
        menuViewAnimator.SetBool(Keys.WeaponsAnimations.ON, true);
        //HideView();
        listener.SetGameState();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
