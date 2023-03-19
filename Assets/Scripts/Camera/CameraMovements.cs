using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] public GameObject Player;
    [SerializeField] public CameraTranslate cameraTranslate;
    float cameraHeight = 2.5f;

    void Start()
    {
        GameEvents.current.OnEnterBossArea += FixCamera;
    }

    private void OnDestroy()
    {
        GameEvents.current.OnEnterBossArea -= FixCamera;
    }

    void LateUpdate()
    {
        if(Player!=null)
        {
            transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + cameraHeight, -10);
        }
    }

    private void FixCamera()
    {
        cameraTranslate.enabled = true;
        enabled = false;
    }
}
