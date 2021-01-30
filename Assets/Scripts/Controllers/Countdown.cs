using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    [Min(0.001f)]
    public float maxSeconds = 5f;
    public float remainingSecondsPercentage = 1f;
    public bool running = true;
    public UnityEvent onTimeUp;


    private float remainingSeconds;


    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (running)
        {
            remainingSeconds = Mathf.Clamp(
                remainingSeconds - Time.deltaTime,
                0f,
                maxSeconds
            );
            UpdatePercentage();
            if (remainingSeconds <= Mathf.Epsilon)
            {
                onTimeUp.Invoke();
                StopTimer();
            }
        }
    }

    public void StartTimer()
    {
        setRunning(true);
    }
    public void StopTimer()
    {
        setRunning(false);
    }
    public void ToggleTimerRunning()
    {
        setRunning(!running);
    }

    public void setRunning(bool newValue)
    {
        running = newValue;
    }

    public void ResetTimer()
    {
        remainingSeconds = maxSeconds;
        UpdatePercentage();
    }

    private void UpdatePercentage()
    {
        remainingSecondsPercentage = Mathf.Clamp(
            remainingSeconds / maxSeconds,
            0f,
            maxSeconds
        );
    }
}
