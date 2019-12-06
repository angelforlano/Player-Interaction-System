using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(1, 3)] public float interactitonRadius = 1;
    public Vector3 interactitonCenter;

    InteractItem itemToInteract;

    public bool HasItemToInteract
    {
        get {return itemToInteract != null;}
    }

    void FindInteractionItem()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + interactitonCenter, interactitonRadius);
        
        for (int i = 0; i < hitColliders.Length; i++)
        {
            itemToInteract = hitColliders[i].GetComponent<InteractItem>();
            if (itemToInteract != null)
            {
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
                itemToInteract.Interact(this);
            }
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        transform.Translate(move * 4 * Time.deltaTime);
    }

    void FixedUpdate()
    {
        FindInteractionItem();
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
        Gizmos.DrawWireSphere(transform.position + interactitonCenter, interactitonRadius);
    }
}