using UnityEngine;
using UnityEngine.UI;


/* BallHandler makes balls shoot in circles
 * Script created by @Mykola Kalchuk.
 */


public class BallHandler : MonoBehaviour
{

    public static float rotationSpeed = 100;
    public static float rotationTime = 3;
    public static Color oneColor;
    public static int currentCircleNo;
    
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _dummyBall;
    [SerializeField] private GameObject[] _circles;
    [SerializeField] private GameObject[] _array;

    private float _speed = 100;
    private int _ballsCount;
    private int _circleNumber;
    private int _heartNumber;

    private bool _gameFail;
    [SerializeField] private Image[] balls;
    [SerializeField] private GameObject[] Hearts;

    public Color[] ChangingColors;
    public SpriteRenderer spr;
    public Material splashMat;


    private void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        ChangingColors = ColorScript.colorArray;
        oneColor = ChangingColors[0];
        spr.color = oneColor;
        splashMat.color = oneColor;
        CircleCreating();

        _ballsCount = LevelHandlerScript.ballsCount;
        LevelHandlerScript.currentColor = oneColor;

        _heartNumber = PlayerPrefs.GetInt("hearts", 1);
        if (_heartNumber == 0)
            PlayerPrefs.SetInt("hearts", 1);
        _heartNumber = PlayerPrefs.GetInt("hearts");

        for (int i = 0; i < _heartNumber; i++)
        {
            Hearts[i].SetActive(false);
        }

        MakeHurdles();

    }

    public void HeartsLow()
    {
        _heartNumber--;
        PlayerPrefs.SetInt("hearts", _heartNumber);
        Hearts[_heartNumber].SetActive(false);
    }



    public void Fire()
    {
        if(_ballsCount <= 1)
        {
            base.Invoke("ColorAndAnimatiorSwitcher", 0.4f);
            // Disable Button for some time;
        }

        _ballsCount--;

        if (_ballsCount >= 0)
            balls[ballsCount].enabled = false;

        GameObject clone = Instantiate<GameObject>(_ball, _dummyBall.transform.position, Quaternion.identity); // By using Generics we don't need to cast the result to a specific type;
        clone.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;
        clone.GetComponent<Rigidbody>().AddForce(Vector3.forward * _speed, ForceMode.Impulse); // Time does not affect on ForceMode.Impulse;
    }

    private void ColorAndAnimatiorSwitcher()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        GameObject completedCircle = GameObject.Find("Circle" + _circleNumber);

        for(int i = 0; i < 24; i++) // part of circle which activated will be off. 
            completedCircle.transform.GetChild(i).gameObject.SetActive(false); 

        completedCircle.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor; // Circle will be green after hitting.

        if(completedCircle.GetComponent<iTween>())
            completedCircle.GetComponent<iTween>().enabled = false;

        foreach(GameObject target in array) // Animation
            iTween.MoveBy(target, iTween.Hash(new object[] { "y", -2.98f, "easeType", iTween.EaseType.spring, "time", 0.5 }));
        
        CircleCreating();
        
        _ballsCount = LevelHandlerScript.ballsCount;
        LevelHandlerScript.currentColor = oneColor;

        oneColor = ChangingColors[_circleNumber];
        spr.color = oneColor;
        splashMat.color = oneColor;
    }

    private void CircleCreating()
    {
        _circleNumber++;
        currentCircleNo = _circleNumber;
        GameObject circle = Instantiate(_circles[Random.Range(0, 4)]);
        circle.transform.position = new Vector3(0, 20, 23);
        circle.name = "Circle" + _circleNumber;
    }

    private void DeleteAllCircles()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        foreach (GameObject gameObject in array)
            Destroy(gameObject.gameObject);
        _gameFail = false;
        FindObjectOfType<LevelsHandlerScript>().UpgradeLevel();
        ResetGame();
    }

    private void ChangeBallsCount()
    {
        _ballsCount = LevelsHandlerScript.ballsCount;
        _dummyBall.GetComponent<MeshRenderer>().material.color = oneColor;

        for (int i = 0; i < balls.Length; i++)
            balls[i].enabled = false;

        for(int j = 0; j < _ballsCount; j++)
        {
            balls[j].enabled = true;
            balls[j].color = oneColor;
        }

    }

    void MakeHurdles()
    {
        if (_circleNumber == 1)
            FindObjectOfType<LevelHandlerScript>().MakeHurdles1();
        if (_circleNumber == 2)
            FindObjectOfType<LevelHandlerScript>().MakeHurdles2();
        if (_circleNumber == 3)
            FindObjectOfType<LevelHandlerScript>().MakeHurdles3();
        if (_circleNumber == 4)
            FindObjectOfType<LevelHandlerScript>().MakeHurdles4();
        if (_circleNumber == 5)
            FindObjectOfType<LevelHandlerScript>().MakeHurdles5();
    }

    


}
