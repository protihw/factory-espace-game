using UnityEngine;

public class FlashLightActions : MonoBehaviour
{
    // audios

    // variables
    public static FlashLightActions instance;
    public Light spotLight;
    public bool reflecting;
    public bool issuing;
    public bool hasFlashLight;
    public bool hasFlashLightUV;

    public void Awake()
    {
        instance = this;    
    }

    public void Update()
    {
        RaycastFlashLight();

        if (PlayerInventory.Instance.inventory.Exists(item => item.itemName == "FlashLight"))
        {
            hasFlashLight = true;
        }
        else
        {
            hasFlashLight = false;
            spotLight.enabled = false;
        }

        if (hasFlashLight)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                spotLight.enabled = !spotLight.enabled;
            }

            if (hasFlashLightUV && spotLight.enabled)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (spotLight.color == Color.white)
                    {
                        spotLight.color = Color.magenta;
                    }
                    else
                    {
                        spotLight.color = Color.white;
                    }
                }
            }
        }

        if (reflecting && hasFlashLight && spotLight.enabled)
        {
            MirrorActions.instance.LightOn();
        }
        else
        {
            MirrorActions.instance.LightOff();
        }

        if (issuing && hasFlashLight && spotLight.enabled && spotLight.color == Color.magenta)
        {
            UVActions.Instance.ChangeToNewTexture();
        }
        else
        {
            UVActions.Instance.ChangeToOldTexture();
        }
    }

    void RaycastFlashLight()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        float distance = 3f;

        int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");

        if (Physics.Raycast(ray, out hit, distance, ~layerMask))
        {
            if (hit.transform.tag == "Mirror")
            {
                reflecting = true;
            }

            if (hit.transform.tag == "UV")
            {
                issuing = true;
            }
        }
        else
        {
            reflecting = false;
            issuing = false;
        }
    }
}
