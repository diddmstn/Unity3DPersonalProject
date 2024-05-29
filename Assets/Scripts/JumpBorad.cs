using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBorad : MonoBehaviour
{
    Coroutine corutine;
    public float delay;
    public float forceAmount;

    private void OnCollisionEnter(Collision other)
    {
        if(corutine!=null) StopCoroutine(Generate(null));
        corutine= StartCoroutine(Generate(other.gameObject));
    }

    IEnumerator Generate(GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        Rigidbody rb=obj.GetComponent<Rigidbody>();
        rb.velocity= Vector3.zero;
        rb.AddForce(Vector3.up*forceAmount, ForceMode.Impulse);
    }
}
