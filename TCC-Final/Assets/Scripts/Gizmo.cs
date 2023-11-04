using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public Color colorGizmo = Color.red;
    public float lenghtSphere = 0.1f;
    public float lenghtWire = 0.2f;

    void OnDrawGizmos()
    {
        Gizmos.color = colorGizmo;
        Gizmos.DrawSphere(transform.position, lenghtSphere);
        Gizmos.DrawWireSphere(transform.position, lenghtWire);
    }
}
