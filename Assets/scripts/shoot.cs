using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EasyUI.Dialogs;

public class shoot : MonoBehaviour
{

    public GameObject arCamera;
    //public GameObject PlanetInformation;
    //public GameObject Venus;

    


    //RaycastHit hit;
    //Ray ray = GetComponent<arCamera>().ScreenPointToRay(Input.mousePosition);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(Input.touchCount > 0)// && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

           // touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.GetComponent<Camera>().ScreenPointToRay(touch.position);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "Sun")
                    {
                        DialogUI.Instance
                        .SetTitle ("I am Sun")
                        //.SetAvatar (PlanetSprite.Earth)
                        .SetMessage ("Age: ~4.5 billion years\nSize:432,163.5 Mi (Sun is 109.2x larger than Earth)\nDid you know:\nThe Sun is a yellow dwarf star, a hot ball of glowing gases at the heart of our solar system. Its gravity holds everything from the biggest planets to tiny debris in its orbit.")
                        .SetButtonColor (DialogButtonColor.Magenta)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();
                    }

                    else if (hit.transform.gameObject.tag == "Mercury")
                    {
                        DialogUI.Instance
                        .SetTitle ("I am Mercury")
                        //.SetAvatar (PlanetSprite.Earth)
                        .SetMessage ("Age: 4.503 billion years\nSize: 1,516 Mi (about 1/3 the size of Earth)\nDid you know : \nMercury the smallest planet in our solar system and closest to the Sun is only slightly larger than Earth's Moon. \nMercury is the fastest planet, zipping around the Sun every 88 Earth days")
                        .SetButtonColor (DialogButtonColor.Magenta)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();
                    }

                    else if(hit.transform.tag == "Venus" )
                    {
                        DialogUI.Instance
                        .SetTitle ("I am Venus")
                        //.SetAvatar (PlanetSprite.Venus)
                        .SetMessage ("Age: 4.53 billion years \nSize: 3,760mi \n(only slightly smaller than Earth) \nDid you know : Venus spins slowly in the opposite direction from most planets. A thick atmosphere traps heat in a runaway greenhouse effect, making it the hottest planet in our solar system")
                        .SetButtonColor (DialogButtonColor.Green)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();

                        //Destroy(PlanetInformation, 5f); //Destroy information after 5 seconds
                    
                    }   

                    else if (hit.transform.gameObject.tag == "Earth")
                    {
                        DialogUI.Instance
                        .SetTitle ("I am Earth")
                        //.SetAvatar (PlanetSprite.Earth)
                        .SetMessage ("Age: 4.503 billion years Size: 92.96 mi \nDid you know :Earth, our home planet is the only place we know of so far that’s inhabited by living things. \nIt's also the only planet in oursolar system with liquid water on the Surface.")
                        .SetButtonColor (DialogButtonColor.Magenta)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();
                    }

                    else if (hit.transform.gameObject.tag == "Moon")
                    {
                        DialogUI.Instance
                        .SetTitle ("I am Earth's Moon")
                        //.SetAvatar (PlanetSprite.Earth)
                        .SetMessage ("Age: 4.53 billion years\nSize: 1,079.6 Mi (27 percent the size of Earth) \nDid you know :\nEarth's Moon is the only place beyond Earth where humans have set foot, so far.\nThe Moon makes our planet more livable by moderating how much it wobbles on its axis")
                        .SetButtonColor (DialogButtonColor.Magenta)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();
                    }

                    else if (hit.transform.gameObject.tag == "Mars")
                    {
                        DialogUI.Instance
                        .SetTitle ("I am Mars")
                        //.SetAvatar (PlanetSprite.Earth)
                        .SetMessage ("Age: 4.603 billion years\nSize:  2,106 Mi (Mars is 1.9x smaller than Earth)\nDid you know :\nMars is a dusty, cold, desert world with a very thin atmosphere. There is strong evidence Mars was—billions of years ago—wetter and warmer, with a thicker Atmosphere.")
                        .SetButtonColor (DialogButtonColor.Magenta)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();
                    }

