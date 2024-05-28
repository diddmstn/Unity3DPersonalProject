using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ConsumableType
{
    Health,
    Stamina
}


[CreateAssetMenu(fileName ="Item", menuName ="New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public ConsumableType consumable;
    public string displayName;
    public string description;
    public float value;


    
}
