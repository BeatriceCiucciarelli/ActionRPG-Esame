using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public StatsUI statsUI;

    public TMP_Text healthText;


    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;
    
    [Header("Movement Stats")]
    public int speed;

    [Header("Health Stats")]
    public int maxHealth;
    public int currentHealth;


    private void Awake() {
        if(Instance==null) {
            Instance=this;
        }
        else 
            Destroy(gameObject);
    }

    public void UpDateMaxHealth(int amount)
    {
        maxHealth += amount;
        healthText.text = "HP" + currentHealth + "/" + maxHealth;
    }

     public void UpDateHealth(int amount)
    {
        currentHealth += amount;
         
        if(currentHealth >= maxHealth)
         currentHealth=maxHealth;

        healthText.text = "HP" + currentHealth + "/" + maxHealth;
    }

     public void UpDateSpeed(int amount)
    {
        speed += amount;
        statsUI.UpdateAllStats();
    }
}
