using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoSystem : MonoBehaviour
{
    [SerializeField] private float _maxAmmo = 150f;
    private float _currentAmmo;
    [SerializeField] private Image _ammoBar;
    [SerializeField] private TextMeshProUGUI _ammoText;

    private void Start()
    {
        _currentAmmo = _maxAmmo;
        
        _ammoText.text = _currentAmmo + "/" + _maxAmmo;
    }

    public void AbsorbAmmo(int ammoConsumption)
    {
        _currentAmmo -= ammoConsumption;
        
        _ammoBar.fillAmount = _currentAmmo / _maxAmmo;
        
        _ammoText.text = _currentAmmo + "/" + _maxAmmo;
    }
}
