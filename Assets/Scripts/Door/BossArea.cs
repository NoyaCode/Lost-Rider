using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour
{
    public BoxCollider box;

    private void OnTriggerEnter(Collider other)
    {
        box.enabled = false;
        GameEvents.current.EnterBossArea();
    }

}
