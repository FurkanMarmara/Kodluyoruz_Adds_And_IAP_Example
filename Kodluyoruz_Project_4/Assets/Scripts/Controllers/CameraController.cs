using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private Vector3 myPos;

 
    void Update()
    {

        //transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 10, _player.transform.position.z - 12);
        //transform.position = _playerTransform.position + myPos;
        transform.position = _playerTransform.TransformPoint(myPos);

        transform.LookAt(_playerTransform);



    }


}
