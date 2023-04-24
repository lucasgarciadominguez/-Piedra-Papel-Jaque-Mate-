using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatPiece : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager= GetComponent<GameManager>();
    }
    public void CheckIfCanEat(Cell actualTile, GameObject actualPiece, Cell newSelectedTile, GameObject newPosition)
    {
        if (newSelectedTile.currentPiece.GetComponent<Piece>().ReturnCanBeEaten())
        {
            if (newSelectedTile.currentPiece.GetComponent<Piece>().ReturnType()==TypePiece.King)
            {
                Destroy(newSelectedTile.currentPiece.gameObject);
                newSelectedTile.currentPiece = actualPiece;
                actualTile.currentPiece = null;
                actualPiece.transform.position = newPosition.transform.position;
                gameManager.EndGame();
            }
            else
            {
                Destroy(newSelectedTile.currentPiece.gameObject);
                newSelectedTile.currentPiece = actualPiece;
                actualTile.currentPiece = null;
                actualPiece.transform.position = newPosition.transform.position;
            }

        }
        else
        {
            Debug.LogWarning("NotAgoodPoint");
        }
    }
}
