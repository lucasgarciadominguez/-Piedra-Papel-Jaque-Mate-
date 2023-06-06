using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneratePositions 
{
    public static List<Vector2Int> GenerateNewPositions(TypePiece typePiece,Team team,OrientationPosition position)
    {
        List<Vector2Int> positions = new List<Vector2Int>();
        switch (typePiece)
        {
            case TypePiece.None:
                return positions;
            case TypePiece.Bishop:

                int y = 1;
                if (position==OrientationPosition.TopRight)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {

                        positions.Add(new Vector2Int(x, y));
                        y++;

                    }
                    y = 1;
                }
                if (position == OrientationPosition.BottomLeft)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {

                        positions.Add(new Vector2Int(-x, -y));

                        y++;

                    }
                    y = 1;
                }
                if (position == OrientationPosition.TopLeft)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {


                        positions.Add(new Vector2Int(-x, y));
                        y++;

                    }
                    y = 1;
                }
                if (position == OrientationPosition.BottomRight)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {


                        positions.Add(new Vector2Int(x, -y));
                        y++;

                    }
                }
                return positions;
            case TypePiece.Knight:
                positions.Add(new Vector2Int(1,2));
                positions.Add(new Vector2Int(2,1));
                positions.Add(new Vector2Int(-1,-2));
                positions.Add(new Vector2Int(-2,-1));
                positions.Add(new Vector2Int(-1,2));
                positions.Add(new Vector2Int(-2,1));
                positions.Add(new Vector2Int(1,-2));
                positions.Add(new Vector2Int(2,-1));

                return positions;
            case TypePiece.Tower:
                if (position == OrientationPosition.Right)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {
                        positions.Add(new Vector2Int(x, 0));
                    }
                }
                if (position == OrientationPosition.Left)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {
                        positions.Add(new Vector2Int(-x, 0));
                    }
                }
                if (position == OrientationPosition.Top)
                {
                    for (y = 1; y < Metrics.size; y++)
                    {
                        positions.Add(new Vector2Int(0, y));
                    }
                }
                if (position == OrientationPosition.Bottom)
                {
                    for (y = 1; y < Metrics.size; y++)
                    {
                        positions.Add(new Vector2Int(0, -y));
                    }
                }
                return positions;
            case TypePiece.King:
                if (position == OrientationPosition.Right)
                {
                    positions.Add(new Vector2Int(1, 0));

                }
                if (position == OrientationPosition.Left)
                {
                    positions.Add(new Vector2Int(-1, 0));

                }
                if (position == OrientationPosition.Top)
                {
                    positions.Add(new Vector2Int(0, 1));

                }
                if (position == OrientationPosition.Bottom)
                {
                    positions.Add(new Vector2Int(0, -1));

                }
                if (position == OrientationPosition.TopRight)
                {
                    positions.Add(new Vector2Int(1, 1));

                }
                if (position == OrientationPosition.BottomLeft)
                {
                    positions.Add(new Vector2Int(-1, -1));

                }
                if (position == OrientationPosition.TopLeft)
                {
                    positions.Add(new Vector2Int(-1, 1));

                }
                if (position == OrientationPosition.BottomRight)
                {
                    positions.Add(new Vector2Int(1, -1));


                }
                return positions;
            case TypePiece.Queen:
                if (position == OrientationPosition.Right)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {
                        positions.Add(new Vector2Int(x, 0));
                    }
                }
                if (position == OrientationPosition.Left)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {
                        positions.Add(new Vector2Int(-x, 0));
                    }
                }
                if (position == OrientationPosition.Top)
                {
                    for (y = 1; y < Metrics.size; y++)
                    {
                        positions.Add(new Vector2Int(0, y));
                    }
                }
                if (position == OrientationPosition.Bottom)
                {
                    for (y = 1; y < Metrics.size; y++)
                    {
                        positions.Add(new Vector2Int(0, -y));
                    }
                }
                y = 1;
                if (position == OrientationPosition.TopRight)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {

                        positions.Add(new Vector2Int(x, y));
                        y++;

                    }
                    y = 1;
                }
                if (position == OrientationPosition.BottomLeft)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {

                        positions.Add(new Vector2Int(-x, -y));

                        y++;

                    }
                    y = 1;
                }
                if (position == OrientationPosition.TopLeft)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {


                        positions.Add(new Vector2Int(-x, y));
                        y++;

                    }
                    y = 1;
                }
                if (position == OrientationPosition.BottomRight)
                {
                    for (int x = 1; x < Metrics.size; x++)
                    {


                        positions.Add(new Vector2Int(x, -y));
                        y++;

                    }
                }
                return positions;
            case TypePiece.Pawn:
                if (team==Team.One&&position==OrientationPosition.TopFirstMove)
                {
                    positions.Add(new Vector2Int(0, 1));
                    positions.Add(new Vector2Int(0, 2));

                }
                else if (team == Team.Two && position == OrientationPosition.BottomFirstMove)
                {
                    positions.Add(new Vector2Int(0, -1));
                    positions.Add(new Vector2Int(0, -2));
                }
                if (team == Team.One && position == OrientationPosition.Top)
                {
                    positions.Add(new Vector2Int(0, 1));
                }
                else if (team == Team.Two && position == OrientationPosition.Bottom)
                {
                    positions.Add(new Vector2Int(0, -1));
                }
                else if (team == Team.One && position == OrientationPosition.PawnEat)
                {
                    positions.Add(new Vector2Int(1, 1));
                    positions.Add(new Vector2Int(-1, 1));
                }
                else if (team == Team.Two && position == OrientationPosition.PawnEat)
                {
                    positions.Add(new Vector2Int(-1, -1));
                    positions.Add(new Vector2Int(1, -1));
                }
                return positions;
            default:
                return positions;
        }
    }
}
