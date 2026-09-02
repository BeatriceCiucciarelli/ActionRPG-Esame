using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public bool canbePickedUp = true;
    public ItemSO itemSO;
    public SpriteRenderer sr;
    public Animator anim;

    public int quantity;
    public static event Action<ItemSO, int> OnItemLooted;

    private void OnValidate() {
        if(itemSO==null) 
            return;
        
        UpdateAppearence();
    }

    public void Initialize(ItemSO itemSO, int quantity)
    {
        this.itemSO=itemSO;
        this.quantity=quantity;
        canbePickedUp=false;

        UpdateAppearence();
    }

    private void UpdateAppearence()
    {
         sr.sprite=itemSO.icon;
        this.name=itemSO.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && canbePickedUp==true) {
            anim.Play("LootPickup");
            OnItemLooted?.Invoke(itemSO, quantity);
            Destroy(gameObject, .5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            canbePickedUp = true;
        }
    }
}
