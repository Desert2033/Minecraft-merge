using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private Merge _mergeSystem;

    [SerializeField] private FightSystem _fightSystem;

    [SerializeField] private GameObject _panelPreview;

    public GameStateTypes GameStateType { get; private set; }

    private void Start()
    {
        MakeGameStatePreview();
    }

    public void MakeGameStateBattle()
    {
        GameStateType = GameStateTypes.Battle;

        _mergeSystem.gameObject.SetActive(false);

        _fightSystem.gameObject.SetActive(true);

        _panelPreview.SetActive(false);
    }

    public void MakeGameStatePreview()
    {
        GameStateType = GameStateTypes.Preview;

        _mergeSystem.gameObject.SetActive(true);

        _fightSystem.gameObject.SetActive(false);

        _panelPreview.SetActive(true);
    }
}
