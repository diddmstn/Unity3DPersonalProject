using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public List<Vector3> startPos;

    private void Awake() 
    {
        CharacterManager.Instance.Player=this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition >();
        DontDestroyOnLoad(gameObject);
    }
    public void SetPosition()
    {
        this.transform.position =startPos[GameManager.instance.currentSceneIndex];
    }
}
