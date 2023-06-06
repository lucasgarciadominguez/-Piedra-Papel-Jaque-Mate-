using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerInputDataPlayers : MonoBehaviour
{
    [SerializeField]
    public Team teamTurn = Team.One;
    [SerializeField]
    ChangeScenes changeScenes;
    [SerializeField]
    ReadInput readInput;
    [SerializeField]
    Player player1;
    [SerializeField]
    Player player2;
    [SerializeField]
    TMP_Text textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChargeAllInfo()
    {
        if (teamTurn==Team.Two) 
        {
            string inputName= readInput.ReadStringInput();
            Skins skin=readInput.ReadSkinInput();
            player2.SetName(inputName);
            player2.team=Team.Two;
            player2.skin= skin;

            ChangeScene();
        }
        else
        {
            ChangeTeamTurn();
            string inputName = readInput.ReadStringInput();
            Skins skin = readInput.ReadSkinInput();
            player1.SetName(inputName);
            player1.skin = skin;
            player2.team = Team.One;

        }
    }
    void ChangeScene()
    {
        changeScenes.LoadGameScene();
    }
    void ChangeTeamTurn()
    {
        teamTurn=Team.Two;
        ChangeTurnTextUI();
    }
    void ChangeTurnTextUI()
    {
        textMeshPro.text = "PLAYER 2 TURN:";
    }
}
