using System;
using UnityEngine;

public class StatChange : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public bool isDisappear = false;
    public bool isItem = false;

    public AudioClip soundEffect;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            playerMovement.SetGravity(gravity);
            playerMovement.SetSpeed(speed);
            playerMovement.SetJumpHeight(jumpHeight);
            if (isItem)
            {
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            }

            if (isDisappear)
            {
                gameObject.SetActive(false);
            }
        }
    }
}