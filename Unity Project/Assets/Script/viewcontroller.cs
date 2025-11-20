using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewcontroller : MonoBehaviour
{
    private float mouseX,mouseY;
    public  float mouseSensitivity;
    public Transform player;
    public float xRotation;

    //void Start()
    //{

        //transform.localRotation = Quaternion.Euler(0f, -90f, 0f);

        //if (player != null)
        //{
         //   player.Rotate(Vector3.up * -90f);
        //}
   // }

    private void Update(){
        //get mouse x,y position
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity*Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity*Time.deltaTime;
        xRotation -= mouseY;
        xRotation  = Mathf.Clamp(xRotation,-70f,70f);
 
        player.Rotate(Vector3.up*mouseX);
     
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
