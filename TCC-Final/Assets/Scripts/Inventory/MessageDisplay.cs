using UnityEngine;
using UnityEngine.UI;

public class MessageDisplay : MonoBehaviour
{
    public static MessageDisplay instance;

    public Text messageText; // Referência ao componente Text no painel de mensagem
    public float displayDuration = 5f; // Duração de exibição da mensagem em segundos

    private bool isMessageVisible = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isMessageVisible)
        {
            displayDuration -= Time.deltaTime;

            if (displayDuration <= 0)
            {
                HideMessage();
            }
        }
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        gameObject.SetActive(true); // Torna o painel de mensagem visível
        isMessageVisible = true;
    }

    public void HideMessage()
    {
        gameObject.SetActive(false); // Oculta o painel de mensagem
        isMessageVisible = false;
        displayDuration = 5f; // Reinicia a duração
    }
}
