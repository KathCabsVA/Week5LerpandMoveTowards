using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public float magnitude, speed;
    public Vector2 startPosition;


    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(3, LerpMovement());
        //transform.position = new Vector2(0, MoveTowardsMovement());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(startPosition, 0.25f);
    }

    public float PingPongAmount()
    {
        return Mathf.PingPong(Time.time * speed, magnitude);
    }

    public float SineAmount()
    {
        return Mathf.Sin(Time.time * speed) * magnitude;
    }

    public float LerpMovement()
    {
        //to make the gameObject move back and forth
        return Mathf.Lerp(startPosition.y, startPosition.y + magnitude, Mathf.PingPong(Time.time * speed, 1.0f));
    }


    public float MoveTowardsMovement()
    {
        return Mathf.MoveTowards(startPosition.y, startPosition.y + magnitude, Mathf.PingPong(Time.time * speed, magnitude));

    }
}
