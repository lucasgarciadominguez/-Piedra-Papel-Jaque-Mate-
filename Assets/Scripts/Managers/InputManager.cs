using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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
    [SerializeField]
    UIManager uiManager;
    Cell newSelectedTile;
    RaycastHit2D raycastHit2D;
    [SerializeField]
    bool canOperate=false;
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
                            SavesThePosition(newSelectedTile, hit);
                            uiManager.HighLightsButtons();
                        }
                        else
                        {
                            selectedTile.SetMainSprite();
                            selectedTile = newSelectedTile;
                            movements.ShowMovementsForPiece(selectedTile);
                            canOperate = false;

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
    public void SavesThePosition(Cell newSelectedTile, RaycastHit2D hit)
    {
        this.newSelectedTile = newSelectedTile;
        raycastHit2D = hit;
        canOperate=true;
    }
    public void ExecuteMovement()
    {
        if (canOperate)
        {
            movePiece.MoveToNewPosition(selectedTile, selectedTile.currentPiece, newSelectedTile, raycastHit2D.collider.gameObject);
            movements.ClearPosibleCells();
            selectedTile.SetMainSprite();
            gameManager.MovementFinished();
        }

        canOperate = false;

    }
}
