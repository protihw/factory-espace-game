using UnityEngine;
using UnityEngine.UI;

public class CollectableObject : MonoBehaviour
{
    public string itemName = "Item";
    public Sprite itemIcon;

    public void Start()
    {
        
    }

    public Item GetItem()
    {
        // Crie uma nova instância do item com base nas propriedades deste objeto colecionável
        return new Item(itemName, itemIcon);
    }
}
