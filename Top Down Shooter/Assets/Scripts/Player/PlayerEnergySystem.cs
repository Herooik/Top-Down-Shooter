using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergySystem : MonoBehaviour
{
    public float CurrentEnergy { get; set; }

    [SerializeField] private float maxEnergy = 150f;
    [SerializeField] private Image energyBar;
    [SerializeField] private TextMeshProUGUI energyText;

    private void Start()
    {
        CurrentEnergy = maxEnergy;
        
        energyText.text = CurrentEnergy + "/" + maxEnergy;
    }

    public void AbsorbEnergy(int energyConsumption)
    {
        CurrentEnergy -= energyConsumption;
        
        energyBar.fillAmount = CurrentEnergy / maxEnergy;
        
        energyText.text = CurrentEnergy + "/" + maxEnergy;
    }
    
    public void GiveEnergy(float energyAmount)
    {
        var energyMissing = maxEnergy - CurrentEnergy;

        if (energyMissing < energyAmount)
        {
            CurrentEnergy += energyMissing;
        }
        else
        {
            CurrentEnergy += energyAmount;
        }

        UpdateEnergyBar();
    }

    private void UpdateEnergyBar()
    {
        energyBar.fillAmount = CurrentEnergy / maxEnergy;

        energyText.text = CurrentEnergy + "/" + maxEnergy;
    }
}
