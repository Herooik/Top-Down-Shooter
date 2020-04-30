using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelController : MonoBehaviour
{
    public Button equipFirstSlotButton;
    public Button equipSecondSlotButton;
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceLabel;
    [SerializeField] private TextMeshProUGUI dmgText;
    [SerializeField] private TextMeshProUGUI firerateText;
    [SerializeField] private TextMeshProUGUI energyConsumText;
    [SerializeField] private Image iconImage;
    
    [SerializeField] private Button buyButton;

    private Weapon _weapon;
    private ShopScrollList _scrollList;
    
    public void SetupShopItem(Weapon currentItem, ShopScrollList currentScrollList)
    {
        _weapon = currentItem;

        nameText.text = _weapon.name;
        dmgText.text = "DMG: " + _weapon.damage;
        firerateText.text = "FIRERATE: " + _weapon.fireRate;
        energyConsumText.text = "ENERGY CONSUM.: " + _weapon.energyConsumption;
        priceLabel.text = _weapon.priceInShop.ToString();
        iconImage.sprite = _weapon.icon;

        _scrollList = currentScrollList;
    }
    
    private void Start()
    {
        buyButton.onClick.AddListener(HandleBuyClick);
        equipFirstSlotButton.onClick.AddListener(HandleFirstEquipClick);
        equipSecondSlotButton.onClick.AddListener(HandleSecondEquipClick);
    }

    private void HandleBuyClick()
    {
        if (_scrollList.TryBuyWeapon(_weapon))
        {
            DisableBuyButton();
        }
    }
    
    public void DisableBuyButton()
    {
        buyButton.gameObject.SetActive(false);
        equipFirstSlotButton.gameObject.SetActive(true);
        equipSecondSlotButton.gameObject.SetActive(true);
    }

    private void HandleFirstEquipClick()
    {
        ChangeWeaponIndex(0);
        ChangePanelIndex(0);
        _scrollList.RefreshEquipButtons();
    }
    private void HandleSecondEquipClick()
    {
        ChangeWeaponIndex(1);
        ChangePanelIndex(1);
        _scrollList.RefreshEquipButtons();
    }

    private void ChangeWeaponIndex(int slotNumber)
    {
        var weaponToEquipIndex = WeaponChange.Instance.weaponList.IndexOf(_weapon);
        
        var weaponToEquip = WeaponChange.Instance.weaponList[weaponToEquipIndex];
        var weaponToReplace = WeaponChange.Instance.weaponList[slotNumber];

        var temp = weaponToReplace;
        WeaponChange.Instance.weaponList[slotNumber] = weaponToEquip;
        WeaponChange.Instance.weaponList[weaponToEquipIndex] = temp;
        
        if (WeaponChange.Instance.weaponSlotUsing == slotNumber)
        {
            WeaponChange.Instance.SwitchWeapon(slotNumber);
        }
    }

    private void ChangePanelIndex(int slotNumber)
    {
        var panelIndex = _scrollList.panelList.IndexOf(gameObject);

        var indexToTransport = _scrollList.panelList[panelIndex];
        var indexToReplace = _scrollList.panelList[slotNumber];

        var temp = indexToReplace;
        _scrollList.panelList[slotNumber] = indexToTransport;
        _scrollList.panelList[panelIndex] = temp;
    }
    
    public void SetupEquipButtons(bool isFirstSlotButtonVisible, bool isSecondSlotButtonVisible)
    {
        equipFirstSlotButton.interactable = isFirstSlotButtonVisible;
        equipSecondSlotButton.interactable = isSecondSlotButtonVisible;
    } 
}
