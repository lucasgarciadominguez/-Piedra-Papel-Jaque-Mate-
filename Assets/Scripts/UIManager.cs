using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject uiText;
    [SerializeField]
    GameObject randomMode;
    [SerializeField]
    Image player1Piece;
    [SerializeField]
    Image player2Piece;
    [SerializeField]
    SelectTurns selectTurns;


    public void EndGameUI()
    {
        uiText.SetActive(true);
    }

    public void PassInformationRandomMode(Sprite spritePlayer1, Sprite spritePlayer2,Material materialPlayer1, Material materialPlayer2)
    {
        player1Piece.sprite = spritePlayer1;
        player1Piece.material = materialPlayer1;
        player2Piece.sprite = spritePlayer2;
        player2Piece.material = materialPlayer2;
    }
    public void SelectTurns(bool changeTurns)
    {
        selectTurns.ChangeTurns(changeTurns);    
    }
    public void ChangeTurnsRandomMode()
    {

    }
}
