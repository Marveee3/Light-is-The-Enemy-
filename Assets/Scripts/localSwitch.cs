using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localSwitch : MonoBehaviour
{
    [SerializeField]private GameObject activeLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            activeLevel.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            activeLevel.SetActive(false);
        }
    }
}
