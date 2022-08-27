using UnityEngine;


using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{


    public float speed;
    public Text countText;
    public Text winText;
    Quaternion origRotation;

    private Gyroscope m_Gyroscope;
    private Rigidbody rb;
    private int count;


    void Start()
    {

        rb = GetComponent<Rigidbody>();

        m_Gyroscope = Input.gyro;


        m_Gyroscope.enabled = true;
        origRotation = m_Gyroscope.attitude;

        count = 0;


        SetCountText();


        winText.text = "";
    }

    void FixedUpdate()
    {

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //  Vector3 GyroVec = new Vector3(m_Gyroscope.userAcceleration.x, 0, m_Gyroscope.userAcceleration.z);
        
        Vector3 GyroVector = new Vector3(Input.acceleration.x * speed,0, Input.acceleration.z * -speed);

        rb.velocity = GyroVector;
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pick Up"))
        {

            other.gameObject.SetActive(false);


            count += 1;


            SetCountText();
        }
    }


    void SetCountText()
    {

        countText.text = "Count: " + count.ToString();


        if (count >= 12)
        {

            winText.text = "You Win!";
        }
    }
}