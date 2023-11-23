using Cinemachine;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    private int oldlFov = 75;
    private int newFov = 25;
    private bool statusFov = false;

    void Start()
    {
        // Define o FOV inicial para o FOV original
        cam.m_Lens.FieldOfView = oldlFov;
    }

    void Update()
    {
        // Verifica se a tecla "C" foi pressionada
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Inverte o estado do FOV aumentado
            statusFov = !statusFov;

            // Atualiza o FOV com base no estado atual
            if (statusFov)
            {
                cam.m_Lens.FieldOfView = newFov;
            }
            else
            {
                cam.m_Lens.FieldOfView = oldlFov;
            }
        }
    }
}
