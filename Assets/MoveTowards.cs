using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public float magnitude, speed;
    public Vector2 startPosition;

    public Transform followTarget;

    public bool follow = false;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            //transform.position = new Vector2(0, LerpMovement());
            transform.position = new Vector2(MoveTowardsMovementXAxis(), MoveTowardsMovementYAxis());
            return;
        }
        transform.position = new Vector2(startPosition.x, LerpMovement());
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


    public float MoveTowardsMovementYAxis()
    {
        return Mathf.MoveTowards(this.transform.position.y, followTarget.position.y, Mathf.PingPong(Time.deltaTime * speed, magnitude));
    }

    public float MoveTowardsMovementXAxis()
    {
        return Mathf.MoveTowards(this.transform.position.x, followTarget.position.x, Mathf.PingPong(Time.deltaTime * speed, magnitude));
    }


}
