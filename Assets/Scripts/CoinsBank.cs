using UnityEngine;
using System;
using TMPro;

public class CoinsBank : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    
    private int _coins = 0;
    public int Coins => _coins;

    public event Action<int> OnChangeCoins;

    private void OnEnable()
    {
        _coinsText.text = $"{_coins}";
    }

    public void AddCoins(int coins)
    {
        if (coins < 0)
            throw new ArgumentOutOfRangeException($"{coins}");

        _coins += 0;

        _coinsText.text = $"{_coins}";

        OnChangeCoins?.Invoke(coins);
    }
}
