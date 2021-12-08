using UnityEngine.UI;
//using LootLocker.Requests;
using UnityEngine;

public class SendScores : MonoBehaviour
{
    public InputField id, pScore;
    public int ID;

    // Start is called before the first frame update
    void Start()
    {
        /*LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });*/
    }

    public void SubmitScore()
    {
       
    }
}
