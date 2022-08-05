using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameStateTypes GameStateType { get; private set; }

    public void Awake()
    {
        GameStateType = GameStateTypes.Preview;
    }

    public void MakeGameStateBattle()
    {
        GameStateType = GameStateTypes.Battle;
    }

    public void MakeGameStatePreview()
    {
        GameStateType = GameStateTypes.Preview;
    }

}
