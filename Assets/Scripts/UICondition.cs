using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
   public Condition health;
   public Condition stammina;
   
   private void Start() 
   {
      CharacterManager.Instance.Player.condition.uICondition = this;
      DontDestroyOnLoad(gameObject.transform.parent);
   }
}
