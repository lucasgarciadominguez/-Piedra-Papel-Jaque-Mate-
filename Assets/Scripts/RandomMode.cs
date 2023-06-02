using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RandomChoices
{
    None,
    Rock,
    Paper,
    Scissors
}
public class RandomMode : MonoBehaviour
{
    [SerializeField]
    Animator animatorPanelBGRandomMode;
    [SerializeField]
    Animator animatorDivisionLineRandomMode;
    [SerializeField]
    Animator VSRandomMode;


    [SerializeField]
    Animator animatorPlayer1Cards;
    [SerializeField]
    Animator animatorPlayer2Cards;
    [SerializeField]
    Animator animatorPlayer1Piece;
    [SerializeField]
    Animator animatorPlayer2Piece;


    [SerializeField]
    UIManager managerUI;
    [SerializeField]
    RandomChoices choicePlayer1 = RandomChoices.None;
    [SerializeField]
    RandomChoices choicePlayer2 = RandomChoices.None;
    [SerializeField]
    EatPiece eatPiece;
    private void Awake()
    {
        this.gameObject.SetActive(false);   
    }
    public void StartRandomMode(GameObject actualTile, Cell otherTile,Team teamTurn)
    {
        Sprite piece = actualTile.GetComponent<SpriteRenderer>().sprite;
        Sprite piece2 = otherTile.currentPiece.GetComponent<SpriteRenderer>().sprite;
        managerUI.PassInformationRandomMode(piece, piece2);
        managerUI.SelectTurns(false);
    }

    public void SetRandomChoice(int choice)
    {
        if (choicePlayer1==0)
        {
            if (choice==0)
            {
                choicePlayer1= RandomChoices.Rock;
            }
            else if (choice == 1)
            {
                choicePlayer1 = RandomChoices.Paper;

            }
            else if (choice == 2)
            {
                choicePlayer1 = RandomChoices.Scissors;
            }
        }
        else
        {
            if (choice == 0)
            {
                choicePlayer2 = RandomChoices.Rock;
            }
            else if (choice == 1)
            {
                choicePlayer2 = RandomChoices.Paper;

            }
            else if (choice == 2)
            {
                choicePlayer2 = RandomChoices.Scissors;
            }
        }
        ChangeTurnRandomMode();
    }
    void ChangeTurnRandomMode()
    {
        if (choicePlayer1==RandomChoices.None|| choicePlayer2 == RandomChoices.None)
        {
            managerUI.SelectTurns(true);
            animatorPlayer1Cards.SetTrigger("ChangeTurnPlayer1");
            animatorPlayer2Cards.SetTrigger("ChangeTurnPlayer2");
            animatorPlayer1Piece.SetTrigger("ChangeTurnPlayer1Piece");
            animatorPlayer2Piece.SetTrigger("ChangeTurnPlayer2Piece");
        }
        else
        {
            FinishRandomMode();
        }


    }
    void FinishRandomMode()
    {
        animatorPanelBGRandomMode.SetTrigger("Disable");
        animatorDivisionLineRandomMode.SetTrigger("Disable");
        VSRandomMode.SetTrigger("Disable");
        animatorPlayer1Cards.SetTrigger("Disable");
        animatorPlayer2Cards.SetTrigger("Disable");
        animatorPlayer1Piece.SetTrigger("Disable");
        animatorPlayer2Piece.SetTrigger("Disable");

        animatorPlayer1Cards.SetBool("ChangeTurnAppear",false);
        animatorPlayer2Cards.SetBool("ChangeTurnAppear", false);
        animatorPlayer1Piece.SetBool("ChangeTurnAppear", false);
        animatorPlayer2Piece.SetBool("ChangeTurnAppear", false);
    }
}
