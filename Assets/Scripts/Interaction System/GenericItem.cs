using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericItem : InteractItem
{
    public UnityEvent onInteractEvent;

    public override void StartInteract(Player _player)
    {
        base.StartInteract(_player);

        onInteractEvent.Invoke();
    }
}