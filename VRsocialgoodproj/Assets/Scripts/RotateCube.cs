using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public float spinForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinForce * Time.deltaTime, 0);
    }

    public void StartSpin()
    {
        spinForce = 45;
    }

    public void StopSpin()
    {
        spinForce = 0;
    }
    
    public void delete()
    {
        Destroy(gameObject);
    }
    public void nextscene()
    {
        Initiate.Fade("Scene3", Color.black, 0.5f);
    }
}
