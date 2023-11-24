using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject startButton, exitButton;
    public AudioSource audioSource;
    public AudioClip buttonClip;

    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
    }

    public void StartButton()
    {
        audioSource.PlayOneShot(buttonClip);

        SceneManager.LoadScene(1);
        Cursor.visible = false;
    }

    public void ExitButton()
    {
        audioSource.PlayOneShot(buttonClip);

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
