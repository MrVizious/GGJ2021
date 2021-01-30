using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiscTester : MonoBehaviour
{
    public UnityEvent firePressed;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firePressed.Invoke();
        }
    }

    public void FireAction()
    {
        Debug.Log("Fire!");
    }

}
