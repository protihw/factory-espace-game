using UnityEngine;

public class MirrorActions : MonoBehaviour
{
    public static MirrorActions instance;
    [SerializeField]
    private Light spotLight;

    private void Start()
    {
        instance = this;    
    }

    public void LightOn()
    {
        spotLight.gameObject.SetActive(true);
    }

    public void LightOff()
    {
        spotLight.gameObject.SetActive(false);
    }
}
