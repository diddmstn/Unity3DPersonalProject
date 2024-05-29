using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : InteractionObj
{
    protected override void startAction()
    {
        SceneManager.LoadScene(1);
    }
}
