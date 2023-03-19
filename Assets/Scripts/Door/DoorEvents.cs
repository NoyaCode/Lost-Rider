using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorEvents : MonoBehaviour {

    public Animator TrapDoorAnim; 
    public BoxCollider TrapDoor;
    public TextMeshProUGUI lockedMessage;
    public TriggerDoorArea DoorArea;

    void Start()
    {
        TrapDoorAnim = GetComponent<Animator>();
        TrapDoor = GetComponent<BoxCollider>();

        GameEvents.current.OnTenCoinsTrigger += OpenDoor;
        GameEvents.current.OnEnterDoorArea += ShowLockedMessage;
        GameEvents.current.OnExitDoorArea += HideLockedMessage;
    }

    private void OpenDoor()
    {
        DoorArea.DoorOpened = true;
        TrapDoorAnim.SetTrigger("open");
        TrapDoor.isTrigger = true;
    }

    private void ShowLockedMessage()
    {
        lockedMessage.enabled = true;
    }

    private void HideLockedMessage()
    {
        lockedMessage.enabled = false;
    }

    private void OnDestroy()
    {
        GameEvents.current.OnTenCoinsTrigger -= OpenDoor;
        GameEvents.current.OnTenCoinsTrigger -= ShowLockedMessage;
        GameEvents.current.OnExitDoorArea -= HideLockedMessage;
    }

    //IEnumerator OpenCloseTrap()
    //{
    //    //play open animation;
    //    TrapDoorAnim.SetTrigger("open");
    //    TrapDoor.isTrigger = true;
    //    //wait 2 seconds;
    //    yield return new WaitForSeconds(2);
    //    //play close animation;
    //    TrapDoorAnim.SetTrigger("close");
    //    TrapDoor.isTrigger = false;
    //    //wait 2 seconds;
    //    yield return new WaitForSeconds(2);
    //    //Do it again;
    //    StartCoroutine(OpenCloseTrap());

    //}


}