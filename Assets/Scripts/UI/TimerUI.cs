using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Image image;
    public Countdown timer;

    private void Start()
    {
        image.type = Image.Type.Filled;
        image.fillMethod = Image.FillMethod.Radial360;
        image.fillOrigin = 2; //This equals to Top
        image.fillClockwise = false;
    }

    private void Update()
    {
        image.fillAmount = timer.remainingSecondsPercentage;
    }
}
