using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField]
    public GameObject imageFade;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadOptionsScene()
    {
        imageFade.SetActive(true);
       StartCoroutine( TransicionesNivel(1));
    }
    public void LoadGameScene()
    {
        imageFade.SetActive(true);
      StartCoroutine(  TransicionesNivel(3));
    }
    public void LoadInputScene()
    {
        imageFade.SetActive(true);
        StartCoroutine(TransicionesNivel(2));
    }
    public void LoadMenuScene()
    {
        imageFade.SetActive(true);
        StartCoroutine(TransicionesNivel(1));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator TransicionesNivel(int nivel)
    {
        if (nivel == 1)
        {

            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene(0);

        }
        if (nivel == 2)
        {

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(1);

        }
        if (nivel == 3)
        {

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(2);

        }
    }
}
