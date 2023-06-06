using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Skins
{
    None,
    Chocolate,
    Cubic,
    Simple
}
public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField]
    public string name;
    [SerializeField]
    public Skins skin;
    [SerializeField]
    public Team team;
    public Player(string name,int levels)
    {
        this.name = name;
    }
    public void SetName(string name)
    {
        this.name = name;
    }
    public string ReturnName()
    {
        return this.name;   
    }
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    public void Destroy()
    {
        Destroy(gameObject);

    }
}
