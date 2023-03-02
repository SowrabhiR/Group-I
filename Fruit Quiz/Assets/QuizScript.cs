using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class QuizScript : MonoBehaviour
{

    //Initialising the fruits
    private string[] fruitsNames = {"Apple", "Banana", "Blueberry", "Cherry", "Jackfruit",
        "Kiwi", "Mango", "Orange", "Peach", "Pineapple", "Strawberry", "Watermelon"};

    private string[] fruitImages = {"apple", "Banana", "Blueberry", "Cherry", "Jack fruit",
        "Kiwi", "Mango", "Orange", "Peach", "Pineapple", "Strawberry", "Watermelon"};

    //Since we have 5 questions per category, rightAnswer stores the randomly chosen right answer in an array of size 5
    private int[] rightAnswer = new int[5];

    public TextMeshProUGUI fruitText = new TextMeshProUGUI();

    public string[] options = new string[4];

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    private int rightAnswerPosition;

    private int limit = 5;
    private int score = 0;

    // public AudioSource source;
    //public AudioClip[] fruitAudios = new AudioClip[12];

    //Random object is created to randomly generate the questions and options.
    System.Random ran = new System.Random();

    
    
    /* Description : 
     chooseCorrectAnswer() method dynamically chooses one right answer, based on which the question will be asked.
    */
    public int chooseCorrectAnswer()
    {
        int chosenFruit = ran.Next(11);
        for (int i =0; i< rightAnswer.Length; i++)
        {
            Debug.Log("Logging rightAnswer Length inside chooseCorrectAnswer" + rightAnswer.Length);
            if (chosenFruit == rightAnswer[i])
            {
                chooseCorrectAnswer();
            }
        }
        //rightAnswerPosition = 0;

        return chosenFruit;   
    }

    /* Description : 
    WrongOptions method chooses the other three wrong answers to be displayed dynamically.
   */
    public void WrongOptions(int rightAnswer)
    {
        string[] WrongAnswer = new string[4];
        WrongAnswer[0] = fruitImages[rightAnswer];
       /* Sprite sprite_1 = Resources.Load<Sprite>("Assets/Fruits/Images/" + fruitImages[rightAnswer]); // Load the image from the path*/
        /*buttons[0].image.sprite = sprite_1;*/
        int wrongAnswerCounter = 1;
        Sprite sprite;
        while (wrongAnswerCounter != 4)
        {
            int randomOption = ran.Next(1,4);
            if (isUnique(randomOption, WrongAnswer))
            { 
                WrongAnswer[wrongAnswerCounter] = fruitImages[randomOption];

                sprite = Resources.Load<Sprite>(fruitImages[randomOption]);  // Load the image from the path

                // buttons[wrongAnswerCounter].image.sprite = sprite;// Assign the image to the button
                wrongAnswerCounter++;
            }
            
        }
        Debug.Log("WrongAnswer 0 " + WrongAnswer[0]);
        Debug.Log("WrongAnswer 0 " + WrongAnswer[1]);
        Debug.Log("WrongAnswer 0 " + WrongAnswer[2]);
        Debug.Log("WrongAnswer 0 " + WrongAnswer[3]);


        Shuffle(WrongAnswer);

    }
    /* Description : 
    isUnique(int newOption, int[] WrongOptions) method checks whether all the options of the question are unique.
   */
    bool isUnique(int newOption, string[] WrongOptions)
    {
        for(int i = 0; i< WrongOptions.Length;i++)
        {
            if (fruitImages[newOption] == WrongOptions[i])
            {
                return false;
            }
        }
        return true;
    }

    /* Description : 
    Shuffle(int[] WrongOptions) method shuffles the selected four options.
   */
    void Shuffle(string[] WrongOptions)
    {
        rightAnswerPosition = ran.Next(3);
        string temp = WrongOptions[rightAnswerPosition];
        WrongOptions[rightAnswerPosition] = WrongOptions[0];
        WrongOptions[0] = temp;
        options = WrongOptions;


        Sprite image1 = Resources.Load<Sprite>("Images/"+ options[0]);
        Sprite image2 = Resources.Load<Sprite>("Images/"+ options[1]);
        Sprite image3 = Resources.Load<Sprite>("Images/" + options[2]);
        Sprite image4 = Resources.Load<Sprite>("Images/" + options[3]);

        // set the images as the source for each button
        button1.image.sprite = image1;
        button2.image.sprite = image2;
        button3.image.sprite = image3;
        button4.image.sprite = image4;
    }
    void OnButton1Click()
    {
        if(rightAnswerPosition == 0)
        {
            score++;
            Debug.Log("Button 1 clicked!");
            Debug.Log("Right Answer Position" + rightAnswerPosition);
            //rightAnswerMessage();
            fruitText.text = "Yay! You are correct!";
        }
/*        else
        {
            fruitText.text = "Try again";
        }*/
    }

    void OnButton2Click()
    {
        if (rightAnswerPosition == 1)
        {
            score++;
            Debug.Log("Button 2 clicked!");
            Debug.Log("Right Answer Position" + rightAnswerPosition);
            //rightAnswerMessage();
            fruitText.text = "Yay! You are correct!";
        }
/*        else
        {
            fruitText.text = "Try again";
        }*/
    }

    void OnButton3Click()
    {
        if (rightAnswerPosition == 2)
        {
            score++;
            Debug.Log("Button 3 clicked!");
            Debug.Log("Right Answer Position" + rightAnswerPosition);
            //rightAnswerMessage();
            fruitText.text = "Yay! You are correct!";
        }
/*        else
        {
            fruitText.text = "Try again";
        }*/
    }

    void OnButton4Click()
    {
        if (rightAnswerPosition == 3)
        {
            Debug.Log("Button 4 clicked!");
            Debug.Log("Right Answer Position" + rightAnswerPosition);
            score++;
            // rightAnswerMessage();
            fruitText.text = "Yay! You are correct!";

        }
/*        else
        {
            fruitText.text = "Try again";
        }*/
    }
    void rightAnswerMessage()
    {
        fruitText.text = "Yay! You are correct!";
    }
    void GenerateQuestion(int RightAnswer)
    {

        Debug.Log("GenerateQuestion " + fruitsNames);
        //fruitText.text = "Where is the ";
       fruitText.text = "Where is the " + fruitsNames[RightAnswer] + "?";
        //source.clip = fruitAudios[RightAnswer];
        //Code to generate Appropriate Audio needs to come here
    }
    // Start is called before the first frame update
    void Start()
    {
        /* for (int i =0; i<5;i++)
          {*/
        Debug.Log("Entered start");
        button1 = GameObject.Find("Button").GetComponent<Button>();
        button2 = GameObject.Find("Button (1)").GetComponent<Button>();
        button3 = GameObject.Find("Button (2)").GetComponent<Button>();
        button4 = GameObject.Find("Button (3)").GetComponent<Button>();

        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
        button3.onClick.AddListener(OnButton3Click);
        button4.onClick.AddListener(OnButton4Click);

        NextQuestion();



        /*        if (score < 5)
                {
                    NextQuestion();
                }
                else
                {
                    showWon();
                }*/


        /* Debug.Log(options[0]);
         Debug.Log(options[1]);
         Debug.Log(options[2]);
         Debug.Log(options[3]);*/
        //}



    }

    void showWon()
    {
        fruitText.text = "You Won!!!";
        Sprite image1 = Resources.Load<Sprite>("Images/" + "apple");
        Sprite image2 = Resources.Load<Sprite>("Images/" + "apple");
        Sprite image3 = Resources.Load<Sprite>("Images/" + "apple");
        Sprite image4 = Resources.Load<Sprite>("Images/" + "apple");
        button1.image.sprite = image1;
        button2.image.sprite = image2;
        button3.image.sprite = image3;
        button4.image.sprite = image4;
    }

    void NextQuestion()
    {

        Debug.Log("Inside NextQuestion...");


        if (score < 5)
        {
            rightAnswer[score] = chooseCorrectAnswer();
            //rightAnswerPosition = ran.Next(3);
            Debug.Log("rightAns[0] =>" + rightAnswer[score]);
            WrongOptions(rightAnswer[score]);

            //Debug.Log("Where is the" + fruitsNames[rightAnswer[0]] + "?");

            GenerateQuestion(rightAnswer[score]);
        }
        else
        {
            showWon();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
