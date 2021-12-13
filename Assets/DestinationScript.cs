using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (MainManager.m_IsItem == true) MainManager.m_IsGoal = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
