﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cashier : MonoBehaviour
{
    public GameObject text;
    public GameObject menu;
    public float waitTime;
    public GameObject blurcam;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            blurcam.GetComponent<PostEffectScript>().blur = true;
            StartCoroutine(executeAfterTime());
        }

    }
    IEnumerator executeAfterTime()
    {
        yield return new WaitForSeconds(waitTime);
        text.SetActive(false);
        menu.SetActive(true);
    }
}