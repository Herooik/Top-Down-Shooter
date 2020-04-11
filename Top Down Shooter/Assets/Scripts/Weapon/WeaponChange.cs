using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{ 
    public Sprite currentBulletSprite { get; private set; }
    public Weapon _selectedWeapon { get; private set; }
    public static WeaponChange Instance { get; private set; }
    
    [SerializeField] private Weapon[] weapon;
    [SerializeField] private SpriteRenderer attachToBodySpriteRender;
    [SerializeField] private SpriteRenderer playerBulletSpriteRender;
    [SerializeField] private Bullet[] bulletSprites;

    private string _input;
    private int _numericInput;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        currentBulletSprite = bulletSprites[0].bulletImage;
        _selectedWeapon = weapon[0];
    }

    private void Update()
    {
        GetNumericKeyInput();
    }

    private void GetNumericKeyInput()
    {
        _input = Input.inputString;
        
        int.TryParse(_input, out _numericInput);

        if (_numericInput >= 1 && _numericInput <=  weapon.Length)
        {
            SwitchWeapon(_numericInput);
        }
    }

    private void SwitchWeapon(int numberOfChoosenWeapon)
    {
        currentBulletSprite = bulletSprites[numberOfChoosenWeapon - 1].bulletImage;
        
        _selectedWeapon = weapon[numberOfChoosenWeapon - 1];

        attachToBodySpriteRender.sprite = _selectedWeapon.attachToBodySprite;

        playerBulletSpriteRender.sprite = currentBulletSprite;
      
        PlayerBulletPool.Instance.ChangeInactiveBulletSprite(currentBulletSprite);

    }
}
