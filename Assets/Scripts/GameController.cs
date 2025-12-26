using System;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float timeElapsed = 0;
    public bool isGamestart;
    public bool isLobby;
    private bool setText;

    public TextMeshProUGUI statusText;

    private void Start()
    {
        timeElapsed = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        // if (isLobby)
        // {
        //     timeElapsed = 0;
        //     isGamestart = false;
        //     statusText.text = "";
        // }
        // else
        {
            if (isGamestart)
            {
                timeElapsed += Time.deltaTime;
                statusText.text = $"Time : {timeElapsed:N3}";
            }
            else
            {
                isGamestart = false;
                timeElapsed = 0;
            }
        }
    }

    public void SetisGameStart(bool set)
    {
        isGamestart = set;
    }

    public void SetisLobby(bool set)
    {
        isLobby = set;
    }

    public float GetTimeElapsed()
    {
        return timeElapsed;
    }

    public void ResetTimeElapsed()
    {
        timeElapsed = 0;
    }
}