using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemObject : MonoBehaviour
{
   public ItemData itemData;

   private void OnTriggerEnter(Collider other) 
   {
        ItemEffect();
        Destroy(gameObject);
   }

   void ItemEffect()
   {
        switch(itemData.consumable)
        {
            case ConsumableType.Health:
            CharacterManager.Instance.Player.condition.uICondition.health.Add(itemData.value);
            break;
            case ConsumableType.Stamina:
            CharacterManager.Instance.Player.condition.uICondition.stammina.Add(itemData.value);
            break;

        }
   }


}
