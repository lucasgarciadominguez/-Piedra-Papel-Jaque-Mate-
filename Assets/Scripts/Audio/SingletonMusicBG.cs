using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMusicBG : MonoBehaviour
{
    public static SingletonMusicBG instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
