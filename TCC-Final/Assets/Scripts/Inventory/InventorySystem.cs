using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public GameObject currentItem; // O item atual no inventário

    // Adicione um item ao inventário
    public void AddItem(GameObject item)
    {
        // Verifique se o inventário está vazio
        if (currentItem == null)
        {
            currentItem = item;
            item.SetActive(false); // Desative o item no mundo
        }
    }

    // Descarte o item atual do inventário
    public void DiscardItem()
    {
        if (currentItem != null)
        {
            // Defina a posição do item como a posição atual do jogador
            currentItem.transform.position = transform.position;

            currentItem.SetActive(true); // Ative o item no mundo
            currentItem = null; // Limpe o item do inventário
        }
    }
}
