using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public string itemName = "Item";
    public GameObject inputCanvas;

    public Item GetItem()
    {
        // Crie uma nova instância do item com base nas propriedades deste objeto colecionável
        return new Item(itemName);
    }

    // Outros métodos e funcionalidades podem ser adicionados conforme necessário
}
