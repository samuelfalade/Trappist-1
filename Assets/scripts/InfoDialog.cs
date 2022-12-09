using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.Dialogs;

public class InfoDialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    //Show dialog
    {
        //Show dialog
        //DialogUI.Instance
       // .SetTitle ("Notification")
       // .SetMessage ("Hello World")
       // .SetButtonColor (DialogButtonColor.Red)
       // .SetFadeInDuration (5f)
       // .SetButtonText ("ok")
       // //.Onclose (OnDialogClose)
       // .Onclose( ()=> Debug.Log("Closed"))
       // .Show ();

    }

    void OnDialogClose ()
    {
        Debug.Log("closed");
    }

 
}
