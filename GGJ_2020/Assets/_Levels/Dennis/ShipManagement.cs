using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ShipManagement : MonoBehaviour
{
    //private serialized
    [SerializeField] private int minutes;
    [SerializeField] private int secondes;
    [SerializeField] private TextMeshProUGUI timeText;

    //private
    private float currentSecondes;
    private bool timeActive = true;

    private void Start()
    {
        currentSecondes = secondes;
    }
    private void Update()
    {
        if (timeActive)
        {
            if (minutes <= 0 && secondes <= 0)
            {
                timeText.text = "0:00";
                WinGame();
            }
            else
            {
                currentSecondes = Timer(currentSecondes);
                secondes = (int)currentSecondes;

                if (secondes <= 0)
                {
                    minutes--;
                    currentSecondes = 60;
                }

                if (secondes >= 10)
                {
                    timeText.text = minutes + ":" + secondes;
                }
                else
                {
                    timeText.text = minutes + ":0" + secondes;
                }
            }
        }
    }
    public void TimeActive(bool timeStopped)
    {
        timeActive = timeStopped;
    }
    public void GameOver()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0f;
    }
    private void WinGame()
    {
        Debug.Log("WinGame");
        Time.timeScale = 0f;
    }

    private float Timer(float timer)
    {
        timer -= Time.deltaTime;
        return timer;
    }

    #region Singleton
    private static ShipManagement instance;
    private void Awake()
    {
        instance = this;
    }

    public static ShipManagement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ShipManagement();
            }

            return instance;
        }
    }
    #endregion
}
