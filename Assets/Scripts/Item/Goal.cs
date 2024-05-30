using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : InteractionObj
{
    protected override void startAction()
    {
        GameManager.instance.GameClear();
    }
}
