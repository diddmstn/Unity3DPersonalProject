using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
                 curPos++;
                if(curPos>=pos.Count)
                {
                    curPos=pos.Count-1;
                }
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition,pos[curPos].transform.localPosition, speed * Time.deltaTime);
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
        other.transform.SetParent(this.transform);
        inPlatform=true;

    }
    private void OnCollisionExit(Collision other) 
    {
        coroutine = StartCoroutine(Count());
        other.transform.SetParent(null);
        DontDestroyOnLoad(other.gameObject);

    }

    IEnumerator Count()
    {
        yield return new WaitForSeconds(delay);

        inPlatform=false;
        end=false;
        curPos=1;

    }

}
