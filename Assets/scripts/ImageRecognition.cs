using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageRecognition : MonoBehaviour
{

    [SerializeField]
    private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;
    ////private ARTrackedImageManager _arTrackedImageManager;
    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach(GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    public void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    public void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    public void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);   ///Debug.Log(trackedImage.name);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }
        //foreach (ARTrackedImage trackedImage in eventArgs.removed) //trying to keep spawned objects
        //{
        //    spawnedPrefabs[trackedImage.name].SetActive(false);
        //}
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;
        prefab.SetActive(true);

        //foreach(GameObject go in spawnedPrefabs.Values)
        //{
        //    if(go.name != name)
        //    {
        //        go.SetActive(false);
        //    }
        //}
    }


}
