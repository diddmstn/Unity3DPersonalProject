using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDamagalbe
{
    void TakePhysicalDamage(int damage);
}
public class PlayerCondition : MonoBehaviour, IDamagalbe
{
    public UICondition uICondition;

    public float reduceStamina;

    Condition health {get {return uICondition.health;}}
    Condition stamina {get {return uICondition.stammina;}}

    
    // Update is called once per frame
    void Update()
    {
        stamina.Add(stamina.passiveValue*Time.deltaTime);
        if(CharacterManager.Instance.Player.controller.dash==true)
        {
            UseStamina();
        }
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
    }

    public bool UseStamina()
    {
        if(stamina.curValue- reduceStamina <0f)
        {
            return false;
        }

        stamina.Subtract(reduceStamina);
        return true;
    }
    
    public void ResetCondition()
    {
        health.curValue= health.maxValue;
        stamina.curValue= stamina.maxValue;
    }
}
