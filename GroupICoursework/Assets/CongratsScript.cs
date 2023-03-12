using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CongratsScript : MonoBehaviour
{
    //text for the congrats message and next steps
    public TextMeshProUGUI CongratsMSG = new TextMeshProUGUI();
    public TextMeshProUGUI ContinueMSG = new TextMeshProUGUI();

    //counter for the correct answers
    int counter;

    // Start is called before the first frame update
    void Start()
    {

        //Message to display
        CongratsMSG.text = "Well Done!! You Have Completed The Quiz";
        ContinueMSG.text = "Tap the screen to continue";

    }




    // Update is called once per frame
    void Update()
    {
        //condition when the mouse button in clicked
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Quiz");
        }

    }
}

