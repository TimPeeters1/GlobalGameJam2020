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

    void Update()
    {
        if (timeActive)
        {
            currentSecondes = Timer(currentSecondes);
            secondes = (int)currentSecondes;
            if(secondes <= 0)
            {
                minutes--;
                currentSecondes = 60;
            }

            if (minutes <= 0 && secondes <= 0)
            {
                WinGame();
            }

            timeText.text = minutes + ":" + secondes;
        }
    }

    public void TimeActive(bool timeStopped)
    {
        timeActive = timeStopped;
    }
    private void WinGame()
    {
        Debug.Log("WinGame");
    }
    public void GameOver()
    {
        Debug.Log("GameOver");
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
