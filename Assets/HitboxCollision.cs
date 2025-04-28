using UnityEngine;
using UnityEngine.SceneManagement; 

public class HitboxCollision : MonoBehaviour
{
    private string sceneToLoad =  "GameOver"; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}