using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTurns : MonoBehaviour
{
    [SerializeField]
    GameObject TurnPiece1;
    [SerializeField]
    GameObject TurnPiece2;
    public void ChangeTurns(bool changeTurns)
    {
        //if (!changeTurns)
        //{
        //    TurnPiece1.SetActive(true);
        //    TurnPiece2.SetActive(false);

        //}
        //else
        //{
        //    TurnPiece1.SetActive(false);
        //    TurnPiece2.SetActive(true);
        //}
    }
}
