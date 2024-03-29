﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDudeMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    public bool stop;

    private float timeSinceChangedRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2.5f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                timeSinceChangedRotation = 0f;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180f, 0);
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), .5f) && timeSinceChangedRotation>=1f)
        {
            int randomInt = Random.Range(0, 2);
            timeSinceChangedRotation = 0f;
            if (randomInt == 0)
            {
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90f, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 90f, 0);
            }
        }
        else if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), .5f) && timeSinceChangedRotation >= 2f)
        {
            timeSinceChangedRotation = 0f;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 90f, 0);
        }
        else if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), .5f) && timeSinceChangedRotation >= 2f)
        {
            timeSinceChangedRotation = 0f;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90f, 0);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), .5f))
        {
            
            stop = true;
        }
        else if (stop)
        {
            stop = false;
        }
        if (!stop)
        {
            transform.Translate(Time.deltaTime * speed * Vector3.forward);

        }

        timeSinceChangedRotation += Time.deltaTime;
    }
}
