using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField]
    private List<CheckPointItem> _checkPointItems = new List<CheckPointItem>();

    public ScoreController scoreController;

    [SerializeField]
    private int _lastCheckPoint = 1;

    private void Start()
    {
        for (int i = 0; i < _checkPointItems.Count; i++)
        {
            if (i == 0)
            {
                _checkPointItems[i]._myCheckPointModel._isMyTurn = true;
            }

            _checkPointItems[i]._myCheckPointModel._id = i+1;
        }
    }

    public void SetNextCheckPoint(int id)
    {
        if (id-1 < _checkPointItems.Count)
        {
            _checkPointItems[id - 1]._myCheckPointModel._isMyTurn = true;
            _lastCheckPoint = id-1;
        }
        else
        {
            EndGame();
            _lastCheckPoint = id - 1;
            
        }
        
    }

    public Vector3 GetLastCheckPointPosition()
    {
        Vector3 pos = _checkPointItems[_lastCheckPoint-1].transform.position;
        pos[1] = pos[1] + 0.5f;
        return pos;
    }

    public void EndGame()
    {
        Debug.Log("Tebrikler Kazandınız !");
        HighScore.HighScoreControl(scoreController.GetScore());
        SceneController.instance.ChangeScene(Scenes.PreGameScene.ToString());
        AdsManager.instance.ShowAds(AdsPlacementTypes.rewardedVideo);
    }

}
