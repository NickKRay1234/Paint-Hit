using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public static float rotationSpeed = 100;

    public static Color oneColor = Color.green;
    public GameObject ball;

    private float _speed = 100;


    void Start()
    {
        MakeANewCircle();
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

    void MakeANewCircle()
    {
        GameObject gameObject2 = Instantiate(Resources.Load("Round" + Random.Range(1, 4))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle";
    }




}
