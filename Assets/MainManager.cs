using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameObject m_CurrentPanel;
    public GameObject m_BeforePanel;
    public GameObject m_MainPanel;
    public GameObject m_FailPanel;

    public GameObject m_SheepPlayer;
    public GameObject m_CowPlayer;
    public GameObject m_ChickenPlayer;

    public GameObject m_MountainObstacle;
    public GameObject m_DesertObstacle;
    public GameObject m_UniverseObstacle;
    public GameObject m_SnowObstacle;
    static public GameObject[] m_ObstacleArray;
    public int ObstacleIndex = 0;

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
    public static bool m_IsGoal;
    public static bool m_IsFail;

    public GameObject[] m_InitiateProduct;

    // Start is called before the first frame update
    void Start()
    {
        //initial setting
        m_Setting = false;
        m_IsItem = false;
        m_IsGoal = false;
        m_IsFail = false;
        m_ObstacleArray = new GameObject[10];
        m_InitiateProduct = new GameObject[3];
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

                if (m_Obstacle.tag == "MapChoice") //choose map and obstacle
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

                GameObject Player = (GameObject)Instantiate(m_Player, new Vector3(-8f, -4f, 0f), Quaternion.Euler(0, 90, 0));
                GameObject Destination = (GameObject)Instantiate(m_Destination, new Vector3(Random.Range(0f, 9f), Random.Range(-4f, 5.8f), 0f), Quaternion.Euler(270, 0, 0));
                GameObject Item = (GameObject)Instantiate(m_Item, new Vector3(Random.Range(-9f, 9f), Random.Range(0f, 5.8f), 0f), Quaternion.identity);
                m_InitiateProduct[0] = Player;
                m_InitiateProduct[1] = Destination;
                m_InitiateProduct[2] = Item;

                for(int i = 0; i < 10; i++)
                {
                    GameObject obj;

                    if (m_Obstacle.name == "Cactus")
                    {
                        obj = (GameObject)Instantiate(m_Obstacle, new Vector3(Random.Range(-6f, 9f), Random.Range(-4f, 4f), 0f), Quaternion.identity);
                    }
                    else obj = (GameObject)Instantiate(m_Obstacle, new Vector3(Random.Range(-6f, 9f), Random.Range(-4f, 4f), 0f), Quaternion.Euler(270, 0, 0));

                    m_ObstacleArray[ObstacleIndex] = obj;
                    ObstacleIndex++;
                }
                m_Setting = true;
            }
        }

        if (m_IsItem == true && m_InitiateProduct[2] != null) Destroy(m_InitiateProduct[2]);
        if (m_IsGoal == true) m_GoalButton.SetActive(true);
        if (m_IsFail == true) m_FailPanel.SetActive(true);
    }

    public void GoalButton()
    {
        GameStart = false;
        m_Setting = false;
        if (m_MountainBackground.activeSelf == true) m_MountainBackground.SetActive(false);
        if (m_DesertBackground.activeSelf == true) m_DesertBackground.SetActive(false);
        if (m_UniverseBackground.activeSelf == true) m_UniverseBackground.SetActive(false);
        if (m_SnowBackground.activeSelf == true) m_SnowBackground.SetActive(false);

        if (m_IsItem == false) for (int j = 0; j < 3; j++) Destroy(m_InitiateProduct[j]);
        if (m_IsItem == true)
        {
            Destroy(m_InitiateProduct[0]); //destroy player
            Destroy(m_InitiateProduct[1]); //destroy destination
        }

        for (int i = 0; i < 10; i++)
        {
            Destroy(m_ObstacleArray[i]);
            ObstacleIndex = 0;
        }

        m_IsItem = false;
        m_IsGoal = false;
        m_IsFail = false;
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

        if (m_IsItem == false) for (int j = 0; j < 3; j++) Destroy(m_InitiateProduct[j]);
        if (m_IsItem == true)
        {
            Destroy(m_InitiateProduct[0]); //destroy player
            Destroy(m_InitiateProduct[1]); //destroy destination
        }

        for (int i = 0; i < 10; i++)
        {
            Destroy(m_ObstacleArray[i]);
            ObstacleIndex = 0;
        }

        m_IsItem = false;
        m_IsGoal = false;
        m_IsFail = false;
        m_CurrentPanel.SetActive(false);
        m_BeforePanel.SetActive(true);
        m_FailPanel.SetActive(false);
        m_GoalButton.SetActive(false);
    }

    public void GameQuit()
    {
        //GameStart = false;
        //if (m_MountainBackground.activeSelf == true) m_MountainBackground.SetActive(false);
        //if (m_DesertBackground.activeSelf == true) m_DesertBackground.SetActive(false);
        //if (m_UniverseBackground.activeSelf == true) m_UniverseBackground.SetActive(false);
        //if (m_SnowBackground.activeSelf == true) m_SnowBackground.SetActive(false);
        
        Application.Quit();
    }
}
