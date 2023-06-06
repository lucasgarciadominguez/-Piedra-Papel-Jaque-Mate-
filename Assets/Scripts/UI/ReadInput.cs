using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    private string name;
    public TMP_InputField input;
    public TMP_Dropdown dropdownSkins;
    [SerializeField]
    Skins skinSelected=Skins.Chocolate;
    // Start is called before the first frame update
    void Start()
    {
        //assigned on value changed event
        dropdownSkins.onValueChanged.AddListener(delegate
        {
            ChangeSkin(dropdownSkins);
        });
    }

    public void ChangeSkin(TMP_Dropdown sender)
    {
        if (sender.value==0)
        {
            skinSelected = Skins.Chocolate;
        }
        else if (sender.value==1)
        {
            skinSelected = Skins.Cubic;
        }
        else if (sender.value==2)
        {
            skinSelected = Skins.Simple;

        }
    }
    public Skins ReadSkinInput()
    {
        return skinSelected;
    }
    public string ReadStringInput()
    {
        name=input.text;
        return name;

        //int num = listaJugadores.listPlayers.FindLast(j => j).levelsWon;
        //string nombre = listaJugadores.listPlayers.FindLast(j => j).name;
        //Debug.Log("El numero de niveles ganados de: " + nombre + " es " + num);
        //Debug.Log(p1.name);

    }
}

