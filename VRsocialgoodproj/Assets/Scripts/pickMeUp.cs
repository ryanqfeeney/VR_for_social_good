using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickMeUp : MonoBehaviour
{

public GameObject Panel;
 public float Wait = 5;
   public AudioClip impact;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    void OnMouseDown()
    {


  StartCoroutine (PanelWait ());
        audioSource.PlayOneShot(impact, 0.7F);
    }
IEnumerator PanelWait ()
 {
     yield return new WaitForSeconds (Wait);
     Panel.SetActive (false);
 }
}