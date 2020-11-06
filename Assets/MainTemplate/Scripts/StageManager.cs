using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    private StageState currentState;

    public StageState CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;

            OnStateChange();
        }
    }

    public void OnStateChange()
    {
        StageUI.Instance.ShowPanel(currentState);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CurrentState = StageState.READY;

        RayHandler.Instance.onHitRaycast += VacoomController.Instance.SetPosition;

        BoardManager.Instance.onProgressUpdate += StageUI.Instance.startPanel.stageProgressSlider.SetRate;

        BoardManager.Instance.onComplete += () => { CurrentState = StageState.SUCCESS; };

        StageUI.Instance.onSelectColor += VacoomController.Instance.ChangeColor;
    }

    public void StartStage()
    {
        CurrentState = StageState.START;
    }
}

public enum StageState
{
    READY,
    START,
    SUCCESS,
    FAIL
}
