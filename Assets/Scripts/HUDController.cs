using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI interactPopText;
    public static HUDController Instance;

    void Awake()
    {
        Instance = this;
    }

    public void SetInteractPopText(bool _status)
    {
        interactPopText.gameObject.SetActive(_status);
    }
}