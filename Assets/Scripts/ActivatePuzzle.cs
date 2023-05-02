using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePuzzle : MonoBehaviour
{
    [SerializeField]private GameObject puzzle;
    [SerializeField]private bool noPuzzle;
    [SerializeField]private GameObject eButton;
    public bool youCanGo = false;

    // void Update()
    // {

    // }

    void OnCollisionStay2D(Collision2D other)
    {   
        eButton.SetActive(true);
        if(other.collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && noPuzzle != true)
        {
            puzzle.SetActive(true);

        }
        if(other.collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && noPuzzle != false)
        {
            youCanGo = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        eButton.SetActive(false);
    }
}
