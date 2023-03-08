using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



public class AudioManager : MonoBehaviour
{

    public AudioSource source;
    public AudioClip QuesApple, QuesBanana, QuesBlueberry, QuesCherry, QuesJackfruit, QuesKiwi, QuesMango, QuesOrange, QuesPeach, QuesPineapple, QuesStrawberry, QuesWatermelon;



    //create an array of fruits so that the questions can be randomly generated
    private static string [] fruits = {"Apple","Banana", "Blueberry", "Cherry", "Jackfruit", "Kiwi", "Mango", "Orange", "Peach", "Pineapple", "Strawberry", "Watermelon"};

    //random placeholder for the generation of the questions
    private static System.Random random = new System.Random();

    private static int picker = random.Next(11);
    private static string Question = fruits[picker];

    private static string newClip = string.Concat("Ques", Question);



    // Start is called before the first frame update
    void Start()
    {
        
        switch(Question){

            case "Apple":
                source.clip = QuesApple;
                source.Play();
                break;
             case "Banana":
                source.clip = QuesBanana;
                source.Play();
                break;
            case "Blueberry":
                source.clip = QuesBlueberry;
                source.Play();
                break;
            case "Cherry":
                source.clip = QuesCherry;
                source.Play();
                break;
            case "Jackfruit":
                source.clip = QuesJackfruit;
                source.Play();
                break;
            case "Kiwi":
                source.clip = QuesKiwi;
                source.Play();
                break;
            case "Mango":
                source.clip = QuesMango;
                source.Play();
                break;
            case "Orange":
                source.clip = QuesOrange;
                source.Play();
                break;
            case "Peach":
                source.clip = QuesPeach;
                source.Play();
                break;
            case "Pineapple":
                source.clip = QuesPineapple;
                source.Play();
                break;
            case "Strawberry":
                source.clip = QuesStrawberry;
                source.Play();
                break;
            case "Watermelon":
                source.clip = QuesWatermelon;
                source.Play();
                break;
        }
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
