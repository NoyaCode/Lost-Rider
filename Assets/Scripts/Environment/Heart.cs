using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private float heal = 1;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.PlayerHpUpdate(heal, false);
        Destroy(gameObject);
    }
}
