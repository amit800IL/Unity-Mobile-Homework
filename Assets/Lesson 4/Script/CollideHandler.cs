using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideHandler : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
           StartCoroutine(Destroy());
           Destroy(collision.gameObject);
        }
       
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.00000001f);
        
    }
}
