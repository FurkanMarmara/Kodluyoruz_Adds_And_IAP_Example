using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScore
{
    
    public static void HighScoreControl(float score)
    {
        if (PlayerPrefs.GetFloat("Score")>0)
        {
            if (PlayerPrefs.GetFloat("Score") > score) //time olduğu için küçükse yaptık.
            {
                PlayerPrefs.SetFloat("Score", score);
                Debug.Log("HighScore Yapıldı");
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Score", score);
        }
       
    }

}
