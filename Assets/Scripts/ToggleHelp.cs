using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHelp : MonoBehaviour
{
    public GameObject toggleObject;

    public void Toggle()
    {
        if (toggleObject.activeSelf)
        {
            toggleObject.SetActive(false);
        } else
        {
            toggleObject.SetActive(true);
        }
    }
}
