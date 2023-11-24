using UnityEngine;
using TMPro;

public class MouseEvents : MonoBehaviour
{
    public TMP_Text startText, exitText;

    public void StartChangeColorBlack()
    {
        startText.color = Color.black;
    }

    public void StartChangeColorWhite()
    {
        startText.color = Color.white;
    }

    public void ExitChangeColorBlack()
    { 
        exitText.color = Color.black;
    }

    public void ExitChangeColorWhite()
    {
        exitText.color = Color.white;
    }
}
