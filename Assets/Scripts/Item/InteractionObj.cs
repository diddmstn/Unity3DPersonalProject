using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionObj : MonoBehaviour, IIteractable
{
   public ItemData itemData;

    public string GetInteractPrompt()
    {
        string str = $"{itemData.displayName}\n{itemData.description}";
        return str;
    }

    public void OnIteract()
    {
        throw new System.NotImplementedException();
    }
}