using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergySystem : MonoBehaviour
{
    [SerializeField] private float maxEnergy = 150f;
    
    [SerializeField] private Image energyBar;
    [SerializeField] private TextMeshProUGUI energyText;
    
    [HideInInspector] public float currentEnergy;

    private void Start()
    {
        currentEnergy = maxEnergy;
        
        energyText.text = currentEnergy + "/" + maxEnergy;
    }

    public void AbsorbEnergy(int energyConsumption)
    {
        currentEnergy -= energyConsumption;
        
        energyBar.fillAmount = currentEnergy / maxEnergy;
        
        energyText.text = currentEnergy + "/" + maxEnergy;
    }
    
    public void GiveEnergy(float energyAmount)
    {
        var energyMissing = maxEnergy - currentEnergy;

        if (energyMissing < energyAmount)
        {
            currentEnergy += energyMissing;
        }
        else
        {
            currentEnergy += energyAmount;
        }

        UpdateEnergyBar();
    }

    private void UpdateEnergyBar()
    {
        energyBar.fillAmount = currentEnergy / maxEnergy;

        energyText.text = currentEnergy + "/" + maxEnergy;
    }
}
