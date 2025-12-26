using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameController gameController;
    public CharacterController characterController;
    public PlayerMovement playerMovement;
    public KeyCode restartKey = KeyCode.R;
    public GameObject restartPoint;
    public GameObject powerups;
    public GameObject screenMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(restartKey))
        {
            screenMenuUI.SetActive(false);
            ResetGame();
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            ResetPowerups();
            ResetStats();
        }
    }

    public void ResetStats()
    {
        playerMovement.SetGravity(-9.8f);
        playerMovement.SetSpeed(12f);
        playerMovement.SetJumpHeight(3f);
    }

    public void ResetPowerups()
    {
        if (powerups != null)
        {
            foreach (Transform child in powerups.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    public void SetRestartPoint(GameObject newPoint)
    {
        restartPoint = newPoint;
    }

    public void ResetGame()
    {
        characterController.enabled = false;
        characterController.transform.position = restartPoint.transform.position;
        characterController.transform.rotation = restartPoint.transform.rotation;
        characterController.enabled = true;
        gameController.ResetTimeElapsed();
    }
}