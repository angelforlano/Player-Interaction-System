using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Activator : InteractItem
{
    public Gradient gradient;
    public Image activationBarImage;
    [Range(1, 6)] public int activationTime = 5;

    public UnityEvent onActiveEvent;

    bool interacting;
    float currentActivationTime;
    float startInteractTime;

    public float ActivationPercent
    {
        get { return currentActivationTime / (float) activationTime;}
    }

    void Update()
    {
        activationBarImage.color = gradient.Evaluate(ActivationPercent);
        activationBarImage.fillAmount = ActivationPercent;

        if (interacting)
        {
            currentActivationTime += Time.deltaTime;
        }

        if (!interacting && currentActivationTime > 0)
        {
            currentActivationTime -= Time.deltaTime;
        }

        if (currentActivationTime > activationTime)
        {
            onActiveEvent.Invoke();
        }
    }

    public override void StartInteract(Player _player)
    {
        base.StartInteract(_player);
        startInteractTime = Time.time;
        interacting = true;
    }

    public override void StopInteract(Player _player)
    {
        base.StartInteract(_player);
        startInteractTime = 0;
        interacting = false;
    }
}