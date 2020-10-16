using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointItem : MonoBehaviour
{

    public CheckPointController checkPointController;
    [SerializeField]
    public CheckPointModel _myCheckPointModel = new CheckPointModel();


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_myCheckPointModel._isMyTurn)
            {
                _myCheckPointModel._isCompleted = true;
                Debug.Log(_myCheckPointModel._id + " checkPoint Geçildi");
                _myCheckPointModel._isMyTurn = false;
                checkPointController.SetNextCheckPoint(_myCheckPointModel._id+1);

            }
        }
    }

}
[System.Serializable]
public class CheckPointModel{

    public bool _isCompleted;
    public bool _isMyTurn;
    public int _id;

}
