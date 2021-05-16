using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay;
    public float nextlauchTime;

     // Update is called once per frame
    void Update()
    {
        if (!GameController.Instance.getIsStarted())
        {
            return;
        }

        float positionZ = transform.position.z;
        float positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2); //

        if(Time.time > nextlauchTime)
        {
            Instantiate(asteroid, new Vector3(positionX, 0, positionZ), Quaternion.identity);
            nextlauchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
        

    }
}
