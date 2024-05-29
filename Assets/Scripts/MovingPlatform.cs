using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> pos;
    bool inPlatform;
    public float speed;
    float delay = 5f;

    bool end;

    Coroutine coroutine;

    void FixedUpdate()
    {
        if(inPlatform==true&&end==false)
        {
            for(int i = 1; i < pos.Count; i++)
            {
                transform.localPosition= Vector3.Lerp(transform.localPosition,pos[i].localPosition,Time.deltaTime*speed);
            }
        }
        else
        {
            transform.localPosition=pos[0].localPosition;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(coroutine!=null) 
        {
            StopCoroutine(coroutine);
        }
        inPlatform=true;
        //플레이어를 자식으로 넣기
    }
    private void OnCollisionExit(Collision other) 
    {
        coroutine = StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        yield return new WaitForSeconds(delay);

        inPlatform=false;
        end=false;

    }

}
