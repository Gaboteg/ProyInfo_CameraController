using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamSwitcher : MonoBehaviour
{
    public Transform Player;
    public CinemachineVirtualCamera activeCam;
    public CinemachineVirtualCamera topCam;
    private bool cameraOn = false;
    public Material material1;
    public Material material2;
    public float alpha = 0.5f;
    //public GameObject currentGameObject;

    void Start()
    {
        //currentGameObject = gameObject;
        //material1 = mate1;
        //material2 = mate2;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraOn = !cameraOn;
            Debug.Log("El valor del booleano ha cambiado a: " + cameraOn);

            if (cameraOn == true)
            {
                topCam.Priority = 10;
                ChangeAlpha(material1, material2, alpha);
            }
            else
            {
                topCam.Priority = 0;
                ChangeAlpha(material1, material2, 1f);
            }
        }
    }


private void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("Player"))
    {
        activeCam.Priority = 1;

    }

}

private void OnTriggerExit(Collider other)
{
    if(other.CompareTag("Player"))
    {
        activeCam.Priority = 0;
    }

}

void ChangeAlpha(Material mat1, Material mat2, float alphaVal)
{
    Color oldColor1 = mat1.color;
    Color newColor1 = new Color(oldColor1.r, oldColor1.g, oldColor1.b, alphaVal);
    Color oldColor2 = mat2.color;
    Color newColor2 = new Color(oldColor2.r, oldColor2.g, oldColor2.b, alphaVal);
    mat1.SetColor("_Color", newColor1);
    mat2.SetColor("_Color", newColor2);
}

}
