using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    #region PLAYER MANAGEMENT AND UI

    public event Action<Vector3, float> OnCollisionPlayerEnemy;
    public void CollisionPlayerEnemy(Vector3 force, float stunDuration)
    {
        OnCollisionPlayerEnemy?.Invoke(force, stunDuration);
    }

    public event Action OnCoinCollected;
    public void CoinCollected()
    {
        OnCoinCollected?.Invoke();
    }

    public event Action<float, bool> OnPlayerHpUpdate;
    public void PlayerHpUpdate(float hp, bool getInvincibility)
    {
        OnPlayerHpUpdate?.Invoke(hp, getInvincibility);
    }

    public event Action<Vector3> OnCheckpointReached;
    public void CheckpointReached(Vector3 position)
    {
        OnCheckpointReached?.Invoke(position);
    }

    public event Action OnCrossedFinishLine;
    public void CrossedFinishLine()
    {
        OnCrossedFinishLine?.Invoke();
    }
    #endregion

    #region WATER

    public event Action OnFellInWater;
    public void FellInWater()
    {
        OnFellInWater?.Invoke();
    }
    #endregion

    #region DOOR

    public event Action OnTenCoinsTrigger;
    public void TenCoinsTrigger()
    {
        OnTenCoinsTrigger?.Invoke();
    }

    public event Action OnEnterDoorArea;
    public void EnterDoorArea()
    {
        OnEnterDoorArea?.Invoke();
    }

    public event Action OnExitDoorArea;
    public void ExitDoorArea()
    {
        OnExitDoorArea?.Invoke();
    }
    #endregion

    #region ENEMIES

    public event Action<int> OnJumpedOnEnemy;
    public void JumpedOnEnemy(int id)
    {
        OnJumpedOnEnemy?.Invoke(id);
    }
    #endregion

    #region SPIDERS

    public event Action<int> OnEnterSpiderRange;
    public void EnterSpiderRange(int id)
    {
        OnEnterSpiderRange?.Invoke(id);
    }

    public event Action<int> OnInSpiderRange;
    public void InSpiderRange(int id)
    {
        OnInSpiderRange?.Invoke(id);
    }

    public event Action<int> OnExitSpiderRange;
    public void ExitSpiderRange(int id)
    {
        OnExitSpiderRange?.Invoke(id);
    }
    #endregion

    #region SPIKES

    public event Action OnTouchedSpikes;
    public void TouchedSpikes()
    {
        OnTouchedSpikes?.Invoke();
    }
    #endregion

    #region PLATFORMS

    public event Action OnResetPlatforms;
    public void ResetPlatforms()
    {
        OnResetPlatforms?.Invoke();
    }
    #endregion

    #region BOSS

    public event Action OnBossGotHit;
    public void BossGotHit()
    {
        OnBossGotHit?.Invoke();
    }

    public event Action OnEnterBossArea;
    public void EnterBossArea()
    {
        OnEnterBossArea?.Invoke();
    }

    #endregion
}