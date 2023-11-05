using UnityEngine;
using UnityEngine.UI;

public class ItemDiscard : MonoBehaviour
{
    public MessageDisplay messageDisplay;
    public InventorySystem inventory; // Referência ao script do inventário

    private void Update()
    {
        if (inventory.currentItem != null && Input.GetKeyDown(KeyCode.Q))
        {
            inventory.DiscardItem();
        }
        else if (inventory.currentItem == null && Input.GetKeyDown(KeyCode.Q))
        {
            messageDisplay.ShowMessage("Você não possui nenhum item no momento.");
        }
    }
}
