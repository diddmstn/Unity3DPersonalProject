using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IIteractable
{
    public string GetInteractPrompt();
    public void OnIteract();
}

public class InteractionObj : MonoBehaviour, IIteractable
{
   public ObjectInfo info;

    public string GetInteractPrompt()
    {
        string str = $"{info.displayName}\n{info.description}";
        return str;
    }

    public void OnIteract()
    {
        //게임을 시작합니다 3 2 1 이후 맵 이동
        startAction();
    }

    protected virtual void startAction()
    {

    }

    
}