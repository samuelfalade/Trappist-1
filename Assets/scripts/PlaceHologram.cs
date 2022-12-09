using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]

public class PlaceHologram : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;
    private GameObject spawnedObject;
    private GameObject PlanetInformation;
    public GameObject shoot; // trying to get a prefab

    RaycastHit hit;

    //[SerializeField] private GameObject myHologram; //Object to spawn

    private ARRaycastManager myManager;
    //private static readonly List<ARRaycastHit> myHits = new List<ARRaycastHit>();
    private Vector2 touchposition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    private void Awake()
    {
        
        myManager = GetComponent<ARRaycastManager>();
        shoot.SetActive(false);
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        
        if(!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(myManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
                shoot.SetActive(true);
            }
            
            //if (hit.transform.tag == "Earth")
            //Instantiate(PlanetInformation);

            else
            {
                //spawnedObject.transform.position = hitPose.position;
                Instantiate(PlanetInformation, hit.transform.position, hit.transform.rotation);
                Destroy(PlanetInformation, 5f); //Destroy information after 5 seconds
            }
        }

        


        
        //myManager = GetComponent<ARRaycastManager>();
        /*Touch userInput = Input.GetTouch(0);

        if(Input.touchCount < 1 || userInput.phase != TouchPhase.Began)
        {
            return;
        }

        if (myManager.Raycast(userInput.position, myHits, TrackableType.AllTypes))
        {
            var hitPose = myHits[0].pose;

            Instantiate(myHologram, hitPose.position, hitPose.rotation);
        }*/
    }
}
