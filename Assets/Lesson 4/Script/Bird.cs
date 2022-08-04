using UnityEngine;
using UnityEngine.Audio;

public class Bird : MonoBehaviour
{
    Vector3 offSet;
    Vector3 birdOrigin;
    [SerializeField] float maxDistance;
    [SerializeField] float forceFactor;
    Rigidbody2D rigidbody2D;
    [SerializeField] AudioSource audioclip;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        birdOrigin = transform.position;
        Vector3 mousedown_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousedown_position.z = transform.position.z;
        offSet = mousedown_position - transform.position;
    }

    private void OnMouseDrag()
    {
        float distance;
        Vector3 new_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        new_position.z = transform.position.z;
        distance = Vector3.Distance(transform.position, birdOrigin);

        Vector3 newBirdPosition;
        newBirdPosition = new_position - offSet;
        if (distance < maxDistance)
        {
            transform.position = newBirdPosition;
        }
    }

    private void OnMouseUp()
    {
        audioclip.Play();
        rigidbody2D.gravityScale = 1;
        Vector3 dragVector = transform.position - birdOrigin;
        rigidbody2D.AddForce(new Vector2(-dragVector.x * forceFactor, -dragVector.y * forceFactor));
    }
}
