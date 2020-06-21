using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementControlsSecond : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float angle = 2 * (float)Math.PI / 6.0f;
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = this.transform.rotation;
    }

    private void Update()
    {
        if (this.transform.position.y != 25)
        {
            this.transform.position = new Vector3(this.transform.position.x,25.0f, this.transform.position.z);
        }
        
        // Debug.Log(transform.rotation);
        if (this.transform.rotation.x != 0 || this.transform.rotation.z != 0)
        {
            this.transform.rotation = new Quaternion(0,this.transform.rotation.y,0,this.transform.rotation.w);
        }
    }

    private void FixedUpdate()
    {
        
        if(this.transform.position.z > 2000)
        {
            if (this.transform.position.z < 2025)
            {
                this.transform.position = new Vector3(50, 25, 2030);
                this.transform.rotation = initialRotation;
            }
            else if (this.transform.position.z < 2620)
            {
                this.transform.Translate(new Vector3(0,0, 4.0f));
            }
            else
            {
                SceneManager.LoadScene("Scenes/Level 1");
            }
        }
        else
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");
            this.transform.Translate(new Vector3(0,0, inputVertical) * speed);
            this.transform.Rotate(new Vector3(0,inputHorizontal,0) * angle);
        }
    }
}
