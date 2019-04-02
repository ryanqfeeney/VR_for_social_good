using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	
	public static DontDestroy Instance;
	[HideInInspector]
	public double calories=0;
	[HideInInspector]
	public double simpleCarbs=0;
	[HideInInspector]
	public double complexCarbs=0;
	[HideInInspector]
	public double bloodSugar=90;
	[HideInInspector]
	public System.DateTime clock;

	
    void Awake()
    {
       if(Instance == null){
			DontDestroyOnLoad(gameObject);
			Instance = this;

    }
		else if (Instance != this){

			Destroy(gameObject);	
		}
	}

}
