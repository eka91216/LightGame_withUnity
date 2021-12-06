using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetPanel : MonoBehaviour
{
    public Text m_BlankText;
    public GameObject m_CurrentPanel;
    public GameObject m_NextPanel;
    public GameObject m_BeforePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.transform.gameObject.tag == "MapChoice")
                {
                    m_BlankText.text = raycastHit.transform.gameObject.name;
                    
                    MainManager.m_Obstacle = raycastHit.transform.gameObject;

                    AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                    audioSource.Play();
                }
            }
        }
    }

    public void SetButton()
    {
        if (m_BlankText.text != "")
        {
            m_BlankText.text = "";
            m_CurrentPanel.SetActive(false);
            m_NextPanel.SetActive(true);
            MainManager.GameStart = true; //Game Start
        }
    }

    public void BackButton()
    {
        m_BlankText.text = "";
        m_CurrentPanel.SetActive(false);
        m_BeforePanel.SetActive(true);
    }
}
