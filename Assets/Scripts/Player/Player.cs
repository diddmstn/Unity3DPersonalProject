using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public List<Vector3> startPos;

    private void Awake() 
    {
        if(CharacterManager.Instance.Player==null)
        {
            CharacterManager.Instance.Player=this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition >();

        
    }
    public void SetPosition(int index)
    {
        this.transform.position =startPos[index];
    }
}
