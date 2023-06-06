using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatPiece : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]
    RandomMode randomMode;
    [SerializeField]
    ListPiecesShow listPieces1;
    [SerializeField]
    ListPiecesShow listPieces2;
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
        Checkteam();
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
    void Checkteam()
    {
        if (newSelectedTile.currentPiece.GetComponent<Piece>().ReturnTeam() == Team.One)
        {
            listPieces1.FindSprite(actualTile.currentPiece.GetComponent<Piece>().ReturnType());
        }
        else
        {
            listPieces2.FindSprite(actualTile.currentPiece.GetComponent<Piece>().ReturnType());

        }
    }
}
