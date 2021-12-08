using System;
using System.Collections;
using System.Collections.Generic;
using LootLocker.Requests;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLBoard : MonoBehaviour
{
    public InputField MemberID, pScore;
    public int id;
    public Text[] Entries;

    /*public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(id, 3, (response) =>
        {
            if (response.success)
            {
                LootLockerMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    Entries[i].text = (scores[i].rank + ".     " + scores[i].score);
                }

                if (scores.Length < 3)
                {
                    for (int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + ".  ---";
                    }
                }
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }*/

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
