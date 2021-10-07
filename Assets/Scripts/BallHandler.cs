using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public static Color oneColor = Color.green;
    public GameObject ball;

    private float _speed = 100;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            HitBall();
        }
    }

    public void HitBall()
    {
        GameObject clone = Instantiate<GameObject>(ball, new Vector3(0, 0, -8), Quaternion.identity); // By using Generics we don't need to cast the result to a specific type;
        clone.GetComponent<MeshRenderer>().material.color = oneColor;
        clone.GetComponent<Rigidbody>().AddForce(Vector3.forward * _speed, ForceMode.Impulse); // Time does not affect on ForceMode.Impulse;
    }




}
