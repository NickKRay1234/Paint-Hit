using UnityEngine;


/* BallHandler makes balls shoot in circles
 * Script created by @Mykola Kalchuk.
 */


public class BallHandler : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _dummyBall;
    [SerializeField] private GameObject[] _circles;

    public static float rotationSpeed = 100;
    private float _speed = 100;


    private void Start()
    {
        MakeANewCircle();
    }

    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Fire();
    }

    private void Fire()
    {
        GameObject clone = Instantiate<GameObject>(_ball, _dummyBall.transform.position, Quaternion.identity); // By using Generics we don't need to cast the result to a specific type;
        clone.GetComponent<MeshRenderer>().material.color = Color.green;
        clone.GetComponent<Rigidbody>().AddForce(Vector3.forward * _speed, ForceMode.Impulse); // Time does not affect on ForceMode.Impulse;
    }

    private void MakeANewCircle()
    {
        GameObject circle = Instantiate(_circles[Random.Range(0, 4)]);
        circle.transform.position = new Vector3(0, 20, 23);
        circle.name = "Circle";
    }




}
