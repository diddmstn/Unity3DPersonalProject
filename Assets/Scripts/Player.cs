using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public Vector3 startTransform;

    private void Awake() 
    {
        CharacterManager.Instance.Player=this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition >();
        startTransform= this.transform.position;
    }
}
