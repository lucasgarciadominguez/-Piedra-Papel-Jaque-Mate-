using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    [SerializeField]
    EatPiece eatPiece;
    public void MoveToNewPosition(Cell actualTile,GameObject actualPiece, Cell newSelectedTile,GameObject newPosition)
    {
        if (!newSelectedTile.currentPiece)
        {
            newSelectedTile.currentPiece = actualPiece;
            actualTile.currentPiece = null;
            actualPiece.transform.position= newPosition.transform.position;
        }
        else
        {
            eatPiece.CheckIfCanEat( actualTile,  actualPiece,  newSelectedTile,newPosition);
            //MoveToNewPosition(actualTile, actualPiece, newSelectedTile, newPosition);
        }
        if (actualPiece.GetComponent<Piece>().ReturnType()==TypePiece.Pawn) //selects his first move
        {
            Debug.Log("Its a pawn");
            if (actualPiece.GetComponent<Piece>().ReturnIsHisFirstMove())
            {
                Debug.Log("Its his first move");

                actualPiece.GetComponent<Piece>().ChangeFirstMove();

            }
        }
    }
}
