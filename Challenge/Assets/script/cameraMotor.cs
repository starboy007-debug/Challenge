using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;
    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
    }

    
    void Update()
    {
        moveVector = lookAt.position + startOffset;

        // x
        moveVector.x = 0;
        // y
        moveVector.y = Mathf.Clamp(moveVector.y,3,5);
        // z

        if(transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            //animation camera
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime *1/ animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }

    }
}
