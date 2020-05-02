using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopScrollList : MonoBehaviour
{
    public List<GameObject> panelList;
    
    [SerializeField] private List<Weapon> weaponShopList;
    [SerializeField] private Transform contentPanel;

    private void Start()
    {
        AddPanels();
        ChangeStartingPanels();
        RefreshEquipButtons();
    }

    void AddPanels()
    {
        for (int i = 0; i < weaponShopList.Count; i++)
        {
            var item = weaponShopList[i];

            var newPanel = PanelDropPool.Instance.GetPooledObject();
            if (newPanel != null)
            {
                newPanel.name = item.name + " Panel";
                newPanel.gameObject.SetActive(true);
                newPanel.transform.SetParent(contentPanel, false);
            }

            var samplePanel = newPanel.GetComponent<ShopPanelController>();
            samplePanel.SetupShopItem(item,this);
            
            panelList.Add(newPanel);
        }
    }

    private void ChangeStartingPanels()
    {
        for (int i = 0; i < 2; i++)
        {
            panelList[i].GetComponent<ShopPanelController>().DisableBuyButton();
        }
    }
    
    public void RefreshEquipButtons()
    {
       for (int i = 0; i < panelList.Count; i++)
       {
           var panel = panelList[i];
           var samplePanel = panel.GetComponent<ShopPanelController>();

           if (panelList.IndexOf(panel) == 0)
           {
               samplePanel.SetupEquipButtons(false, true);
           }
           else if (panelList.IndexOf(panel) == 1)
           {
               samplePanel.SetupEquipButtons(true, false);
           }
           else if (panelList.IndexOf(panel) >= 2)
           {
               samplePanel.SetupEquipButtons(true, true);
           }
           
       }
    }
    
    public bool TryBuyWeapon(Weapon weapon)
    {
        var coin = CoinManager.Instance.CoinAmount;
        
        if (coin >=  weapon.priceInShop)
        {
            CoinManager.Instance.RemoveGold(weapon.priceInShop);
            AddWeaponToList(weapon);
            
            return true;
        }

        return false;
    }
    
    public void AddWeaponToList(Weapon weapon)
    {
        WeaponChange.Instance.weaponList.Add(weapon);
    }

    
}
