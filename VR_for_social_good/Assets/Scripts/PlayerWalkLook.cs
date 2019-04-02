using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkLook : MonoBehaviour
{
    public int PlayerSpeed = 0;
    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vrCamera.eulerAngles.x >= 10 && vrCamera.eulerAngles.x < 30.0f)
        {
            transform.position = transform.position + Camera.main.transform.forward * PlayerSpeed * Time.deltaTime;
        }
    }
}
