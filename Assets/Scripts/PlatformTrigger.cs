using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private PlatformMovements platformMovements;
    private void Start()
    {
        platformMovements = GetComponent<PlatformMovements>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!platformMovements.enabled)
            platformMovements.enabled = true;
    }
}
