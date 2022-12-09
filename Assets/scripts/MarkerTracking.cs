using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MarkerTracking : MonoBehaviour
{

   // Start is called before the first frame update
    public GameObject[] AR_Prefabs;

    private readonly Dictionary<string, GameObject> instanciatedPrefabs = new Dictionary<string, GameObject>();
    
    private ARTrackedImageManager myManager;
    // Start is called before the first frame update
    private void OnEnable()
    {
        myManager = GetComponent<ARTrackedImageManager>();
        myManager.trackedImagesChanged += changeDetected;
    }

    private void OnDisable()
    {
        myManager.trackedImagesChanged -= changeDetected;
    }

    private void changeDetected(ARTrackedImagesChangedEventArgs eventArguments)
    {
        //Marker detected
        foreach (var detectedImage in eventArguments.added)
        {
            string imageName = detectedImage.name;

            foreach (var scenePrefab in AR_Prefabs)
            {
                string prefabName = scenePrefab.name;

                if(string.Compare(imageName, prefabName, System.StringComparison.Ordinal) == 0
                && !instanciatedPrefabs.ContainsKey(imageName))
                {
                    var createdPref = Instantiate(scenePrefab, detectedImage.transform);

                    instanciatedPrefabs[prefabName] = createdPref;
                }
            }
        }


         //Marker changed
        foreach (var detectedImage in eventArguments.updated)
        {
            instanciatedPrefabs[detectedImage.referenceImage.name]   //detect an image and search through the dictionary.
                .SetActive(detectedImage.trackingState == TrackingState.Tracking);
        }

        //Marker is gone
        foreach (var detectedImage in eventArguments.removed)
        {
            Destroy(instanciatedPrefabs[detectedImage.referenceImage.name]);

            instanciatedPrefabs.Remove(detectedImage.referenceImage.name);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
