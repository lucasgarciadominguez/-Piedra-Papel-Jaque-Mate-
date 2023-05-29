using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypePiece
{
    None,
    Bishop,
    Knight,
    Tower,
    King,
    Queen,
    Pawn,
}
public enum Team
{
    One,
    Two
}
public enum OrientationPosition
{
    None,PawnEat,Knight,Left, Right, Top,TopFirstMove, Bottom,BottomFirstMove, TopLeft, BottomLeft, TopRight, BottomRight
}
public class Piece : MonoBehaviour
{
    [SerializeField]
    TypePiece type;
    [SerializeField]
    Team team;
    public bool canBeEaten { private get; set; }
      List<Vector2Int> possiblePositionsPawnEat = new List<Vector2Int>();
     List<Vector2Int> possiblePositionsKnight = new List<Vector2Int>();
      List<Vector2Int> possiblePositionsLeft= new List<Vector2Int>();
     List<Vector2Int> possiblePositionsRight = new List<Vector2Int>();
     List<Vector2Int> possiblePositionsTop = new List<Vector2Int>();
     List<Vector2Int> possiblePositionsBottom = new List<Vector2Int>();
    List<Vector2Int> possiblePositionsTopFirstMove = new List<Vector2Int>();
    List<Vector2Int> possiblePositionsBottomFirstMove = new List<Vector2Int>();
    List<Vector2Int> possiblePositionsTopLeft = new List<Vector2Int>();
     List<Vector2Int> possiblePositionsBottomLeft = new List<Vector2Int>();
     List<Vector2Int> possiblePositionsBottomTopRight = new List<Vector2Int>();
     List<Vector2Int> possiblePositionsBottomRight = new List<Vector2Int>();
    Dictionary<OrientationPosition,List<Vector2Int>> orientationPositions;
    public bool isHisFirstMove { private get; set; }=true;
    bool control=false;
    private void Start()
    {
        canBeEaten= false;
         orientationPositions=new Dictionary<OrientationPosition, List<Vector2Int>>();
        switch (type)
        {
            case TypePiece.None:
                break;
            case TypePiece.Bishop:
                orientationPositions.Add(OrientationPosition.TopRight, possiblePositionsBottomTopRight = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.TopRight));
                orientationPositions.Add(OrientationPosition.TopLeft,possiblePositionsTopLeft = GeneratePositions.GenerateNewPositions(type, team,OrientationPosition.TopLeft));
                orientationPositions.Add(OrientationPosition.BottomRight,possiblePositionsBottomRight = GeneratePositions.GenerateNewPositions(type, team,OrientationPosition.BottomRight));
                orientationPositions.Add(OrientationPosition.BottomLeft,possiblePositionsBottomLeft = GeneratePositions.GenerateNewPositions(type, team,OrientationPosition.BottomLeft));
                break;
            case TypePiece.Knight:
                orientationPositions.Add(OrientationPosition.Knight,possiblePositionsKnight = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Knight));
                break;
            case TypePiece.Tower:
                orientationPositions.Add(OrientationPosition.Bottom, possiblePositionsBottom = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Bottom));
                orientationPositions.Add(OrientationPosition.Top, possiblePositionsTop = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Top));
                orientationPositions.Add(OrientationPosition.Left, possiblePositionsLeft = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Left));
                orientationPositions.Add(OrientationPosition.Right, possiblePositionsRight=GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Right));
                break;
            case TypePiece.King:
                orientationPositions.Add(OrientationPosition.Bottom, possiblePositionsBottom = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Bottom));
                orientationPositions.Add(OrientationPosition.Top, possiblePositionsTop = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Top));
                orientationPositions.Add(OrientationPosition.Left, possiblePositionsLeft = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Left));
                orientationPositions.Add(OrientationPosition.Right, possiblePositionsRight=GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Right));
                orientationPositions.Add(OrientationPosition.TopRight, possiblePositionsBottomTopRight = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.TopRight));
                orientationPositions.Add(OrientationPosition.TopLeft, possiblePositionsTopLeft = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.TopLeft));
                orientationPositions.Add(OrientationPosition.BottomRight, possiblePositionsBottomRight = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.BottomRight));
                orientationPositions.Add(OrientationPosition.BottomLeft, possiblePositionsBottomLeft = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.BottomLeft));
                break;
            case TypePiece.Queen:
                orientationPositions.Add(OrientationPosition.Bottom, possiblePositionsBottom = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Bottom));
                orientationPositions.Add(OrientationPosition.Top, possiblePositionsTop = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Top));
                orientationPositions.Add(OrientationPosition.Left, possiblePositionsLeft = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Left));
                orientationPositions.Add(OrientationPosition.Right, possiblePositionsRight=GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Right));
                orientationPositions.Add(OrientationPosition.TopRight, possiblePositionsBottomTopRight = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.TopRight));
                orientationPositions.Add(OrientationPosition.TopLeft, possiblePositionsTopLeft = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.TopLeft));
                orientationPositions.Add(OrientationPosition.BottomRight, possiblePositionsBottomRight = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.BottomRight));
                orientationPositions.Add(OrientationPosition.BottomLeft, possiblePositionsBottomLeft = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.BottomLeft));
                break;
            case TypePiece.Pawn:
                orientationPositions.Add(OrientationPosition.BottomFirstMove, possiblePositionsBottomFirstMove = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.BottomFirstMove));
                orientationPositions.Add(OrientationPosition.TopFirstMove, possiblePositionsTopFirstMove = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.TopFirstMove));
                orientationPositions.Add(OrientationPosition.Bottom, possiblePositionsBottom = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Bottom));
                orientationPositions.Add(OrientationPosition.Top, possiblePositionsTop = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.Top));
                orientationPositions.Add(OrientationPosition.PawnEat, possiblePositionsPawnEat = GeneratePositions.GenerateNewPositions(type, team, OrientationPosition.PawnEat));
                break;
            default:
                break;
        }

    }
    public bool ReturnCanBeEaten()
    {
        return canBeEaten;
    } 
    public TypePiece ReturnType()
    {
        return type;
    }
    public Team ReturnTeam()
    {
        return team;
    }
    public bool ReturnIsHisFirstMove()
    {

        return isHisFirstMove;
    }
    public Dictionary<OrientationPosition, List<Vector2Int>> ReturnPossiblePositions()
    {

        return orientationPositions;
    }
    public void ChangeFirstMove()
    {
        if (!control)
            control = true;
            isHisFirstMove = false;
    }
}
