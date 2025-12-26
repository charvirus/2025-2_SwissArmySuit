using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearScreenController : MonoBehaviour
{
    public GameObject screenMenuUI;
    [SerializeField] private GameController gameController;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Restart restartController;
    public GameObject teleportTarget;
    [SerializeField] private TextMeshProUGUI clearTimeOne;
    [SerializeField] private TextMeshProUGUI clearTimeTwo;
    [SerializeField] private TextMeshProUGUI clearTimeThree;
    [SerializeField] private TextMeshProUGUI clearTime;
    [SerializeField] private RawImage starOne;
    [SerializeField] private RawImage starTwo;
    [SerializeField] private RawImage starThree;
    private float clearTimeFloatOne;
    private float clearTimeFloatTwo;
    private float clearTimeFloatThree;
    public Texture originalTexture;
    public Texture newTexture;
    private bool isGameStart;
    private bool isPlayerLobby;
    
    private bool goNextStage = false;
    private string nextStageName;
    
    void Start()
    {
        clearTimeOne.text = clearTimeFloatOne.ToString("F2");
        clearTimeTwo.text = clearTimeFloatTwo.ToString("F2");
        clearTimeThree.text = clearTimeFloatThree.ToString("F2");
        starOne = GameObject.Find("One Star").GetComponent<RawImage>();
        starTwo = GameObject.Find("Two Star").GetComponent<RawImage>();
        starThree = GameObject.Find("Three Star").GetComponent<RawImage>();
    }

    public void SetClearTime(float oneStartime, float twoStartime, float threeStartime)
    {
        clearTimeFloatOne = oneStartime;
        clearTimeFloatTwo = twoStartime;
        clearTimeFloatThree = threeStartime;
        
        clearTimeOne.text = clearTimeFloatOne.ToString("F2");
        clearTimeTwo.text = clearTimeFloatTwo.ToString("F2");
        clearTimeThree.text = clearTimeFloatThree.ToString("F2");
    }

    public void ShowScreenMenu()
    {
        screenMenuUI.SetActive(true);
        float time = gameController.GetTimeElapsed();
        clearTime.text = time.ToString("F2");
        Time.timeScale = 0;
        
        starOne.texture = originalTexture;
        starTwo.texture = originalTexture;
        starThree.texture = originalTexture;
        
        if (time <= clearTimeFloatThree)
        {
            starOne.texture = newTexture;
            starTwo.texture = newTexture;
            starThree.texture = newTexture;
        }
        else if (time <= clearTimeFloatTwo)
        {
            starOne.texture = newTexture;
            starTwo.texture = newTexture;
        }
        else if (time <= clearTimeFloatOne)
        {
            starOne.texture = newTexture;
        }

        Cursor.lockState = CursorLockMode.None;
    }

    // public void SetStarBlack()
    // {
    //     starOne.texture = originalTexture;
    //     starTwo.texture = originalTexture;
    //     starThree.texture = originalTexture;
    // }
    public void SetTeleportTarget(GameObject target)
    {
        teleportTarget = target;
    }

    public void SetClearTime(float time)
    {
        clearTime.text = time.ToString("F2");
    }

    public void SetisGameStart(bool isStart)
    {
        isGameStart = isStart;
    }

    public void SetisLobby(bool islobby)
    {
        isPlayerLobby = islobby;
    }

    public void Next()
    {
        screenMenuUI.SetActive(false);
        controller.enabled = false;
        controller.transform.position = teleportTarget.transform.position;
        controller.transform.rotation = teleportTarget.transform.rotation;
        controller.enabled = true;
        // gameController.SetisLobby(isPlayerLobby);
        gameController.ResetTimeElapsed();
        restartController.SetRestartPoint(teleportTarget);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        gameController.SetisGameStart(true);
        if (goNextStage)
        {
            SceneManager.LoadScene(nextStageName);
        }
    }

    public void RestartStage()
    {
        screenMenuUI.SetActive(false);
        restartController.ResetGame();
        restartController.ResetPowerups();
        restartController.ResetStats();
        gameController.ResetTimeElapsed();
        Cursor.lockState = CursorLockMode.Locked;
        gameController.SetisGameStart(true);
        Time.timeScale = 1;
    }

    public void SetGoNextStage(bool isGoNextStage)
    {
        goNextStage = isGoNextStage;
    }

    public void SetNextStageName(string stageName)
    {
        nextStageName = stageName;
    }
}