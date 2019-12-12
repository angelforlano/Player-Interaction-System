using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(1, 3)] public float interactionRadius = 1;
    public Vector3 interactionCenter;

    InteractItem itemToInteract;
    float lastItemSetTime;
    bool hasInteracted;

    public bool HasItemToInteract
    {
        get {return itemToInteract != null;}
    }

    void FindInteractionItem()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + interactionCenter, interactionRadius);
        
        for (int i = 0; i < hitColliders.Length; i++)
        {
            InteractItem item = hitColliders[i].GetComponent<InteractItem>();
            
            if (item != null)
            {
                if (!HasItemToInteract)
                {
                    itemToInteract = item;
                    lastItemSetTime = Time.time;
                    hasInteracted = false;
                }

                return;
            }
        }

        itemToInteract = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (HasItemToInteract)
            {
                hasInteracted = true;
                itemToInteract.Interact(this);
            }
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        transform.Translate(move * 4 * Time.deltaTime);
    }

    void FixedUpdate()
    {
        FindInteractionItem();

        if (HasItemToInteract && (Time.time - lastItemSetTime) > 3 && !hasInteracted)
        {
            HUDController.Instance.SetInteractPopText(true);
        } else {
            HUDController.Instance.SetInteractPopText(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Just Change the color for display purposes.
        if (HasItemToInteract)
        {
            Gizmos.color = Color.green;
        } else {
            Gizmos.color = Color.yellow;
        }

        // Display the interaction radius when selected.
        Gizmos.DrawWireSphere(transform.position + interactionCenter, interactionRadius);
    }
}