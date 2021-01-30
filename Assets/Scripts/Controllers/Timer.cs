using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float secondsSinceStart = 0f;

    private void Start()
    {
        ResetTimer();
    }
    private void Update()
    {
        secondsSinceStart += Time.deltaTime;
    }

    public void ResetTimer()
    {
        secondsSinceStart = 0f;
    }
}
