using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SplashScreen : MonoBehaviour
{
    public float splashScreenTime;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(splashScreenTime);

        GameManager.Instance.NextStage();
    }
}

