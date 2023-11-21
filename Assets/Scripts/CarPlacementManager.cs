using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CarPlacementManager : MonoBehaviour
{
    public GameObject Car;
    public GameObject canvasPrefab;
    
    public ARSessionOrigin sessionOrigin;

    public ARRaycastManager raycastManager;

    public ARPlaneManager planeManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    public void Start(){
        //homeCanvas.enabled = false;
    }

    public void Update(){
        if(Input.GetTouch(0).phase == TouchPhase.Began){
            bool collision = raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);
            if(collision){
                GameObject _object = Instantiate(Car);
                _object.transform.position = raycastHits[0].pose.position;
                float rotationAngle = 180f;
                _object.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
                ObjectManager.carObject = _object;
                ObjectManager.carLights = _object.transform.Find("lights").gameObject;
                ObjectManager.carLights.SetActive(false);

                GameObject canvasInstance = Instantiate(canvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                canvasInstance.transform.parent = transform;
            }

            foreach(var plane in planeManager.trackables){
                plane.gameObject.SetActive(false);
            }
            planeManager.enabled = false;
            enabled =false;
        }
    }
}
