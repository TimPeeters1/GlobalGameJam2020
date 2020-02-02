using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ShipManagement : MonoBehaviour
{
    //public
    public int minutes;

    //private serialized
    [SerializeField] private int secondes;
    [Space]
    [SerializeField] private UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;
    [SerializeField] private UnityStandardAssets.Characters.FirstPerson.MouseLook mouseLook;
    [SerializeField] private TextMeshProUGUI timeText;
    [Space]
    [SerializeField] private GameObject winGamePanel;
    [SerializeField] private GameObject loseGamePanel;

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

    private void EndGame()
    {
        Time.timeScale = 0f;
        firstPersonController.enabled = false;
        mouseLook.EnableMouse();
    }
    public void GameOver()
    {
        Debug.Log("GameOver");
        EndGame();
        loseGamePanel.SetActive(true);
    }
    private void WinGame()
    {
        Debug.Log("WinGame");
        EndGame();
        winGamePanel.SetActive(true);
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
        Time.timeScale = 1f;
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
