using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardBehavior : MonoBehaviour
{
    public Restart restart;
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.CompareTag("Player"))
        {
            restart.ResetStats();
            restart.ResetPowerups();
            restart.ResetGame();
        }
    }
}
