using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ListPiecesShow : MonoBehaviour
{
    [SerializeField]
    Team team;
    [SerializeField]
    Sprite spritePawn;
    [SerializeField]
    Sprite spriteTower;
    [SerializeField]
    Sprite spriteKnight;
    [SerializeField]
    Sprite spriteBishop;
    [SerializeField]
    Sprite spriteQueen;
    [SerializeField]
    Sprite spriteKing;
    [SerializeField]
    Image[] imagesPopulationHouse;
    private void Start()
    {
        HidePieces();
    }
    public void FindSprite(TypePiece typePiece)
    {
        switch (typePiece)
        {
            case TypePiece.None:
                break;
            case TypePiece.Bishop:
                HideAndShowPieces(spriteBishop);
                break;
            case TypePiece.Knight:
                HideAndShowPieces(spriteKnight);
                break;
            case TypePiece.Tower:
                HideAndShowPieces(spriteTower);
                break;
            case TypePiece.King:
                HideAndShowPieces(spriteKing);
                break;
            case TypePiece.Queen:
                HideAndShowPieces(spriteQueen);
                break;
            case TypePiece.Pawn:
                HideAndShowPieces(spritePawn);
                break;
            default:
                break;
        }
    }
    void HidePieces()
    {
        foreach (var item in imagesPopulationHouse)
        {
            if (item.sprite == null)
            {
                item.enabled = false;
                item.sprite = null;
            }
        }
    }
    // Start is called before the first frame update
    void HideAndShowPieces(Sprite spritePiece)
    {
        HidePieces();
        bool check = false;
        foreach (var item in imagesPopulationHouse)
        {
            if (!check)
            {
                if (item.sprite==null)
                {
                    item.sprite=spritePiece;
                    item.enabled = true;

                    check = true;
                }
            }
        }
    }
}
