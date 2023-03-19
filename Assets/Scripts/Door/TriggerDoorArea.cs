using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorArea : MonoBehaviour
{
    public bool DoorOpened;
    private void Awake()
    {
        DoorOpened = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!DoorOpened)
        {
            GameEvents.current.EnterDoorArea();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!DoorOpened)
        {
            GameEvents.current.ExitDoorArea();
        }
    }
}
