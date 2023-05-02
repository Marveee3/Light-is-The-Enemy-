using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthSistem : MonoBehaviour
{
    public int health = 3;

    [SerializeField]private Image[] lives;


    void Update()
    {
        int numberOfLives = health;
        for(int i = 0; i < lives.Length; i++)
        {
            if(i < numberOfLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
        if(health <= 0)
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void TakeDamage()
    {
        health -= 1;
    }
}
