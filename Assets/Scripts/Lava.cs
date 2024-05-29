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
            CharacterManager.Instance.Player.SetPosition();//플레이어를 시작 위치로 이동
        }
    }

    
}
