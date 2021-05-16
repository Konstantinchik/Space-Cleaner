using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Mathf.Repeat(Time.time * speed, 30); // 0..30
        transform.position = startPosition + new Vector3(0, 0, -move);
    }
}
