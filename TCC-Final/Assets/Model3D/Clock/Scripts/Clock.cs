using UnityEngine;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour
{
    //-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;
    public int seconds = 0;
    public bool realTime = true;

    public GameObject pointerSeconds;
    public GameObject pointerMinutes;
    public GameObject pointerHours;

    //-- time speed factor
    public float clockSpeed = 1.0f; // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster

    //-- internal vars
    float msecs = 0;

    // Variável para armazenar o tempo limite
    private int limitTime;

    void Start()
    {
        //-- set real time
        if (realTime)
        {
            System.DateTime now = System.DateTime.Now;
            hour = now.Hour;
            minutes = now.Minute;
            seconds = now.Second;

            // Calcula o tempo limite (tempo atual + 30 minutos)
            limitTime = hour * 60 + minutes + 1;
        }
    }

    void Update()
    {
        //-- calculate time
        msecs += Time.deltaTime * clockSpeed;
        if (msecs >= 1.0f)
        {
            msecs -= 1.0f;
            seconds++;
            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
                if (minutes >= 60)
                {
                    minutes = 0;
                    hour++;
                    if (hour >= 24)
                        hour = 0;
                }
            }
        }

        //-- calculate pointer angles
        float rotationSeconds = (360.0f / 60.0f) * seconds;
        float rotationMinutes = (360.0f / 60.0f) * minutes;
        float rotationHours = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

        //-- draw pointers
        pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);

        // Verifica se já se passaram 30 minutos desde o início
        if (realTime && (hour * 60 + minutes) >= limitTime)
        {
            // Carrega a cena 0
            limitTime = 0;
            Debug.Log("isso");
            SceneManager.LoadScene(0);
        }
    }
}
