using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    Camera cam;
    Cell selectedTile;

    [SerializeField]
    LayerMask layerTile;
    [SerializeField]
    ShowMovements movements;
    [SerializeField]
    MovePiece movePiece;
    [SerializeField]
    GameManager gameManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameManager.isPlaying)
            {
                Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100, layerTile);

                if (hit.collider != null)
                {

                    if (selectedTile != null)
                    {
                        Cell newSelectedTile = hit.collider.gameObject.GetComponent<Cell>();

                        if (selectedTile.currentPiece != null && movements.possibleCells.Contains(newSelectedTile))
                        {
                            movePiece.MoveToNewPosition(selectedTile, selectedTile.currentPiece, newSelectedTile, hit.collider.gameObject);
                            movements.ClearPosibleCells();
                            selectedTile.SetMainSprite();
                            gameManager.MovementFinished();

                        }
                        else
                        {
                            selectedTile.SetMainSprite();
                            selectedTile = newSelectedTile;
                            movements.ShowMovementsForPiece(selectedTile);
                        }


                    }
                    else
                    {
                        Cell newSelectedTile = hit.collider.gameObject.GetComponent<Cell>();

                        selectedTile = newSelectedTile;
                        movements.ShowMovementsForPiece(selectedTile);



                    }

                }

            
            }
        }

    }
}
