using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;

    public Action<float> onProgressUpdate;

    public List<Ball> balls;

    public Action onComplete;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        balls = GameObject.FindObjectsOfType<Ball>().ToList();
    }

    private void Update()
    {
        if (StageManager.Instance.CurrentState == StageState.START)
        {
            int placedBallCount = 0;

            placedBallCount = balls.FindAll(x => x.HasPlace == true).Count;

            onProgressUpdate?.Invoke(placedBallCount / (float)balls.Count);

            if (placedBallCount == balls.Count)
            {
                onComplete?.Invoke();
            }
        }
    }
}
