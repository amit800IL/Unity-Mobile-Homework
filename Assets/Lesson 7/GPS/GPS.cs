using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GPS : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Gpsstatus;
    [SerializeField] TextMeshProUGUI latitudeValue;
    [SerializeField] TextMeshProUGUI longitudeValue;
    [SerializeField] TextMeshProUGUI altitudeValue;
   


    private void Start()
    {
        StartCoroutine(GPSloc());
    }

    IEnumerator GPSloc()
    {
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start();

        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            Gpsstatus.text = "Time Out";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Gpsstatus.text = "Unable To Determine Device Location";
            yield break;
        }

        else
        {
            Gpsstatus.text = "Running";
            InvokeRepeating("UpdateGPSData", 0.5f, 1f);
        }

        
    }
        private void UpdateGPSData()
        {
          if (Input.location.status == LocationServiceStatus.Running)
        {
            Gpsstatus.text = "Running";
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
           

        }

        else
        {
            Gpsstatus.text = "Stop";
        }

        }
}
