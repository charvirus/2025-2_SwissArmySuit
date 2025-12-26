using TMPro;
using UnityEngine;

public class SceneChange : MonoBehaviour
{ 
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;
    
    void FreezePlayer()
    {
        playerMovement.SetCanmove(false);
        mouseLook.SetCanLook(false);
    }
    void ActivatePlayer()
    {
        playerMovement.SetCanmove(true);
        mouseLook.SetCanLook(true);
    }
}
