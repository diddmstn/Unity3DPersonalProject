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
    int curPos=1;

    void FixedUpdate()
    {
        if(inPlatform==true&&end==false)
        {
            if( Vector3.Distance(transform.localPosition, pos[curPos].transform.localPosition) <= 1f)
            {
                if(curPos>pos.Count)
                {
                    end=true;
                    return;
                }
                curPos++;
            }
            transform.localPosition = Vector3.Lerp(transform.localPosition,pos[curPos].transform.localPosition, speed * Time.deltaTime);
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
        other.transform.parent = this.transform;
        inPlatform=true;

        //플레이어를 자식으로 넣기
    }
    private void OnCollisionExit(Collision other) 
    {
        coroutine = StartCoroutine(Count());
        inPlatform=false;
        other.transform.parent = null;
    }

    IEnumerator Count()
    {
        yield return new WaitForSeconds(delay);

        inPlatform=false;
        end=false;

    }

}
