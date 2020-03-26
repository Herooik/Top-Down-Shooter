using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{ 
    [HideInInspector] public Sprite currentBulletSprite;
    
    [HideInInspector] public Weapon _selectedWeapon;
    public static WeaponChange instance;
    
    [SerializeField] private Weapon[] weapon;
    [SerializeField] private SpriteRenderer attachToBodySpriteRender;
    [SerializeField] private SpriteRenderer playerBulletSpriteRender;
    [SerializeField] private Bullet[] bulletSprites;

    private string _input;
    private int _numericInput;

    

    private void Awake()
    {
        instance = this;

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
      
        PlayerBulletPool.Instance.ChangeInactiveObjectSprite(currentBulletSprite);

    }
}
