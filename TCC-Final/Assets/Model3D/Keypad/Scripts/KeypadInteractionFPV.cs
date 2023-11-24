using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace NavKeypad 
{ 
public class KeypadInteractionFPV : MonoBehaviour
{
        private void Update()
        {
                RaycastCamera();
        }

        void RaycastCamera()
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            float distance = 1f;
    
            int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");

            if (Physics.Raycast(ray, out hit, distance, ~layerMask))
            {
                if (hit.collider.TryGetComponent(out KeypadButton keypadButton) && Input.GetMouseButtonDown(0))
                {
                    keypadButton.PressButton();
                }
            }
        }
}
}
