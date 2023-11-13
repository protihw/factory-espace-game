using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public string itemName = "Item";
    public GameObject inputCanvas;
    public Vector3 inputCanvasPosition;

    public void Start()
    {
        inputCanvasPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        inputCanvas.transform.position = inputCanvasPosition;
    }

    public Item GetItem()
    {
        // Crie uma nova instância do item com base nas propriedades deste objeto colecionável
        return new Item(itemName);
    }
}
