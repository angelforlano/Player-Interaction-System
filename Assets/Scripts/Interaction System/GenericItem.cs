using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericItem : InteractItem
{
    public UnityEvent onInteractEvent;

    public override void Interact(Player _player)
    {
        base.Interact(_player);

        onInteractEvent.Invoke();
    }
}