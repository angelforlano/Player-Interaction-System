using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractItem : MonoBehaviour
{
    protected Player player;

    public virtual void Interact(Player _player)
    {
        player = _player;
        Debug.Log(player.name + " has interact with > " + gameObject.name);
    }
}