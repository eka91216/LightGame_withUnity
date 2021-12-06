using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject m_GoalButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Destination" && MainManager.m_IsItem == true)
        {
            m_GoalButton.SetActive(true);
        }
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