using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : InteractItem
{
    public UnityEvent onOpenDoorEvent;
    public UnityEvent onCloseDoorEvent;
    bool status;

    public override void Interact(Player _player)
    {
        base.Interact(_player);

        if (status)
        {
            onCloseDoorEvent.Invoke();
        } else {
            onOpenDoorEvent.Invoke();
        }

        status = !status;
    }
}
