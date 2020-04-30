using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static CoinManager _instance;
    public static CoinManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var cm = new GameObject("Coin Manager");
                cm.AddComponent<CoinManager>();
            }

            return _instance;
        }
    }

    [SerializeField] private TextMeshProUGUI coinAmountText;
    public int CoinAmount { get; private set;}
    

    private void Awake()
    {
        _instance = this;
        coinAmountText.text = CoinAmount.ToString();
    }

    public void AddGold()
    {
        CoinAmount++;
        coinAmountText.text = CoinAmount.ToString();
    }

    public void RemoveGold(int amount)
    {
        CoinAmount -= amount;
        coinAmountText.text = CoinAmount.ToString();
    }
}
