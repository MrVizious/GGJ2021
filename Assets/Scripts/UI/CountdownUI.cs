using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownUI : MonoBehaviour
{
    public Image image;
    public Countdown countdown;

    private void Start()
    {
        image.type = Image.Type.Filled;
        image.fillMethod = Image.FillMethod.Vertical;
        image.fillOrigin = 0; //This equals to Top
        image.fillClockwise = false;
    }

    private void Update()
    {
        image.fillAmount = countdown.remainingSecondsPercentage;
    }
}
