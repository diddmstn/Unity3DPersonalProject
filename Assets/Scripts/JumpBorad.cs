using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBorad : MonoBehaviour
{
    Coroutine corutine;
    public float delay;
    public float forceAmount;
    Vector3 curTransform;

    void Start()
    {
        curTransform=this.transform.position;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(corutine==null) 
        {
            corutine= StartCoroutine(Generate(other.gameObject));
            this.transform.position -= new Vector3(0,0.15f,0);
        }
    }

    IEnumerator Generate(GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        Rigidbody rb=obj.GetComponent<Rigidbody>();
        rb.velocity= Vector3.zero;
        rb.AddForce(Vector3.up*forceAmount, ForceMode.Impulse);
        this.transform.position = curTransform;
        corutine=null;

    }
}
