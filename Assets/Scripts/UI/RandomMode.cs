using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

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
    bool firstTime = false;
    bool check = false;
    [SerializeField]
    Image imagePlayer1Piece;
    [SerializeField]
    Image imagePlayer2Piece;
    private void Awake()
    {
    }
    public void StartRandomMode(GameObject actualTile, Cell otherTile,Team teamTurn)
    {
        //ChangeColor();

        Sprite piece = actualTile.GetComponent<SpriteRenderer>().sprite;
        Material mat1= actualTile.GetComponent<SpriteRenderer>().material;
        Sprite piece2 = otherTile.currentPiece.GetComponent<SpriteRenderer>().sprite;
        Material mat2 = otherTile.currentPiece.GetComponent<SpriteRenderer>().material;
        managerUI.PassInformationRandomMode(piece, piece2, mat1, mat2);
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
            if (firstTime)
            {
                //ChangeColor();
                Debug.Log("h");
                animatorPlayer1Cards.SetTrigger("ChangeTurnPlayer1");
                animatorPlayer2Cards.SetTrigger("ChangeTurnPlayer2");
                animatorPlayer1Piece.SetTrigger("ChangeTurnPlayer1Piece");
                animatorPlayer2Piece.SetTrigger("ChangeTurnPlayer2Piece");
                firstTime = false;

            }
            else
            {
                animatorPlayer1Cards.SetTrigger("Disable");
                animatorPlayer2Cards.SetTrigger("Disable");
                animatorPlayer1Piece.SetTrigger("Disable");
                animatorPlayer2Piece.SetTrigger("Disable");
            }

        }
        else
        {
            FinishRandomMode();
        }


    }
    void ChangeColor()
    {
        if (check)
        {
            Color color = imagePlayer1Piece.material.GetColor("_OutlineColor");
            float factor = Mathf.Pow(2, 1);

            color = new Color(color.r * factor, color.g * factor, color.b * factor, color.a);
            imagePlayer1Piece.material.SetColor("_OutlineColor", color);

            Color color2 = imagePlayer2Piece.material.GetColor("_OutlineColor");
            float factor2 = Mathf.Pow(2, 1);


            color2 = new Color(color2.r * factor2, color2.g * factor2, color2.b * factor2, color2.a);
            imagePlayer2Piece.material.SetColor("_OutlineColor", color2);
            check = false;
        }
        else
        {
            Color color = Color.yellow;
            float factor = Mathf.Pow(2, 1);
            Debug.Log(factor);

            color = new Color(color.r * factor, color.g * factor, color.b * factor, color.a);
            imagePlayer1Piece.material.SetColor("_OutlineColor", color);

            Color color2 = Color.yellow;
            float factor2 = Mathf.Pow(2, -10f);
            Debug.Log(factor2);

            color2 = new Color(color2.r * factor2, color2.g * factor2, color2.b * factor2, color2.a);
            imagePlayer2Piece.material.SetColor("_OutlineColor", color2);
            check = true;
        }

    }
    void FinishRandomMode()
    {
        TakeDecision();


    }
    public void EnableRandomMode()
    {
        firstTime=true;
        animatorPanelBGRandomMode.SetTrigger("StartMode");
        animatorDivisionLineRandomMode.SetTrigger("StartMode");
        VSRandomMode.SetTrigger("StartMode");
        animatorPlayer1Cards.SetTrigger("StartMode");
        animatorPlayer2Cards.SetTrigger("StartMode");
        animatorPlayer1Piece.SetTrigger("StartMode");
        animatorPlayer2Piece.SetTrigger("StartMode");
        animatorPlayer1Cards.SetBool("ChangeTurnAppear", true);
        animatorPlayer2Cards.SetBool("ChangeTurnAppear", true);
        animatorPlayer1Piece.SetBool("ChangeTurnAppear", true);
        animatorPlayer2Piece.SetBool("ChangeTurnAppear", true);
    }
    void TakeDecision()
    {
        if (choicePlayer1==RandomChoices.Rock)
        {
            if (choicePlayer2==RandomChoices.Rock)
            {
                Tie();
            }
            else if (choicePlayer2 == RandomChoices.Paper)
            {
                Lose();
            }
            else if (choicePlayer2 == RandomChoices.Scissors)
            {
                Win();
            }
        }
        else if (choicePlayer1 == RandomChoices.Paper)
        {
            if (choicePlayer2 == RandomChoices.Rock)
            {
                Win();
            }
            else if (choicePlayer2 == RandomChoices.Paper)
            {
                Tie();
            }
            else if (choicePlayer2 == RandomChoices.Scissors)
            {
                Lose();
            }
        }
        else if (choicePlayer1 == RandomChoices.Scissors)
        {
            if (choicePlayer2 == RandomChoices.Rock)
            {
                Lose();
            }
            else if (choicePlayer2 == RandomChoices.Paper)
            {
                Win();
            }
            else if (choicePlayer2 == RandomChoices.Scissors)
            {
                Tie();
            }
        }
        choicePlayer1 = RandomChoices.None;
        choicePlayer2 = RandomChoices.None;
    }
    public void Win()
    {
        animatorPanelBGRandomMode.SetTrigger("Disable");
        animatorDivisionLineRandomMode.SetTrigger("Disable");
        VSRandomMode.SetTrigger("Disable");
        animatorPlayer1Cards.SetTrigger("Disable");
        animatorPlayer2Cards.SetTrigger("Disable");
        animatorPlayer1Piece.SetTrigger("Disable");
        animatorPlayer2Piece.SetTrigger("Disable");

        animatorPlayer1Cards.SetBool("ChangeTurnAppear", false);
        animatorPlayer2Cards.SetBool("ChangeTurnAppear", false);
        animatorPlayer1Piece.SetBool("ChangeTurnAppear", false);
        animatorPlayer2Piece.SetBool("ChangeTurnAppear", false);

        animatorPlayer1Cards.SetTrigger("SetDefault");
        animatorPlayer2Cards.SetTrigger("SetDefault");
        animatorPlayer1Piece.SetTrigger("HasWin");
        //animatorPlayer1Piece.SetTrigger("SetDefault");
        animatorPlayer2Piece.SetTrigger("SetDefault");

        eatPiece.EatAfterRandomDecision();
    }
    public void Tie()
    {
        animatorPlayer1Cards.SetTrigger("Disable");
        animatorPlayer2Cards.SetTrigger("Disable");
        animatorPlayer1Piece.SetTrigger("Disable");
        animatorPlayer2Piece.SetTrigger("Disable");

        animatorPlayer1Cards.SetBool("ChangeTurnAppear", true);
        animatorPlayer2Cards.SetBool("ChangeTurnAppear", true);
        animatorPlayer1Piece.SetBool("ChangeTurnAppear", true);
        animatorPlayer2Piece.SetBool("ChangeTurnAppear", true);
    }
    public void Lose()
    {
        animatorPanelBGRandomMode.SetTrigger("Disable");
        animatorDivisionLineRandomMode.SetTrigger("Disable");
        VSRandomMode.SetTrigger("Disable");
        animatorPlayer1Cards.SetTrigger("Disable");
        animatorPlayer2Cards.SetTrigger("Disable");
        animatorPlayer1Piece.SetTrigger("Disable");
        animatorPlayer2Piece.SetTrigger("Disable");

        animatorPlayer1Cards.SetBool("ChangeTurnAppear", false);
        animatorPlayer2Cards.SetBool("ChangeTurnAppear", false);
        animatorPlayer1Piece.SetBool("ChangeTurnAppear", false);
        animatorPlayer2Piece.SetBool("ChangeTurnAppear", false);

        animatorPlayer1Cards.SetTrigger("SetDefault");
        animatorPlayer2Cards.SetTrigger("SetDefault");
        animatorPlayer1Piece.SetTrigger("SetDefault");
        animatorPlayer2Piece.SetTrigger("HasWin");
        //animatorPlayer2Piece.SetTrigger("SetDefault");
    }
}
