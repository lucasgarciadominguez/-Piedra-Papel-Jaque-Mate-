using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMovements : MonoBehaviour
{
    GameManager manager;
    [SerializeField]
    Sprite cellSelectedSprite;
    [SerializeField]
    Sprite cellPossiblePositionsSprite;
    [SerializeField]
    Sprite cellPossibleEatPositionsSprite;
    public List<Cell> possibleCells = new List<Cell>();
    [SerializeField]
    Board board;
    private void Start()
    {
        manager = GetComponent<GameManager>();
    }
    public void ShowMovementsForPiece(Cell selectedTile)
    {
        ClearPosibleCells();
        if (selectedTile.currentPiece != null)
        {
            if (selectedTile.currentPiece.GetComponent<Piece>().ReturnTeam()==manager.TeamTurn)
            {
                bool isHisFirstMove = selectedTile.currentPiece.GetComponent<Piece>().ReturnIsHisFirstMove();
                selectedTile.ChangeSprite(cellSelectedSprite);
                CheckIfCanMove(selectedTile,isHisFirstMove);


                HighLightsPosiblePositions();
            }


        }

    }
    public void ClearPosibleCells()
    {

        foreach (var item in possibleCells)
        {
            item.SetMainSprite();
        }
        possibleCells.Clear();
    }
    public void CheckIfCanMove(Cell selectedTile,bool isHisFirstMove)
    {
        TypePiece pieceType = selectedTile.currentPiece.GetComponent<Piece>().ReturnType();
        switch (pieceType)
        {
            case TypePiece.None:
                break;
            case TypePiece.Bishop:
                Dictionary<OrientationPosition, List<Vector2Int>> listsPossiblePositionsBishop = selectedTile.currentPiece.GetComponent<Piece>().ReturnPossiblePositions();

                UnlockTheMovements(listsPossiblePositionsBishop[OrientationPosition.TopRight], OrientationPosition.TopRight, selectedTile);
                UnlockTheMovements(listsPossiblePositionsBishop[OrientationPosition.TopLeft], OrientationPosition.TopLeft, selectedTile);
                UnlockTheMovements(listsPossiblePositionsBishop[OrientationPosition.BottomLeft], OrientationPosition.BottomLeft, selectedTile);
                UnlockTheMovements(listsPossiblePositionsBishop[OrientationPosition.BottomRight], OrientationPosition.BottomRight, selectedTile);
                break;
            case TypePiece.Knight:
                Dictionary<OrientationPosition, List<Vector2Int>> listsPossiblePositionsKnight = selectedTile.currentPiece.GetComponent<Piece>().ReturnPossiblePositions();
                UnlockTheMovements(listsPossiblePositionsKnight[OrientationPosition.Knight], OrientationPosition.Knight, selectedTile);

                break;
            case TypePiece.Tower:
                Dictionary<OrientationPosition, List<Vector2Int>> listsPossiblePositionsTower = selectedTile.currentPiece.GetComponent<Piece>().ReturnPossiblePositions();
                UnlockTheMovements(listsPossiblePositionsTower[OrientationPosition.Top], OrientationPosition.Top, selectedTile);
                UnlockTheMovements(listsPossiblePositionsTower[OrientationPosition.Bottom], OrientationPosition.Bottom, selectedTile);
                UnlockTheMovements(listsPossiblePositionsTower[OrientationPosition.Right], OrientationPosition.Right, selectedTile);
                UnlockTheMovements(listsPossiblePositionsTower[OrientationPosition.Left], OrientationPosition.Left, selectedTile);
                break;
            case TypePiece.King:
                Dictionary<OrientationPosition, List<Vector2Int>> listsPossiblePositionsKing = selectedTile.currentPiece.GetComponent<Piece>().ReturnPossiblePositions();
                UnlockTheMovements(listsPossiblePositionsKing[OrientationPosition.Top], OrientationPosition.Top, selectedTile);
                UnlockTheMovements(listsPossiblePositionsKing[OrientationPosition.Bottom], OrientationPosition.Bottom, selectedTile);
                UnlockTheMovements(listsPossiblePositionsKing[OrientationPosition.Right], OrientationPosition.Right, selectedTile);
                UnlockTheMovements(listsPossiblePositionsKing[OrientationPosition.Left], OrientationPosition.Left, selectedTile);

                UnlockTheMovements(listsPossiblePositionsKing[OrientationPosition.TopRight], OrientationPosition.TopRight, selectedTile);
                UnlockTheMovements(listsPossiblePositionsKing[OrientationPosition.TopLeft], OrientationPosition.TopLeft, selectedTile);
                UnlockTheMovements(listsPossiblePositionsKing[OrientationPosition.BottomLeft], OrientationPosition.BottomLeft, selectedTile);
                UnlockTheMovements(listsPossiblePositionsKing[OrientationPosition.BottomRight], OrientationPosition.BottomRight, selectedTile);
                break;
            case TypePiece.Queen:
                Dictionary<OrientationPosition, List<Vector2Int>> listsPossiblePositions = selectedTile.currentPiece.GetComponent<Piece>().ReturnPossiblePositions();
                UnlockTheMovements(listsPossiblePositions[OrientationPosition.Top], OrientationPosition.Top, selectedTile);
                UnlockTheMovements(listsPossiblePositions[OrientationPosition.Bottom], OrientationPosition.Bottom, selectedTile);
                UnlockTheMovements(listsPossiblePositions[OrientationPosition.Right], OrientationPosition.Right, selectedTile);
                UnlockTheMovements(listsPossiblePositions[OrientationPosition.Left], OrientationPosition.Left, selectedTile);

                UnlockTheMovements(listsPossiblePositions[OrientationPosition.TopRight], OrientationPosition.TopRight, selectedTile);
                UnlockTheMovements(listsPossiblePositions[OrientationPosition.TopLeft], OrientationPosition.TopLeft, selectedTile);
                UnlockTheMovements(listsPossiblePositions[OrientationPosition.BottomLeft], OrientationPosition.BottomLeft, selectedTile);
                UnlockTheMovements(listsPossiblePositions[OrientationPosition.BottomRight], OrientationPosition.BottomRight, selectedTile);
                break;
            case TypePiece.Pawn:
                Dictionary<OrientationPosition, List<Vector2Int>> listsPossiblePositionsPawn = selectedTile.currentPiece.GetComponent<Piece>().ReturnPossiblePositions();
                if (isHisFirstMove)
                {
                    UnlockTheMovements(listsPossiblePositionsPawn[OrientationPosition.TopFirstMove], OrientationPosition.TopFirstMove, selectedTile);
                    UnlockTheMovements(listsPossiblePositionsPawn[OrientationPosition.BottomFirstMove], OrientationPosition.BottomFirstMove, selectedTile);
                }
                else
                {
                    UnlockTheMovements(listsPossiblePositionsPawn[OrientationPosition.Top], OrientationPosition.Top, selectedTile);
                    UnlockTheMovements(listsPossiblePositionsPawn[OrientationPosition.Bottom], OrientationPosition.Bottom, selectedTile);
                }
                UnlockTheMovements(listsPossiblePositionsPawn[OrientationPosition.PawnEat], OrientationPosition.PawnEat, selectedTile);
                break;
            default:
                break;
        }



        
    }
    public void UnlockTheMovements(List<Vector2Int> list,OrientationPosition orientation,Cell selectedTile)
    {
        bool continueExploringOrientation=true;
        foreach (var item in list)
        {
            if (continueExploringOrientation)
            {
                int x = selectedTile.ReturnX() + (item.x);
                int y = selectedTile.ReturnY() + (item.y);
                if (CheckIfItsCorrectThePosition(x, y, orientation))
                {
                    if (CheckIfItsNotAlly(x, y, orientation))
                    {
                        possibleCells.Add(board.grid[x, y]);
                    }
                    else
                    {
                        if (orientation == OrientationPosition.Knight || orientation == OrientationPosition.PawnEat)
                        {
                        }
                        else
                        {
                            continueExploringOrientation = false;
                        }
                    }
                }
                else
                {
                    if (orientation==OrientationPosition.Knight|| orientation == OrientationPosition.PawnEat)
                    {
                    }
                    else
                    {
                        continueExploringOrientation = false;
                    }



                }

            }
        }

    }
    bool CheckIfItsNotAlly(int x, int y,OrientationPosition type)
    {
        if (board.grid[x, y].currentPiece == null)
        {
            if (type == OrientationPosition.PawnEat)
            {
                return false;
            }
            return true;
        }
        else
        {
            if (board.grid[x, y].currentPiece.GetComponent<Piece>().ReturnTeam()== manager.TeamTurn)
            {
                return false;
            }
            else
            {
                if (type == OrientationPosition.Knight)
                {
                    board.grid[x, y].currentPiece.GetComponent<Piece>().canBeEaten = true;
                    possibleCells.Add(board.grid[x, y]);
                    return true;
                    //can eat and continues
                }
                else
                {
                    if (type == OrientationPosition.Top || type == OrientationPosition.Bottom)
                    {
                        return false;
                    }
                    else if (type == OrientationPosition.PawnEat)
                    {
                        board.grid[x, y].currentPiece.GetComponent<Piece>().canBeEaten = true;
                        possibleCells.Add(board.grid[x, y]);


                        return true;
                    }
                    else
                    {
                        board.grid[x, y].currentPiece.GetComponent<Piece>().canBeEaten = true;
                        possibleCells.Add(board.grid[x, y]);

                        return false;
                        //can eat
                    }

                }

            }

        }
        
    }
    bool CheckIfItsCorrectThePosition(int x,int y,OrientationPosition orientation)
    {
        if (x <= 7 && x >= 0 && y <= 7 && y >= 0)
        {
            return true;
        }
        return false;
    }
    public void HighLightsPosiblePositions()
    {
        foreach (var item in possibleCells)
        {
            item.ChangeSprite(cellPossiblePositionsSprite);
            if (item.currentPiece!=null)
            {
                if (item.currentPiece.GetComponent<Piece>().ReturnCanBeEaten())
                {
                    item.ChangeSprite(cellPossibleEatPositionsSprite);

                }
            }

        }
    }
}
