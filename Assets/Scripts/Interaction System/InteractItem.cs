using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractItem : MonoBehaviour
{
    protected Player player;

    public virtual void StartInteract(Player _player)
    {
        player = _player;
        Debug.Log(player.name + " has start interact with > " + gameObject.name);
    }

    public virtual void StopInteract(Player _player)
    {
        player = null;
        Debug.Log(player.name + " has stop interact with > " + gameObject.name);
    }
}