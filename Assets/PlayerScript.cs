using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destination")
        {
            if (MainManager.m_IsItem == true)
            {
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.Play();
            }
        }
        if(other.gameObject.tag == "Item")
        {
            if (MainManager.m_IsItem == false)
            {
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.Play();
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position -= new Vector3(0f, -0.05f, 0f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0f, 0.05f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position -= new Vector3(-0.05f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(0.05f, 0f, 0f);
        }
    }
}
