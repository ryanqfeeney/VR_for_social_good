using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fridgeFoodOption : MonoBehaviour
{
public GameObject options;
    // Start is called before the first frame update
    void Start()
    {
       options.SetActive(false); 
    }
 void OnMouseDown()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        options.SetActive(true);}
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
