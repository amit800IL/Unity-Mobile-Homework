using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideHandler : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {

            Destroy(collision.gameObject);
            StartCoroutine(LoadTimer());

        }

    }

    IEnumerator LoadTimer()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
