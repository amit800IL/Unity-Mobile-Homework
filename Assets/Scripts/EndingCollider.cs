using UnityEngine;

using UnityEngine.SceneManagement;

public class EndingCollider : MonoBehaviour
{
    [SerializeField]
    GameDataManager gameDataManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameDataManager.WriteToJson();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