                    else if(hit.transform.tag == "Jupiter" )
                    {
                        //Instantiate(PlanetInformation, hit.transform.position, hit.transform.rotation);
                        DialogUI.Instance
                        .SetTitle ("I am Jupiter")
                        //.SetAvatar (PlanetSprite.Jupiter)
                        .SetMessage ("Age: 4.565 billion years Size: 43,441 mi (radius; 11x Earth’s size)\nDid you know :Jupiter is more than twice as massive than the other planets of our solar system combined. \nThe giant planet's Great Red spot is a centuries-old storm bigger than Earth")
                        .SetButtonColor (DialogButtonColor.Red)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();

                        //Destroy(PlanetInformation, 5f); //Destroy information after 5 seconds
                    
                    }

                    else if(hit.transform.tag == "Saturn" )
                    {
                        //Instantiate(PlanetInformation, hit.transform.position, hit.transform.rotation);
                        DialogUI.Instance
                        .SetTitle ("I am Saturn")
                        //.SetAvatar (PlanetSprite.Jupiter)
                        .SetMessage ("Age: 4.543 billion years\nSize: 36,184 Mi (radius; 9x larger than Earth)\nDid you know :\nAdorned with a dazzling, complex system of icy rings, Saturn is unique in our solar system.\nThe other giant planets have rings, but none are as spectacular as Saturn's.")
                        .SetButtonColor (DialogButtonColor.Red)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();

                        //Destroy(PlanetInformation, 5f); //Destroy information after 5 seconds
                    
                    }

                    else if(hit.transform.tag == "Uranus" )
                    {
                        //Instantiate(PlanetInformation, hit.transform.position, hit.transform.rotation);
                        DialogUI.Instance
                        .SetTitle ("I am Uranus")
                        //.SetAvatar (PlanetSprite.Jupiter)
                        .SetMessage ("Age: 4.503 billion years\nSize:  15,759.2 Mi (4 times wider than Earth)\nDid you know :\nUranus, the seventh planet from the Sun rotates at a nearly 90-degree angle from the plane of its orbit. This unique tilt makes Uranus appear to spin on its side")
                        .SetButtonColor (DialogButtonColor.Red)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();

                        //Destroy(PlanetInformation, 5f); //Destroy information after 5 seconds
                    
                    }

                    else if(hit.transform.tag == "Neptune" )
                    {
                        //Instantiate(PlanetInformation, hit.transform.position, hit.transform.rotation);
                        DialogUI.Instance
                        .SetTitle ("I am Neptune")
                        //.SetAvatar (PlanetSprite.Jupiter)
                        .SetMessage ("Age: 4.503 billion years\nSize:  15,299.4 Mi (four times wider than Earth)\nDid you know :\nNeptune, the eighth and most distant major planet orbiting our Sun is dark, cold and whipped by supersonic winds.\nNeptune was the first planet located through mathematical calculations, rather than by telescope.")
                        .SetButtonColor (DialogButtonColor.Red)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();

                       // Destroy(PlanetInformation, 5f); //Destroy information after 5 seconds
                    
                    }

                    else if(hit.transform.tag == "Pluto" )
                    {
                        //Instantiate(PlanetInformation, hit.transform.position, hit.transform.rotation);
                        DialogUI.Instance
                        .SetTitle ("I am Pluto")
                        //.SetAvatar (PlanetSprite.Jupiter)
                        .SetMessage ("Age: 4.5 billion years\nSize: 1400 Mi (Half the width of the United States)\nDid you know:\n Pluto is a dwarf planet that lies in the Kuiper Belt, an area full of icy bodies and other dwarf planets out past Neptune.\nPluto was named in 1930 by an 11 year old girl named Venetia Burney.")
                        .SetButtonColor (DialogButtonColor.Red)
                        .SetFadeInDuration (1f)
                        .SetButtonText ("ok")
                        //.Onclose (OnDialogClose)
                        .Onclose( ()=> Debug.Log("Closed"))
                        .Show ();

                        //Destroy(PlanetInformation, 5f); //Destroy information after 5 seconds
                    
                    }


                }



   



            }
            

        }
    }
}