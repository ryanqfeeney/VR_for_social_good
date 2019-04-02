using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public string scene;

    public void changescene(string scene)
    {
        Initiate.Fade(scene, Color.black, 0.5f);
    }
}

 