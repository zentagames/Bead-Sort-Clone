using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour
{
    public Image slider;
    public void SetRate(float rate)
    {
        slider.fillAmount = rate;
    }
}

