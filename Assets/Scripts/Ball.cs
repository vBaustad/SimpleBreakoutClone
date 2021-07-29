using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    float _speed = 20f; 
    Rigidbody _rigidbody;
    Vector3 _velocity;
    Renderer _renderer;
    
    GameManager gm;


    float timeRemaining = 0;
    bool timerIsRunning = false;


    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>(); 
        
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        Invoke("Launch", 0.5f);
        
    }

    void Launch(){

        _rigidbody.velocity = Vector3.up * _speed;

    }

    public void Speed(float speed){
        
        _speed = speed;        
        timeRemaining += 10;
        timerIsRunning = true;
        
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerIsRunning){
            
            if (timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
                

                gm.DisplayTime(timeRemaining);
                }
            else {
                    Debug.Log("Time has run out");
                    timeRemaining = 0;
                    timerIsRunning = false;
                }
        }else {
            _speed = 20f;
        }

        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        _velocity = _rigidbody.velocity;

        if (!_renderer.isVisible){
            timeRemaining = 0;
            gm.DisplayTime(timeRemaining);
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }  
    }

    void OnCollisionEnter(Collision collision){
        _rigidbody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);
    }
}
