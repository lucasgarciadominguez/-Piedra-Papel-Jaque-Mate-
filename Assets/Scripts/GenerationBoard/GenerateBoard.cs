using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    [SerializeField]
    Sprite spriteWhite;
    [SerializeField]
    Sprite spriteBlack;
    [SerializeField]
    GameObject cellPrefab;
    private void Awake()
    {
        cellPrefab.transform.localScale= new Vector2(Metrics.cellSize,Metrics.cellSize);
    }
    public void CreateVisualBoard(Cell[,] cells,GameObject board)
    {
        float amountX = -1.77f;
        float amountY = -1.71f;

        bool color =false;
        int counter = 0;
        for (int yY = 0; yY < 8; yY++)
        {
            for (int xX = 0; xX < 8; xX++)
            {
                if (counter % 2 == 0)  //si el valor de contador es par
                {
                    GameObject cellGO = Instantiate(cellPrefab, cellPrefab.GetComponent<CameraAnchor>().anchorOffset=new Vector2(amountX + xX*Metrics.cellSize,amountY+ yY * Metrics.cellSize), Quaternion.identity, board.transform);
                    Cell cellScript = cellGO.GetComponent<Cell>();
                    cellScript.spriteRenderer = cellGO.GetComponent<SpriteRenderer>();
                    cellScript.mainSprite = spriteBlack;
                    cellScript.x = xX;
                    cellScript.y = yY;
                    cellScript.spriteRenderer.sprite = spriteBlack;
                    CreateLogicBoard(cells, xX, yY, cellScript);


                    counter++;

                }
                else
                {
                    //si es impar
                    GameObject cellGO = Instantiate(cellPrefab, cellPrefab.GetComponent<CameraAnchor>().anchorOffset = new Vector2(amountX + xX * Metrics.cellSize, amountY + yY * Metrics.cellSize), Quaternion.identity, board.transform);
                    Cell cellScript = cellGO.GetComponent<Cell>();
                    cellScript.spriteRenderer = cellGO.GetComponent<SpriteRenderer>();
                    cellScript.mainSprite = spriteWhite;
                    cellScript.x= xX;
                    cellScript.y= yY;
                    cellScript.spriteRenderer.sprite = spriteWhite;
                    CreateLogicBoard(cells, xX, yY, cellScript);


                    counter++;

                }
                if (xX == 8 - 1)   // si el valor de la x llega al final -1 se resetea el comienzo del color para hacerlo negro o blanco
                {

                    if (color == true)
                    {
                        counter = 0;

                        color = false;
                    }
                    else
                    {
                        counter = 1;
                        color = true;
                    }





                }

            }
        }
    }
    public void CreateLogicBoard(Cell[,] cells,int x,int y,Cell cell)
    {
        cells[x,y]=cell;
    }
}
