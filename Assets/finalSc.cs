using UnityEngine.SceneManagement;
using UnityEngine;

public class finalSc : MonoBehaviour
{

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
