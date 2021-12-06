using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameObject m_CurrentPanel;
    public GameObject m_BeforePanel;
    public GameObject m_MainPanel;

    public GameObject m_SheepPlayer;
    public GameObject m_CowPlayer;
    public GameObject m_ChickenPlayer;

    public GameObject m_MountainObstacle;
    public GameObject m_DesertObstacle;
    public GameObject m_UniverseObstacle;
    public GameObject m_SnowObstacle;

    public GameObject m_MountainBackground;
    public GameObject m_DesertBackground;
    public GameObject m_UniverseBackground;
    public GameObject m_SnowBackground;

    public GameObject m_Destination;
    public GameObject m_Item;
    public GameObject m_GoalButton;

    public static GameObject m_Player;
    public static GameObject m_Obstacle;
    public static bool GameStart;
    public bool m_Setting;
    public static bool m_IsItem; //check Player take item

    // Start is called before the first frame update
    void Start()
    {
        //initial setting
        m_Setting = false;
        m_IsItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) GameQuit();

        if(GameStart == true) //Game Start!!
        {
            //initial Setting
            if(m_Setting == false)
            {
                if (m_Player.tag == "PlayerChoice")
                {
                    switch (m_Player.name)
                    {
                        case "Sheep":
                            m_Player = m_SheepPlayer;
                            break;
                        case "Cow":
                            m_Player = m_CowPlayer;
                            break;
                        case "Chicken":
                            m_Player = m_ChickenPlayer;
                            break;
                    }
                }

                if (m_Obstacle.tag == "MapChoice")
                {
                    switch (m_Obstacle.name)
                    {
                        case "Mountain":
                            m_Obstacle = m_MountainObstacle;
                            m_MountainBackground.SetActive(true);
                            break;
                        case "Desert":
                            m_Obstacle = m_DesertObstacle;
                            m_DesertBackground.SetActive(true);
                            break;
                        case "Universe":
                            m_Obstacle = m_UniverseObstacle;
                            m_UniverseBackground.SetActive(true);
                            break;
                        case "Snow":
                            m_Obstacle = m_SnowObstacle;
                            m_SnowBackground.SetActive(true);
                            break;
                    }
                }

                Instantiate(m_Player, new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f), Quaternion.Euler(0, 90, 0));
                Instantiate(m_Destination, new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 5.8f), 0f), Quaternion.Euler(270, 0, 0));
                Instantiate(m_Item, new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 5.8f), 0f), Quaternion.identity);
                m_Setting = true;
            }

            StartCoroutine(SpawnObstacle()); //Start Coroutine
        }

        if(m_GoalButton.activeSelf == true)
        {

        }
    }

    IEnumerator SpawnObstacle()
    {
        /*if (m_Obstacle.name == "Cactus")
        {
            Instantiate(m_Obstacle, new Vector3(Random.Range(-9f, 9f), 6f, 0f), Quaternion.identity);
        }
        else Instantiate(m_Obstacle, new Vector3(Random.Range(-9f, 9f), 6f, 0f), Quaternion.Euler(270, 0, 0));*/

        yield return new WaitForSeconds(2.0f);
    }

    public void GoalButton()
    {
        GameStart = false;
        m_Setting = false;
        if (m_MountainBackground.activeSelf == true) m_MountainBackground.SetActive(false);
        if (m_DesertBackground.activeSelf == true) m_DesertBackground.SetActive(false);
        if (m_UniverseBackground.activeSelf == true) m_UniverseBackground.SetActive(false);
        if (m_SnowBackground.activeSelf == true) m_SnowBackground.SetActive(false);

        //Destroy(GameObject.FindWithTag("TempForGame"));

        StopCoroutine(SpawnObstacle());
        m_CurrentPanel.SetActive(false);
        m_GoalButton.SetActive(false);
        m_MainPanel.SetActive(true);
    }

    public void BackButton()
    {
        GameStart = false;
        m_Setting = false;
        if (m_MountainBackground.activeSelf == true) m_MountainBackground.SetActive(false);
        if (m_DesertBackground.activeSelf == true) m_DesertBackground.SetActive(false);
        if (m_UniverseBackground.activeSelf == true) m_UniverseBackground.SetActive(false);
        if (m_SnowBackground.activeSelf == true) m_SnowBackground.SetActive(false);

        Destroy(GameObject.FindWithTag("TempForGame"));

        StopCoroutine(SpawnObstacle());
        m_CurrentPanel.SetActive(false);
        m_BeforePanel.SetActive(true);
    }

    public void GameQuit()
    {
        GameStart = false;
        if (m_MountainBackground.activeSelf == true) m_MountainBackground.SetActive(false);
        if (m_DesertBackground.activeSelf == true) m_DesertBackground.SetActive(false);
        if (m_UniverseBackground.activeSelf == true) m_UniverseBackground.SetActive(false);
        if (m_SnowBackground.activeSelf == true) m_SnowBackground.SetActive(false);
        
        Application.Quit();
    }
}
