using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPanelManagement : MonoBehaviour
{
    //private Material [] mats;
    private MeshRenderer meshRenderer;

    public Slider red;
    public Slider green;
    public Slider blue;

    public void Start(){
        meshRenderer = ObjectManager.carObject.transform.Find("body").gameObject.GetComponent<MeshRenderer>();
        Color colorStart = meshRenderer.materials[0].color;
        red.value = colorStart.r;
        green.value = colorStart.g;
        blue.value = colorStart.b;
    }
    public void onEdit(){
        Color color = meshRenderer.materials[0].color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        meshRenderer.materials[0].color = color;
        meshRenderer.materials[0].SetColor("_Color",color);
    }
}
