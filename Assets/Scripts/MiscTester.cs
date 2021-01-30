using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiscTester : MonoBehaviour
{
    public UnityEvent onJumpButtonDown;

    private void Awake()
    {
        onJumpButtonDown = new UnityEvent();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            onJumpButtonDown.Invoke();
            Debug.Log("Fired!");
        }
    }

    public void ListenerAction()
    {
        Debug.Log("Jump button pressed");
    }

}
