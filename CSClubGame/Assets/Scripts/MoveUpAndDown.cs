using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    private bool isUp;          // If true, the obj will move up  
    private bool isDo;          // If true, the obj will move down 
    public Rigidbody rb;       // The rigidbody this script is attached to 
    public float speed = 0f;  // The speed at which the object will move 
    private bool spdS; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Set rb to the rigidbody this script is attacehd to 
        isUp = true;                    // Set isUp to true
        isDo = false;                   // Set isDo to false (should already be false but jic)
        StartCoroutine(ChangeDir());    // Start the ChangeDir coroutine 
        StartCoroutine(ChangeSpd()); 
    }

    void Update()
    {
        if (isUp)                                                              // is isUp is true... 
        {
            rb.transform.Translate(transform.right * Time.deltaTime * speed);    // Move rb up 
        }
        if (isDo)                                                              // is isDo is true... 
        {
            rb.transform.Translate(-transform.right * Time.deltaTime * speed);   // Move rb down 
        }
    }

    IEnumerator ChangeDir()
    {
        while (0 < 1)                           // Basically a never ending loop... 
        {
            speed = speed + 0.01f; 
            yield return new WaitForSeconds(1); // Wait 2 seconds 
            spdS = !spdS;
            yield return new WaitForSeconds(1);
            isUp = !isUp;                       // toggle isUp 
            isDo = !isDo;                       // toggle isDo 
        }
    }

    IEnumerator ChangeSpd()
    {
        while (0 < 1)
        {
            if (spdS)
            {
                speed = speed + 0.01f;
            }
            else
            {
                speed = speed - 0.01f; 
            }
            

        }
    }
}