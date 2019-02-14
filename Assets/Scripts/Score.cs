//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Transform player;
    public Text text;
    int init = 0;
    void Start()
    {
        init = (int)player.position.z;
    }
    void Update()
    {
        text.text = "Score: " + ((int)player.position.z - init).ToString();
    }
}
