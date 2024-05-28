using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent(out IDamagalbe damagalbe))
        {
            damagalbe.TakePhysicalDamage(damage);
            other.gameObject.transform.position= CharacterManager.Instance.Player.startTransform;
        }
    }

    
}
