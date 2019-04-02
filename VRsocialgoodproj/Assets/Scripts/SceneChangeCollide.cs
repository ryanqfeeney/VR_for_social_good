using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeCollide : MonoBehaviour
{
	
	public PlayerController player;
    	public string scene;
	
	
    	public void OnCollisionEnter(Collision col){
		player.SavePlayer();
		Initiate.Fade(scene, Color.black, 0.5f);
	} 
	
}
