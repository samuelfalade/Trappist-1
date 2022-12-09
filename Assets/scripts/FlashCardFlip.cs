using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using EasyUI.Dialogs;

public class Question
{
    public string question;
    public string correctAnswer;
    public Question(string q, string c)
    {
        question = q;
        correctAnswer = c;
    }


}


public class FlashCardFlip : MonoBehaviour
{

    public RectTransform r; // Hold flashcard object scale
    public TextMeshProUGUI cardText;
    public Question[] ques = new Question[8];

    private float flipTime = 0.5f;
    private int faceSide = 1; // 0 = front, 1 = back
    private int isShrinking = -1; //-1 = get smaller, 1 = get bigger
    private bool isFlipping = false;
    private int cardNum = 0;
    private float distancePerTime;
    private float timeCount = 0;
    
    //[SerializeField] Color[] buttonColors;////////


    [SerializeField] Color[] buttonColors;

    // Start is called before the first frame update
    void Start()
    {
        ques[0] = new Question("What is the position of Venus from the Sun?", "Venus is the second planet from the Sun" );
        ques[1] = new Question("What planet in our Solar System is know to support life?", "Earth" );
        ques[2] = new Question("Which planet is the warmest planet in our Solar System?", "Venus" );
        ques[3] = new Question("What is the average temperature of the hottest planet in our Solar System?" , "867.2°F or 464°C (Chicken is done cooking when temperature reaches 165°F" );
        ques[4] = new Question("Which planet is the coldest planet in our Solar System?", "Pluto" );
        ques[5] = new Question("Why is Venus the hottest planet in our Solar system despited being farther from the sun than Mercury?", "The atmosphere traps heat, making it feel like a furnace on the surface." );
        ques[6] = new Question("What planet is regarded as the Earths twin?", "Venus is sometimes called Earth’s twin because it’s similar in size and structure, but the planets are very different in other ways." );
        ques[7] = new Question("What planet is the closest to the Sun?", "Mercury" );
        //ques[3] = new Question("Q?", "A" );
        //dialog.ButtonColor = color; ///////////////////////////

        distancePerTime = r.localScale.x / flipTime;
        cardNum = 0;
        cardText.text = ques[cardNum].question;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlipping)
        {
            Vector3 v = r.localScale;
            v.x += isShrinking * distancePerTime *Time.deltaTime;
            r.localScale = v;

            timeCount += Time.deltaTime;
            if((timeCount >= flipTime) && (isShrinking < 0))
            {
                isShrinking = 1; //make it grow
                timeCount = 0;
                if (faceSide == 0)
                {
                    faceSide = 1;
                    cardText.text = ques[cardNum].correctAnswer;
                    //cardText.color;
                   // ButtonColor = DialogButtonColor.Blue;///////////////
                }
                else
                {
                    faceSide = 0;
                    cardText.text = ques[cardNum].question;
                }
            }
            else if ((timeCount >= flipTime) && (isShrinking == 1))
            {
                isFlipping = false;
            }
        }
    }
    public void NextCard()
    {
        faceSide = 0;
        cardNum++;
        if (cardNum >= ques.Length)
        {
            cardNum = 0;
        }
        cardText.text = ques[cardNum].question;
    }
    public void FlipCard()
    {
        timeCount = 0;
        isFlipping = true;
        isShrinking = -1;
    }
}
