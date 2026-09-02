using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

public class InventoryManager : MonoBehaviour
{
    public int gold;
    public TMP_Text goldText;
    public InventorySlot[] itemSlots;

private void Start()
    {
        foreach(var slot in itemSlots)
        {
            slot.UpdateUI();
        }
    }



   private void OnEnable()
    {
        Loot.OnItemLooted += AddItem;
    
    } 

    private void OnDisable()
    {
        Loot.OnItemLooted -= AddItem;
    }


    public void AddItem(ItemSO itemSO, int quantity)
    {
        if (itemSO.isGold)
        {
            gold += quantity;
            goldText.text = gold.ToString();
        }
        else
        {
            foreach(var slot in itemSlots)
            {
                if( slot.itemSO == null)
                {
                    slot.itemSO = itemSO;
                    slot.quantity = quantity;
                     slot.UpdateUI();
                     return;
                }
                
            }
           
        }
    }

   
}
