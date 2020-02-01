using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProblemList : MonoBehaviour
{
    //private serialized
    [SerializeField] private TextMeshProUGUI[] statusChanger;
    [SerializeField] private Image[] panelProblem;

    [SerializeField] private GameObject listCanvas;

    //private
    private bool listOn = false;

    private void Start()
    {
        listCanvas.SetActive(false);
    }
    private void Update()
    {
        CheckInput();
    }
    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape))
        {
            listOn = SwitchBool(listOn);

            if (listOn)
            {
                OpenList();
                Debug.Log("List has been openend");
            }
            else
            {
                listCanvas.SetActive(false);
                Debug.Log("List has been closed");
            }
        }
    }
    private void OpenList()
    {
        listCanvas.SetActive(true);
    }

    public void UpdateList(int problem, int stageProblem)
    {
        if(stageProblem == 1)
        {
            panelProblem[problem].color = new Color32(255, 0, 0, 255);
            statusChanger[problem].text = "Operational";
        }
        else if (stageProblem == 2)
        {
            panelProblem[problem].color = new Color32(255, 255, 0, 255);
            statusChanger[problem].text = "Error";
        }
        else if (stageProblem == 3)
        {
            panelProblem[problem].color = new Color32(255, 150, 0, 255);
            statusChanger[problem].text = "Warning";
        }
        else if (stageProblem == 4)
        {
            panelProblem[problem].color = new Color32(0, 255, 0, 255);
            statusChanger[problem].text = "Danger";
        }
    }

    private bool SwitchBool(bool active)
    {
        active = !active;
        return active;
    }

    #region Singleton
    private static ProblemList instance;
    private void Awake()
    {
        instance = this;
    }

    public static ProblemList Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ProblemList();
            }

            return instance;
        }
    }
    #endregion
}
