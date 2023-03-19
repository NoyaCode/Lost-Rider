using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEvents : MonoBehaviour
{
    private readonly float damage = -1;
    public PlayerManager playerManager;
    private void Start()
    {
        GameEvents.current.OnTouchedSpikes += SpikeHit;
    }

    private void OnDestroy()
    {
        GameEvents.current.OnTouchedSpikes -= SpikeHit;
    }

    private void SpikeHit()
    {
        GameEvents.current.PlayerHpUpdate(damage, true);
    }
}
