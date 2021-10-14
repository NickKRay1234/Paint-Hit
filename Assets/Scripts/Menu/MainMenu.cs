using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image BG;
    [SerializeField] private Sprite[] spr;


    void Start()
    {
        BG.sprite = spr[Random.Range(0,4)];
    }
}
