using System;
using UnityEngine;
using TMPro;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizScript : MonoBehaviour
{
    private string[] fruitsNames = {"Apple", "Banana", "Blueberry", "Cherry", "Jackfruit",
        "Kiwi", "Mango", "Orange", "Peach", "Pineapple", "Strawberry", "Watermelon"};

    private int[] rightAnswer = new int[5];
    public string[] options = new string[4];

    public TMP_Text fruitText;
    public TMP_Text responseText;

    public AudioSource audioSource;
    
    public AudioClip Apple, Banana, Blueberry, Cherry, Jackfruit, Kiwi, Mango, Orange, Peach, Pineapple, Strawberry, Watermelon;
    public AudioClip Correct, Incorrect;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public int rightAnswerPosition;
    private int score = 0;

    //Random object is created to randomly generate the questions and options.
    System.Random ran = new System.Random();



    // Start is called before the first frame update
    void Start()
    {

        //Get all buttons, audio and text components and add on click listeners for each thats needed
        Debug.Log("Entered start");
        button1 = GameObject.Find("Option1").GetComponent<Button>();
        button2 = GameObject.Find("Option2").GetComponent<Button>();
        button3 = GameObject.Find("Option3").GetComponent<Button>();
        button4 = GameObject.Find("Option4").GetComponent<Button>();

        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
        button3.onClick.AddListener(OnButton3Click);
        button4.onClick.AddListener(OnButton4Click);

        
        responseText = GameObject.Find("Response").GetComponent<TMP_Text>();
        fruitText = GameObject.Find("Question").GetComponent<TMP_Text>();

        audioSource = GameObject.Find("audioSource").GetComponent<AudioSource>();

        NextQuestion();

    }


    // Update is called once per frame
    void Update()
    {
     
    }

    // Function for choosing the correct answer and returning what the user chooses
    public int ChooseCorrectAnswer()
    {
        bool uniqueFruit = false;
        int chosenFruit;

        do
        {
            chosenFruit = ran.Next(11);
            uniqueFruit = true;

            for (int i = 0; i < rightAnswer.Length; i++)
            {
                if (chosenFruit == rightAnswer[i])
                {
                    uniqueFruit = false;
                    break;
                }
            }
        } 

        while (!uniqueFruit);
        return chosenFruit;
       
        
    }

    /* Description : 
    WrongOptions method chooses the other three wrong answers to be displayed dynamically.
   */
    public void WrongOptions(int rightAnswer)
    {
        string[] wrongAnswer = new string[4];
        wrongAnswer[0] = fruitsNames[rightAnswer];
        int wrongAnswerCounter = 1;
        Sprite sprite;
        while (wrongAnswerCounter != 4)
        {
            int randomOption = ran.Next(0,11);
            if (IsUnique(randomOption, wrongAnswer))
            { 
                wrongAnswer[wrongAnswerCounter] = fruitsNames[randomOption];

                sprite = Resources.Load<Sprite>(fruitsNames[randomOption]);  // Load the image from the path
                wrongAnswerCounter++;
            }
            
        }
        Shuffle(wrongAnswer);

    }
    /* Description : 
    isUnique(int newOption, int[] WrongOptions) method checks whether all the options of the question are unique.
   */
    bool IsUnique(int newOption, string[] WrongOptions)
    {
        for(int i = 0; i< WrongOptions.Length;i++)
        {
            if (fruitsNames[newOption] == WrongOptions[i])
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

    /*Description : 
     * void OnButton1Click(), OnButton2Click(), OnButton2Click(), OnButton3Click() 
     * are event listeners to the 4 option buttons
     */
    void OnButton1Click()
    {
        if(rightAnswerPosition == 0)
        {
            RightAnswerMessage();
        }else
        {
            WrongAnswerMessage();
        }
    }

    void OnButton2Click()
    {
        if (rightAnswerPosition == 1)
        {
            RightAnswerMessage();
        }
        else
        {
            WrongAnswerMessage();
        }
    }

    void OnButton3Click()
    {
        if (rightAnswerPosition == 2)
        {
            RightAnswerMessage();
        }
      else
        {
            WrongAnswerMessage();
        }
    }

    void OnButton4Click()
    {
        if (rightAnswerPosition == 3)
        {
            RightAnswerMessage();
        }
        else
        {
            WrongAnswerMessage();
        }
    }

    /*Description :
     * void RightAnswerMessage() loads when correct answer is clicked
     */
    void RightAnswerMessage()
    {
        score++;
        responseText.text = "Yay! You are correct!";
        audioSource.clip = Resources.Load<AudioClip>("Audios/Responses/Correct");
        audioSource.Play();
        
        NextQuestion();
    }


    /*Description :
     * void WrongAnswerMessage() loads when wrong answer is clicked
    */
    void WrongAnswerMessage()
    {
        responseText.text = "Try again";
        audioSource.clip = Resources.Load<AudioClip>("Audios/Responses/Incorrect");
        audioSource.Play();
       
    }

    /*Description :
    * void GenerateQuestion(int RightAnswer) loads the question onto the scene and plays the audio prompt for it
    */
   void GenerateQuestion(int rightAnswerIndex)
    {


    fruitText.text = "Where is the " + fruitsNames[rightAnswerIndex] + "?";

    for(int i = 0; i < fruitsNames.Length; i++)
    {
        if (i == rightAnswerIndex){

            audioSource.clip = Resources.Load<AudioClip>("Audios/Questions/" + fruitsNames[rightAnswerIndex]);
            audioSource.Play();;
        }
    }


    }

    /*Description :
    * void ShowVictoryMessage() loads victory message after quiz completion
    */
    void ShowVictoryMessage()
    {
        fruitText.text = "You Won!!!";
        Sprite image1 = Resources.Load<Sprite>("Images/" + "Apple");
        Sprite image2 = Resources.Load<Sprite>("Images/" + "Apple");
        Sprite image3 = Resources.Load<Sprite>("Images/" + "Apple");
        Sprite image4 = Resources.Load<Sprite>("Images/" + "Apple");
        button1.image.sprite = image1;
        button2.image.sprite = image2;
        button3.image.sprite = image3;
        button4.image.sprite = image4;
    }

    /*Description :
    * void NextQuestion() manages the questions
    */
    void NextQuestion()
    {
        if (score < 5)
        {
            rightAnswer[score] = ChooseCorrectAnswer();
            WrongOptions(rightAnswer[score]);
            GenerateQuestion(rightAnswer[score]);
        }
        else
        {
            SceneManager.LoadScene ("Congrats");
        }
    }

    
}
