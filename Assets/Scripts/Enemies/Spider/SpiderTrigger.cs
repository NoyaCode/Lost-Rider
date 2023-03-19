using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrigger : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.EnterSpiderRange(id);
    }

    private void OnTriggerStay(Collider other)
    {
        GameEvents.current.InSpiderRange(id);
    }
    private void OnTriggerExit(Collider other)
    {
        GameEvents.current.ExitSpiderRange(id);
    }

    
}
