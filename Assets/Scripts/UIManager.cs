using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject uiText;
    public void EndGameUI()
    {
        uiText.SetActive(true);
    }
}
