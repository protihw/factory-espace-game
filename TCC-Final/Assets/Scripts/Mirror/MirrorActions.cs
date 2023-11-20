using UnityEngine;

public class MirrorActions : MonoBehaviour
{
    public static MirrorActions instance;
    [SerializeField]
    private Light spotLight;
    [SerializeField]
    private Light pointLight;

    private void Start()
    {
        instance = this;    
    }

    public void LightOn()
    {
        spotLight.gameObject.SetActive(true);
        pointLight.gameObject.SetActive(true);
    }

    public void LightOff()
    {
        spotLight.gameObject.SetActive(false);
        pointLight.gameObject.SetActive(false);
    }
}
