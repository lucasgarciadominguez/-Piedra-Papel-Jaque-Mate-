using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int x { private get;  set; }
    public int y { private get; set; }
    public Sprite mainSprite;
    public SpriteRenderer spriteRenderer;
    public GameObject currentPiece;
    public int ReturnX()
    {
        return x;
    }
    public int ReturnY()
    {
        return y;
    }
    public void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
    public void SetMainSprite()
    {
        spriteRenderer.sprite = mainSprite;
    }
}
