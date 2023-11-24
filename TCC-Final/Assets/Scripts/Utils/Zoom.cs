using Cinemachine;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cam;
    private int oldFov = 75;
    private int newFov = 25;

    void Start()
    {
        // Define o FOV inicial para o FOV original
        cam.m_Lens.FieldOfView = oldFov;
    }

    void Update()
    {
        cam.m_Lens.FieldOfView = oldFov;

        if (Input.GetKey(KeyCode.C))
        {
            cam.m_Lens.FieldOfView = newFov;
        }
    }
}
