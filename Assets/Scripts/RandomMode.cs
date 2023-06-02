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
    Animator animatorPlayer1Cards;
    [SerializeField]
    Animator animatorPlayer2Cards;
    [SerializeField]
    UIManager managerUI;
    RandomChoices choicePlayer1= RandomChoices.None;
    RandomChoices choicePlayer2 = RandomChoices.None;

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
                choicePlayer1= RandomChoices.Paper;
            }
            else if (choice == 1)
            {
                choicePlayer1 = RandomChoices.Rock;

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
                choicePlayer2 = RandomChoices.Paper;
            }
            else if (choice == 1)
            {
                choicePlayer2 = RandomChoices.Rock;

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
        managerUI.SelectTurns(true);
        animatorPlayer1Cards.SetTrigger("ChangeTurnPlayer1");
        animatorPlayer2Cards.SetTrigger("ChangeTurnPlayer2");

    }
}
