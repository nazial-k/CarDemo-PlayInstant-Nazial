using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ColorPanelToggle : MonoBehaviour
{
    public GameObject colorPanel; // Reference to Button B in the Inspector

    void Start()
    {
        // Disable Button B at the start
        colorPanel.gameObject.SetActive(false);
    }

    public void ToggleButtonB()
    {
        // Toggle the visibility of Button B
        colorPanel.gameObject.SetActive(!colorPanel.gameObject.activeSelf);
    }
}
