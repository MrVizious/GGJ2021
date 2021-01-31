using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public bool debug = false;
    public UnityEvent onPause;

    // Giver input
    public UnityEvent onGiverLeftDown;
    public UnityEvent onGiverLeftUp;
    public UnityEvent onGiverRightDown;
    public UnityEvent onGiverRightUp;

    // Storage input
    public UnityEvent onReceiverLeftDown;
    public UnityEvent onReceiverLeftUp;
    public UnityEvent onReceiverRightDown;
    public UnityEvent onReceiverRightUp;

    // Storage input
    public UnityEvent onStorageADown;
    public UnityEvent onStorageBDown;
    public UnityEvent onStorageAUp;
    public UnityEvent onStorageBUp;

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (debug) Debug.Log("PauseDown pressed");
            onPause.Invoke();
        }

        if (Input.GetButtonDown("GiverLeft"))
        {
            if (debug) Debug.Log("GiverLeftDown pressed");
            onGiverLeftDown.Invoke();
        }
        else if (Input.GetButtonUp("GiverLeft"))
        {
            if (debug) Debug.Log("GiverLeftUp pressed");
            onGiverLeftUp.Invoke();
        }

        if (Input.GetButtonDown("GiverRight"))
        {
            if (debug) Debug.Log("GiverRightDown pressed");
            onGiverRightDown.Invoke();
        }
        else if (Input.GetButtonUp("GiverRight"))
        {
            if (debug) Debug.Log("GiverRightUp pressed");
            onGiverRightUp.Invoke();
        }

        if (Input.GetButtonDown("ReceiverLeft"))
        {
            if (debug) Debug.Log("ReceiverLeftDown pressed");
            onReceiverLeftDown.Invoke();
        }
        else if (Input.GetButtonUp("ReceiverLeft"))
        {
            if (debug) Debug.Log("ReceiverLeftUp pressed");
            onReceiverLeftUp.Invoke();
        }

        if (Input.GetButtonDown("ReceiverRight"))
        {
            if (debug) Debug.Log("ReceiverRightDown pressed");
            onReceiverRightDown.Invoke();
        }
        else if (Input.GetButtonUp("ReceiverRight"))
        {
            if (debug) Debug.Log("ReceiverRightUp pressed");
            onReceiverRightUp.Invoke();
        }

        if (Input.GetButtonDown("StorageA"))
        {
            if (debug) Debug.Log("StorageADown pressed");
            onStorageADown.Invoke();
        }
        else if (Input.GetButtonUp("StorageA"))
        {
            if (debug) Debug.Log("StorageAUp pressed");
            onStorageAUp.Invoke();
        }

        if (Input.GetButtonDown("StorageB"))
        {
            if (debug) Debug.Log("StorageBDown pressed");
            onStorageBDown.Invoke();
        }
        else if (Input.GetButtonUp("StorageB"))
        {
            if (debug) Debug.Log("StorageBUp pressed");
            onStorageBUp.Invoke();
        }

    }
}
