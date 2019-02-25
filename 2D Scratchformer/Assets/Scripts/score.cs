using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public static int scoreVal = 0;
    private Text scoreString;
    // Start is called before the first frame update
    void Start()
    {
        scoreString = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreString.text = "Score: " + scoreVal;
     }
}
