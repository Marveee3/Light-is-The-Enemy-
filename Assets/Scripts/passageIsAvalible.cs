using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passageIsAvalible : MonoBehaviour
{
    [SerializeField]private GameObject yellowLight;
    [SerializeField]private GameObject greenLight;
    [SerializeField]private ActivatePuzzle act;
    [SerializeField]private GameObject door;
    [SerializeField]private Button but;

    void Update()
    {
        if(act.youCanGo == true && but.buttonPress == true)
        {
            yellowLight.SetActive(false);
            greenLight.SetActive(true);
            Destroy(door);
        }
        if(but.buttonPress == false && act.youCanGo == true)
        {
            act.youCanGo = false;
        }
        
    }
}
