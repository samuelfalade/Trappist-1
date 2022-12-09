using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace EasyUI.Dialogs
{
    public enum DialogButtonColor
    {
        Black,
        Purple,
        Magenta,
        Blue,
        Green,
        Yellow,
        Orange,
        Red
    }
    public enum PlanetSprite
    {
        Sun,
        mercury,
        Venus,
        Earth,
        Moon,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune,
        Pluto
    }

    public class Dialog{
        public PlanetSprite PlanetSprite = PlanetSprite.Sun;////// sprite avatars
        public string Title = "Title/ Planet Name";
        public string Message = "Information Here";
        public string ButtonText = "Close";
        public float FadeInDuration = .3f;
        public DialogButtonColor ButtonColor = DialogButtonColor.Black;
        public UnityAction Onclose = null;
    }


    public class DialogUI : MonoBehaviour{
        [SerializeField] GameObject canvas;
        [SerializeField] TextMeshProUGUI titleUIText;
        [SerializeField] TextMeshProUGUI messageUIText;
        [SerializeField] Button closeUIButton;
        [SerializeField] Image planetSprite;
        
        Image planetSpriteImage;
        Image closeUIButtonImage;
        Text closeUIButtonText;
        CanvasGroup canvasGroup;

        [Space(20f)]
        [Header("Close button colors")]
        [SerializeField] Color[] buttonColors;

        [Header("Close planet sprites")]
        [SerializeField] Sprite[] planetSprites;///// Sprite avatars

        Dialog dialog = new Dialog();

        //Singleton pattern
        public static DialogUI Instance;

        void Awake(){
            Instance = this;

            closeUIButtonImage = closeUIButton.GetComponent <Image> ();
            //planetSpriteImage = planetSprite.GetComponent <Image> (); ////
            closeUIButtonText = closeUIButton.GetComponentInChildren <Text> ();
            canvasGroup = canvas.GetComponent <CanvasGroup>();

            //Add close event listener
            closeUIButton.onClick.RemoveAllListeners();
            closeUIButton.onClick.AddListener (Hide);
        }

        //Set Dialog Title
        public DialogUI SetTitle (string title){
            dialog.Title = title;
            return Instance;
        }

        //Set Dialog Message
        public DialogUI SetMessage (string message){
            
            dialog.Message = message;
            return Instance;
        }     

        //Set Dialog Button Text
        public DialogUI SetButtonText (string text)
        {
            dialog.ButtonText = text;
            return Instance;
        }     

        //Set Dialog Button Color
        public DialogUI SetButtonColor (DialogButtonColor color)
        {
            dialog.ButtonColor = color;
            return Instance;
        }     

        //public DialogUI SetAvatar (PlanetSprite sprite)///// For Sprite Avatars
        //{
        //    dialog.PlanetSprite = sprite;
        //    return Instance;
        //}  

        //Set Fade in duration
        public DialogUI SetFadeInDuration (float duration)
        {
            dialog.FadeInDuration = duration;
            return Instance;
        }     


        //Set Onclose  
        public DialogUI Onclose (UnityAction action){
            dialog.Onclose = action;
            return Instance;
        }    

        //Show Dialog   
        public void Show(){
            titleUIText.text = dialog.Title;
            messageUIText.text = dialog.Message;
            //closeUIButtonText.text = dialog.ButtonText.ToUpper ();
            closeUIButtonImage.color = buttonColors[ (int) dialog.ButtonColor];
            //planetSpriteImage.sprite = planetSprites[ (int) dialog.PlanetSprite];//// Sprite avatars


            canvas.SetActive (true);
            StartCoroutine (FadeIn (dialog.FadeInDuration));
        }

        //Hide Dialog   
        public void Hide(){
            canvas.SetActive (false);

            //Invoke Onclose Event
            if (dialog.Onclose != null)
                dialog.Onclose.Invoke ();

            //Reset Dialog
            dialog = new Dialog();

            StopAllCoroutines ();


        }

        IEnumerator FadeIn(float duration)
        {
            float startTime = Time.time;
            float alpha = 0f;

            while(alpha < 1f )
            {
                alpha = Mathf.Lerp (0f, 1f, (Time.time-startTime) / duration );
                canvasGroup.alpha = alpha;

                yield return null;
            }
        }

}

}