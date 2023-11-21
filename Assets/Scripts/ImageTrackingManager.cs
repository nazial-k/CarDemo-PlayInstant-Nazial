using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTrackingManager : MonoBehaviour
{
    public GameObject Car;
    public ARTrackedImageManager imManager;
    public GameObject canvasPrefab;
    
    void Awake()
    {
        imManager = FindObjectOfType<ARTrackedImageManager>();
        /*
        //Vector3 car_pos = new Vector3(0,0,-10.0f);
        GameObject car_object = Instantiate(Car,Vector3.zero,Quaternion.identity);
        ObjectManager.carObject = car_object;
        ObjectManager.carLights = car_object.transform.Find("lights").gameObject;
        ObjectManager.carLights.SetActive(false);
        ObjectManager.carObject.SetActive(false);
        */
    }

    void OnEnable() => imManager.trackedImagesChanged += OnChanged;

    void OnDisable() => imManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            addCarObject(newImage);
        }
        
        foreach (var updatedImage in eventArgs.updated)
        {
            updateCarObject(updatedImage);
        }
        
        //foreach (var removedImage in eventArgs.removed)

        void addCarObject(ARTrackedImage trackedImage)
        {   
            /*
            Vector3 pos = trackedImage.transform.position;
            //pos.z += 0.5f;
            Quaternion rot = trackedImage.transform.rotation;
            rot.y +=180f;
            ObjectManager.carObject.transform.position = pos;
            
            ObjectManager.carObject.transform.rotation = rot;
            ObjectManager.carObject.SetActive(true);
            */
            setCarObject();
            GameObject canvasInstance = Instantiate(canvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            canvasInstance.transform.parent = transform;  
        }

        void setCarObject(){
            ObjectManager.carObject = GameObject.Find("car01");
            ObjectManager.carLights = ObjectManager.carObject.transform.Find("lights").gameObject;
            ObjectManager.carLights.SetActive(false);
        }
        
        void updateCarObject(ARTrackedImage trackedImage)
        {   
            /*
            Vector3 pos = trackedImage.transform.position;
            //pos.z += 0.5f;
            Quaternion rot = trackedImage.transform.rotation;
            rot.y +=180f;
            ObjectManager.carObject.transform.position = pos;
            ObjectManager.carObject.transform.rotation = rot;
            */
        }
        
    }
}
