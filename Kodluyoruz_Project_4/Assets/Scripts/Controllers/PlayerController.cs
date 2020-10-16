using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CheckPointController checkPointController;

    [SerializeField]
    private float _speed = 0.2f;
    [SerializeField]
    private float _rotationSpeed = 1f;
    [SerializeField]
    private float _jumpForce = 100f;
    [SerializeField]
    private bool _isGrounded = true;


    


    private float _translation = 0;
    private float _rotation = 0;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rotation = Input.GetAxis("Horizontal") * _rotationSpeed;
        _translation = Input.GetAxis("Vertical") * _speed;

        if(!_isGrounded)
        {
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y - (Time.deltaTime*40),_rigidbody.velocity.z);
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(0,_jumpForce, 0);
            _isGrounded = false;
        }

        if (gameObject.transform.position.y<-10f)
        {
            Debug.Log("Öldün Yeniden Canlandırılıyorsun");
            Respawn();
        }

    }

    public void Respawn()
    {
        gameObject.transform.position = checkPointController.GetLastCheckPointPosition();
    }

    

    private void FixedUpdate()
    {
        gameObject.transform.Translate(0, 0, _translation);
        gameObject.transform.Rotate(0, _rotation, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }




}
