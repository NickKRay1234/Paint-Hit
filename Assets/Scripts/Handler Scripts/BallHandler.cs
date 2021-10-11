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

    //new
    private int _ballsCount;
    private int _circleNumber;


    private void Start()
    {
        GameObject circle = Instantiate(_circles[Random.Range(0, 4)]);
        circle.transform.position = new Vector3(0, 20, 23);
        circle.name = "Circle" + _circleNumber;

        MakeANewCircle();
        //new 
        _ballsCount = 4;
    }

    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Fire();
    }

    private void Fire()
    {
        //new
        if(_ballsCount <= 1)
        {
            base.Invoke("MakeANewCircle", 0.4f);
            // Disable Button for some time;
        }

        _ballsCount--;

        GameObject clone = Instantiate<GameObject>(_ball, _dummyBall.transform.position, Quaternion.identity); // By using Generics we don't need to cast the result to a specific type;
        clone.GetComponent<MeshRenderer>().material.color = Color.green;
        clone.GetComponent<Rigidbody>().AddForce(Vector3.forward * _speed, ForceMode.Impulse); // Time does not affect on ForceMode.Impulse;
    }

    private void MakeANewCircle()
    {
        //new
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        GameObject gameObject = GameObject.Find("Circle" + _circleNumber);
        for(int i = 0; i < 24; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        gameObject.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = Color.green;

        if(gameObject.GetComponent<iTween>())
            gameObject.GetComponent<iTween>().enabled = false;

        foreach(GameObject target in array)
            iTween.MoveBy(target, iTween.Hash(new object[] { "y", -2.98f, "easeType", iTween.EaseType.spring, "time", 0.5 }));
        _circleNumber++;


        GameObject circle = Instantiate(_circles[Random.Range(0, 4)]);
        circle.transform.position = new Vector3(0, 20, 23);
        circle.name = "Circle" + _circleNumber;
    }




}
