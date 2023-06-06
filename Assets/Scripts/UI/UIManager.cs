using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField]
    Animator animatorAcceptButton;
    [SerializeField]
    Animator AnimatorDenyButton;

    [SerializeField]
    TMP_Text player1name;
    [SerializeField]
    TMP_Text player2name;

    [SerializeField]
    Sprite spritePawnChocolate;
    [SerializeField]
    Sprite spriteTowerChocolate;
    [SerializeField]
    Sprite spriteKnightChocolate;
    [SerializeField]
    Sprite spriteBishopChocolate;
    [SerializeField]
    Sprite spriteQueenChocolate;
    [SerializeField]
    Sprite spriteKingChocolate;
    [SerializeField]
    Sprite spritePawnChocolateW;
    [SerializeField]
    Sprite spriteTowerChocolateW;
    [SerializeField]
    Sprite spriteKnightChocolateW;
    [SerializeField]
    Sprite spriteBishopChocolateW;
    [SerializeField]
    Sprite spriteQueenChocolateW;
    [SerializeField]
    Sprite spriteKingChocolateW;

    [SerializeField]
    Sprite spritePawnCubic;
    [SerializeField]
    Sprite spriteTowerCubic;
    [SerializeField]
    Sprite spriteKnightCubic;
    [SerializeField]
    Sprite spriteBishopCubic;
    [SerializeField]
    Sprite spriteQueenCubic;
    [SerializeField]
    Sprite spriteKingCubic;
    [SerializeField]
    Sprite spritePawnCubicW;
    [SerializeField]
    Sprite spriteTowerCubicW;
    [SerializeField]
    Sprite spriteKnightCubicW;
    [SerializeField]
    Sprite spriteBishopCubicW;
    [SerializeField]
    Sprite spriteQueenCubicW;
    [SerializeField]
    Sprite spriteKingCubicW;

    [SerializeField]
    Sprite spritePawnSimple;
    [SerializeField]
    Sprite spriteTowerSimple;
    [SerializeField]
    Sprite spriteKnightSimple;
    [SerializeField]
    Sprite spriteBishopSimple;
    [SerializeField]
    Sprite spriteQueenSimple;
    [SerializeField]
    Sprite spriteKingSimple;
    [SerializeField]
    Sprite spritePawnSimpleW;
    [SerializeField]
    Sprite spriteTowerSimpleW;
    [SerializeField]
    Sprite spriteKnightSimpleW;
    [SerializeField]
    Sprite spriteBishopSimpleW;
    [SerializeField]
    Sprite spriteQueenSimpleW;
    [SerializeField]
    Sprite spriteKingSimpleW;
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
    public void HighLightsButtons()
    {
        animatorAcceptButton.SetTrigger("Highlights");
        AnimatorDenyButton.SetTrigger("Highlights");
    }
    public void SelectTurns(bool changeTurns)
    {
        selectTurns.ChangeTurns(changeTurns);    
    }
    public void SetNamesPlayers(string namePlayer1, string namePlayer2)
    {
        player1name.text= namePlayer1;
        player2name.text= namePlayer2;
    }
    public void ChangeSprites(SpriteRenderer spriteRenderer,TypePiece type,Skins skin,Team team)
    {
        if (team==Team.One)
        {
            switch (type)
            {
                case TypePiece.None:
                    break;
                case TypePiece.Bishop:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spriteBishopChocolateW; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spriteBishopCubicW; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spriteBishopSimpleW; break;
                    }
                    break;
                case TypePiece.Knight:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spriteKnightChocolateW; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spriteKnightCubicW; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spriteKnightSimpleW; break;
                    }
                    break;
                case TypePiece.Tower:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spriteTowerChocolateW; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spriteTowerCubicW; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spriteTowerSimpleW; break;
                    }
                    break;
                case TypePiece.King:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spriteKingChocolateW; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spriteKingCubicW; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spriteKingSimpleW; break;
                    }
                    break;
                case TypePiece.Queen:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spriteQueenChocolateW; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spriteQueenCubicW; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spriteQueenSimpleW; break;
                    }
                    break;
                case TypePiece.Pawn:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spritePawnChocolateW; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spritePawnCubicW; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spritePawnSimpleW; break;
                    }
                    break;
                default:
                    break;
            }
        }
        else if ((team==Team.Two))
        {
            switch (type)
            {
                case TypePiece.None:
                    break;
                case TypePiece.Bishop:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spriteBishopChocolate; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spriteBishopCubic; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spriteBishopSimple; break;
                    }
                    break;
                case TypePiece.Knight:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spriteKnightChocolate; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spriteKnightCubic; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spriteKnightSimple; break;
                    }
                    break;
                case TypePiece.Tower:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spriteTowerChocolate; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spriteTowerCubic; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spriteTowerSimple; break;
                    }
                    break;
                case TypePiece.King:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spriteKingChocolate; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spriteKingCubic; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spriteKingSimple; break;
                    }
                    break;
                case TypePiece.Queen:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spriteQueenChocolate; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spriteQueenCubic; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spriteQueenSimple; break;
                    }
                    break;
                case TypePiece.Pawn:
                    if (skin == Skins.Chocolate)
                    {
                        spriteRenderer.sprite = spritePawnChocolate; break;
                    }
                    else if (skin == Skins.Cubic)
                    {
                        spriteRenderer.sprite = spritePawnCubic; break;
                    }
                    else if (skin == Skins.Simple)
                    {
                        spriteRenderer.sprite = spritePawnSimple; break;
                    }
                    break;
                default:
                    break;
            }
        }

    }
    public void ChangeTurnsRandomMode()
    {

    }
}
