using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    [SerializeField]
    MenuViewController menuViewController;
    public MenuViewController MenuViewController { get { return menuViewController; } }

    [SerializeField]
    GameViewController gameViewController;
    public GameViewController GameViewController { get { return gameViewController; } }
}
