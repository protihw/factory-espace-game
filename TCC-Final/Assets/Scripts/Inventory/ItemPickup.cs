using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public MessageDisplay messageDisplay;
    public GameObject itemPrefab; // Prefab do item que pode ser coletado
    public InventorySystem inventory; // Referência ao script do inventário
    [SerializeField]
    private bool colliding = false;

    private void Update()
    {
        if (colliding && Input.GetKeyDown(KeyCode.E))
        {
            if (inventory && inventory.currentItem == null)
            {
                // Crie o item no inventário
                GameObject item = Instantiate(itemPrefab);
                inventory.AddItem(item);

                // Destrua o objeto de coleta no mundo
                Destroy(gameObject);
            }
            else
            {
                messageDisplay.ShowMessage("Você pode transportar apenas um item por vez.");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliding = true;           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colliding = false;
        }
    }
}
