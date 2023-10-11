using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternfaceController : MonoBehaviour
{

    public GameObject inventoryPanel;
    bool invActive;

    void start ()
    {

    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            invActive = !invActive;
            inventoryPanel.SetActive(invActive);
        }

        if (invActive)
        {
            //Cursor.lockState = CursorLockMode.None;
        }
    }
}
