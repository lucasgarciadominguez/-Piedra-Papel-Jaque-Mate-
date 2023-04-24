using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Team TeamTurn;
    [SerializeField]
    public bool isPlaying;
    [SerializeField]
    UIManager iManager;
    // Start is called before the first frame update
    void Start()
    {
        TeamTurn = Team.One;
        isPlaying= true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MovementFinished()
    {
        if (TeamTurn == Team.One)
            TeamTurn = Team.Two;
        else
            TeamTurn = Team.One;

    }
    public void EndGame()
    {
        isPlaying = false;
        iManager.EndGameUI();

    }
}
