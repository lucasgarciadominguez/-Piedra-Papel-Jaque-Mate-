using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    Board board;
    public GameObject whiteKing;
    public GameObject blackKing;
    public GameObject whiteQueen;
    public GameObject blackQueen;
    public GameObject whiteRook;
    public GameObject blackRook;
    public GameObject whiteBishop;
    public GameObject blackBishop;
    public GameObject whiteKnight;
    public GameObject blackKnight;
    public GameObject whitePawn;
    public GameObject blackPawn;
    private Piece[,] pieces = new Piece[8, 8];

    // Start is called before the first frame update
    private void Awake()
    {
        board = GetComponent<Board>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
