using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionsButtons : MonoBehaviour
{
    [SerializeField]
    ChangeScenes changeScenes;
    [SerializeField]
    InputManager inputManager;
    bool canOperate=false;
    public void LoadMenu()
    {
        changeScenes.LoadMenuScene();
    }
    public void ConfirmDecision()
    {
        inputManager.ExecuteMovement();
    }
    public void DenyDecision()
    {
        canOperate=false;
    }
    public bool ReturnCanOperate()
    {
        return canOperate;
    }
}
