using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{ 
    public Sprite CurrentBulletSprite { get; private set; }
    public Weapon SelectedWeapon { get; private set; }
    public static WeaponChange Instance { get; private set; }
    public List<Weapon> weaponList;

    public int weaponSlotUsing = 0;
    
    [SerializeField] private SpriteRenderer attachToBodySpriteRender;
    [SerializeField] private SpriteRenderer playerBulletSpriteRender;
    [SerializeField] [Range(1, 3)] private int weaponSlots = 2;

    private string _input;
    private int _numericInput;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        CurrentBulletSprite = weaponList[0].bullet.bulletImage;
        SelectedWeapon = weaponList[0];
    }

    private void Update()
    {
        GetNumericKeyInput();
    }

    private void GetNumericKeyInput()
    {
        _input = Input.inputString;
        
        int.TryParse(_input, out _numericInput);

        if (_numericInput >= 1 && _numericInput <=  weaponSlots)
        {
            SwitchWeapon(_numericInput - 1);
        }
    }

    public void SwitchWeapon(int numberOfChoosenWeapon)
    {
        weaponSlotUsing = numberOfChoosenWeapon;
        
        CurrentBulletSprite = weaponList[numberOfChoosenWeapon].bullet.bulletImage;
        
        SelectedWeapon = weaponList[numberOfChoosenWeapon];

        attachToBodySpriteRender.sprite = SelectedWeapon.attachToBodySprite;

        playerBulletSpriteRender.sprite = CurrentBulletSprite;
      
        PlayerBulletPool.Instance.ChangeInactiveBulletSprite(CurrentBulletSprite);
    }
}
