using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHandler : MonoBehaviour
{
    public static RayHandler Instance;

    public Action<Vector3> onHitRaycast;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public LayerMask rayMask;

    private void Update()
    {
        if (StageManager.Instance.CurrentState == StageState.START)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, rayMask))
                {
                    onHitRaycast?.Invoke(hit.point + new Vector3(0,0,.2f));
                }
            }
        }
    }
}
