using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatPiece : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]
    RandomMode randomMode;  
    Cell actualTile;
    GameObject actualPiece;
    Cell newSelectedTile;
    GameObject newPosition;
    private void Start()
    {
        gameManager= GetComponent<GameManager>();
    }
    public void CheckIfCanEat(Cell actualTile, GameObject actualPiece, Cell newSelectedTile, GameObject newPosition)
    {
        if (newSelectedTile.currentPiece.GetComponent<Piece>().ReturnCanBeEaten())
        {
            gameManager.ShowsRandomMode();
            randomMode.StartRandomMode(actualPiece, newSelectedTile, gameManager.TeamTurn);
            this.actualTile = actualTile;
            this.actualPiece = actualPiece;
            this.newSelectedTile = newSelectedTile;
            this.newPosition = newPosition;

        }
        else
        {
            Debug.LogWarning("NotAgoodPoint");
        }
    }
    public void EatAfterRandomDecision()
    {
        if (newSelectedTile.currentPiece.GetComponent<Piece>().ReturnType() == TypePiece.King)
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
}
