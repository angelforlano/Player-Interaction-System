using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : InteractItem
{
    public UnityEvent onOpenDoorEvent;
    public UnityEvent onCloseDoorEvent;
    bool status;

    public override void StartInteract(Player _player)
    {
        base.StartInteract(_player);

        if (status)
        {
            onCloseDoorEvent.Invoke();
        } else {
            onOpenDoorEvent.Invoke();
        }

        status = !status;
    }
}