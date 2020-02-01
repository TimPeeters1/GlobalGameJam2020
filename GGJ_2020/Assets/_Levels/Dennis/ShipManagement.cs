using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManagement : MonoBehaviour
{
    //private serialized
    [SerializeField] private float surviveTime;

    //private
    private float currentSurviveTimer;
    private bool timeActive = true;

    void Start()
    {
        currentSurviveTimer = surviveTime;
    }

    void Update()
    {
        if (timeActive)
        {
            currentSurviveTimer = Timer(currentSurviveTimer);

            if (currentSurviveTimer <= 0)
            {
                WinGame();
            }
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
