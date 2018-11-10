using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameViewController : MonoBehaviour {
    [SerializeField]
    private GameView gameView;
    public GameView GameView { get { return gameView; } }

    [SerializeField]
    private GameOverView gameOverView;
    public GameOverView GameOverView { get { return gameOverView; } }

    [SerializeField]
    private WinView winView;
    public WinView WinView { get { return winView; } }

}
