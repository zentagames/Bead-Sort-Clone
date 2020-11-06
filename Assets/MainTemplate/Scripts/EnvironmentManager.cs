using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance;

    public Action<float> onStageProgressChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void SetState(StageState stageState)
    {

    }
}
