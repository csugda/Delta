using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour
{
    //Stats
    //health
    private int currentHeartHealth;
    private int currentBatteryHealth;
    private int maxHeartHealth = 10;
    private int maxBatteryHealth = 10;
    private Sprite playerSprite;
    //attack
    private int attackSpeed;
    private int attackDamage;
    private int reloadSpeed;
    //misc
    private int movementSpeed;
    private GameObject[] items;
    //stat accessors
    public int getAttackSpeed(){return attackSpeed;}
    public int getAttackDamage(){return attackDamage;}
    public int getReloadSpeed(){return reloadSpeed;}
    public int getMovementSpeed(){return movementSpeed;}
    public int getMaxHealth(){return maxHeartHealth;}
    public int GetMaxBattery(){return maxBatteryHealth;}
    public int getHealth(){return currentHeartHealth;}
    public int getBattery(){return currentBatteryHealth;}

    
    //stat modifiers
    public void modAttackSpeed(int x){attackSpeed += x;}
    public void modAttackDamage(int x){attackDamage += x;}
    public void modReloadSpeed(int x){reloadSpeed += x;}
    public void modMovementSpeed(int x){movementSpeed += x;}
    public void modMaxHealth(int x) {maxHeartHealth += x;}
    public void modMaxBattery(int x) {maxBatteryHealth += x;}

    // Start is called before the first frame update
    void Start()
    {
        //initialize values
        currentHeartHealth = maxHeartHealth;
        currentBatteryHealth = maxBatteryHealth;

    }

    //call to lower the player's health
    public void takeHeartDamage(int x)
    {
        currentHeartHealth -= x;
    }
    public void healHeart(int x)
    {
        takeHeartDamage(-x);
    }

    //call to lower the player's battery
    public void takeBatteryDamage(int x)
    {
        currentBatteryHealth -= x;
    }
    public void healBattery(int x)
    {
        takeBatteryDamage(-x);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
