using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    GameObject piecesParent;
    [SerializeField]
    GameObject pawnBlack;
    [SerializeField]
    GameObject bishopBlack;
    [SerializeField]
    GameObject kingBlack;
    [SerializeField]
    GameObject queenBlack;
    [SerializeField]
    GameObject towerBlack;
    [SerializeField]
    GameObject knightBlack;
    [SerializeField]
    GameObject pawnWhite;
    [SerializeField]
    GameObject bishopWhite;
    [SerializeField]
    GameObject kingWhite;
    [SerializeField]
    GameObject queenWhite;
    [SerializeField]
    GameObject towerWhite;
    [SerializeField]
    GameObject knightWhite;

    GenerateBoard generateBoard;
    public List<GameObject> pieces = new List<GameObject>();
    public Cell[,] grid { get; private set; }
    private void Awake()
    {
        generateBoard = GetComponent<GenerateBoard>();

    }
    void Start()
    {
        grid = new Cell[Metrics.size, Metrics.size];
        generateBoard.CreateVisualBoard(grid,this.gameObject);
        IEnumerator co;
        co = CreatePiecesA();
        StartCoroutine(co); 
    }
    IEnumerator CreatePiecesA()
    {
        yield return new WaitForSeconds(0.05f);
        PlacePieces();
        StopCoroutine(CreatePiecesA()); // stop it.


    }
    public void PlacePieces()
    {
        for (int i = 0; i < Metrics.size; i++)
        {
            pieces.Add(grid[i, 1].currentPiece = Instantiate(pawnWhite, grid[i, 1].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        }
        pieces.Add(grid[0,0].currentPiece= Instantiate(towerWhite, grid[0,0].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[7, 0].currentPiece = Instantiate(towerWhite, grid[7, 0].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[1, 0].currentPiece = Instantiate(knightWhite, grid[1, 0].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[6, 0].currentPiece = Instantiate(knightWhite, grid[6, 0].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[2, 0].currentPiece = Instantiate(bishopWhite, grid[2, 0].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[5, 0].currentPiece = Instantiate(bishopWhite, grid[5, 0].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[3, 0].currentPiece = Instantiate(queenWhite, grid[3, 0].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[4, 0].currentPiece = (Instantiate(kingWhite, grid[4, 0].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform)));

        for (int i = 0; i < Metrics.size; i++)
        {
            pieces.Add(grid[i, 6].currentPiece = Instantiate(pawnBlack, grid[i, 6].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        }

        pieces.Add(grid[0, 7].currentPiece = Instantiate(towerBlack, grid[0, 7].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[7, 7].currentPiece = Instantiate(towerBlack, grid[7, 7].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[1, 7].currentPiece = Instantiate(knightBlack, grid[1, 7].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[6, 7].currentPiece = Instantiate(knightBlack, grid[6, 7].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[2, 7].currentPiece = Instantiate(bishopBlack, grid[2, 7].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[5, 7].currentPiece = Instantiate(bishopBlack, grid[5, 7].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[3, 7].currentPiece = Instantiate(queenBlack, grid[3, 7].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
        pieces.Add(grid[4, 7].currentPiece = Instantiate(kingBlack, grid[4, 7].gameObject.GetComponent<CameraAnchor>().realPosition, Quaternion.identity, piecesParent.transform));
    }
}

