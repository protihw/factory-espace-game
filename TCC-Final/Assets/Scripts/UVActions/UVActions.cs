using UnityEngine;

public class UVActions : MonoBehaviour
{
    public static UVActions Instance;
    public Material material;
    public Texture newTexture;
    public Texture oldTexture;

    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (material == null)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                material = renderer.material;
            }
        }
    }

    public void ChangeToNewTexture()
    {
        if (material != null && newTexture != null)
        {
            material.mainTexture = newTexture;
        }
    }

    public void ChangeToOldTexture()
    {
        if (material != null && oldTexture != null)
        {
            material.mainTexture = oldTexture;
        }
    }
}
