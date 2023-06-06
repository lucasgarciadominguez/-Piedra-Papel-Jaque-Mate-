using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Team TeamTurn;
    [SerializeField]
    public bool isPlaying;
    [SerializeField]
    UIManager iManager;
    [SerializeField]
    RandomMode randomMode;
    [SerializeField]
    Player player1;
    [SerializeField]
    Player player2;
    [SerializeField]
    Board board;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchSkins());

        TeamTurn = Team.One;
        isPlaying= true;
    }
    IEnumerator SwitchSkins()
    {
        yield return new WaitForSeconds(0.07f);
        FindPlayers();
        StopCoroutine(SwitchSkins()); // stop it.


    }
    void FindPlayers()
    {
        Player[] goList = new Player[2];
        goList = GameObject.FindObjectsOfType<Player>();
        string namePlayer1="";
        string namePlayer2="";
        foreach (Player player in goList)
        {
            if (player.team==Team.One)
            {
                namePlayer1= player.name;
                player1= player;
            }
            else
            {
                namePlayer2 = player.name;
                player2= player;


            }
        }
        iManager.SetNamesPlayers(namePlayer1,namePlayer2);
        FillSkins();
        foreach (var item in goList)
        {
            item.Destroy();
        }

    }
    void FillSkins()
    {
        foreach (var item in board.pieces)
        {
            if (item.GetComponent<Piece>().ReturnTeam()==Team.One)
            {
                Debug.Log(player1.skin);
                iManager.ChangeSprites(item.GetComponent<SpriteRenderer>(), item.GetComponent<Piece>().ReturnType(),player1.skin,Team.One);

            }
            else
            {
                Debug.Log(player2.skin);

                iManager.ChangeSprites(item.GetComponent<SpriteRenderer>(), item.GetComponent<Piece>().ReturnType(), player2.skin,Team.Two);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void MovementFinished()
    {
        if (TeamTurn == Team.One)
            TeamTurn = Team.Two;
        else
            TeamTurn = Team.One;

    }
    public void ShowsRandomMode()
    {
        randomMode.EnableRandomMode();
    }
    public void EndGame()
    {
        isPlaying = false;
        iManager.EndGameUI();

    }
}
