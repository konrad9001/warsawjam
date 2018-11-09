using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameViewController : MonoBehaviour {
    [SerializeField]
    private GameView gameView;
    public GameView GameView { get { return gameView; } }
}
