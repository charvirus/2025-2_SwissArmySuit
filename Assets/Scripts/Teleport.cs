using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private CharacterController controller;
    public GameController gameController;
    public GameObject target;
    public Restart restartController;
    public ClearScreenController clearScreenController;
    public bool gameStart;
    public bool isLobby;
    public bool gameScoreShow;
    public float clearTimeFloatOne;
    public float clearTimeFloatTwo;
    public float clearTimeFloatThree;
    public bool teleportNextStage = false;
    public string sceneName;
    public PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider other)
    {
        controller = other.gameObject.GetComponent<CharacterController>();
        if (other.gameObject.CompareTag("Player"))
        {
            playerMovement.ResetToDefault();
            if (gameScoreShow)
            {
                clearScreenController.SetClearTime(clearTimeFloatOne, clearTimeFloatTwo, clearTimeFloatThree);
                clearScreenController.SetTeleportTarget(target);
                clearScreenController.SetClearTime(gameController.GetTimeElapsed());
                clearScreenController.ShowScreenMenu();
                clearScreenController.SetisLobby(isLobby);

                if (teleportNextStage)
                {
                    clearScreenController.SetGoNextStage(true);
                    clearScreenController.SetNextStageName(sceneName);
                }
                else
                {
                    clearScreenController.SetGoNextStage(false);
                }
            }
            else
            {
                controller.enabled = false;
                other.transform.position = target.transform.position;
                other.transform.rotation = target.transform.rotation;
                controller.enabled = true;
                gameController.ResetTimeElapsed();
                gameController.SetisGameStart(gameStart);
            }

        }
    }

    public bool GetTeleportNextStage()
    {
        return teleportNextStage;
    }
    public string GetSceneName()
    {
        return sceneName;
    }
}