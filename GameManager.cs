using System;
using System.Collections;
using System.Collections.Generic;
using LootLocker.Requests;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public static int Leaderboard1 = 0;
    public static int Leaderboard2 = 0;
    public GUISkin layout;
    GameObject theBall;

    public InputField MemberID, pScore;
    public int id;
    public Text[] Entries;
    
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");

        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public static void Score (string WallID){
        if(WallID == "RightWall"){
            PlayerScore1++;
        }
        else if(WallID == "LeftWall"){
            PlayerScore2++;
        }
    }

    public void SubmitScore(string mID, int score)
    {
        LootLockerSDKManager.SubmitScore(mID, score, id, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }



    public static void LoadMainMenu(){
        Application.LoadLevel("MainMenu");
    }

    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 290 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 260 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 150, 35, 120, 53), "RESTART")){
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
        if (GUI.Button(new Rect(Screen.width / 2 + 30, 35, 120, 53), "EXIT TO MENU")){
            LoadMainMenu();    
            }
        if (PlayerScore1 == 5){
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            Leaderboard1++;
            SubmitScore("Player1", Leaderboard1);
            
        }
        else if (PlayerScore2 == 5){
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            Leaderboard2++;
            SubmitScore("Player2", Leaderboard2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
