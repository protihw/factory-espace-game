using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject startButton, exitButton;
    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        mainPanel.SetActive(true);
    }
}
