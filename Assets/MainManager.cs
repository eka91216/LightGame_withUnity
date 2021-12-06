using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public GameObject m_CurrentPanel;
    public GameObject m_BeforePanel;
    
    public GameObject m_MountainObstacle;
    public GameObject m_DesertObstacle;
    public GameObject m_UniverseObstacle;
    public GameObject m_SnowObstacle;

    public GameObject m_MountainBackground;
    public GameObject m_DesertBackground;
    public GameObject m_UniverseBackground;
    public GameObject m_SnowBackground;

    public static GameObject m_Player;
    public static GameObject m_Obstacle;
    public static bool GameStart;

    //float startWait;
    float spawnWait;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) GameQuit();

        if(GameStart == true) //Game Start!!
        {
            //Make Player
            GameObject obj = (GameObject)Instantiate(m_Player, new Vector3(Random.Range(-9f, 9f), 6f, -3f), Quaternion.identity);

            //Make Destination

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

            //startWait = 3.0f;
            spawnWait = 2.0f;

            StartCoroutine(SpawnObstacle()); //Start Coroutine
        }
    }

    IEnumerator SpawnObstacle()
    {
        //GameObject obj = (GameObject)Instantiate(m_Obstacle, new Vector3(Random.Range(-9f, 9f), 6f, -3f), Quaternion.identity);

        yield return new WaitForSeconds(spawnWait);
    }

    public void BackButton()
    {
        GameStart = false;
        if (m_MountainBackground.activeSelf == true) m_MountainBackground.SetActive(false);
        if (m_DesertBackground.activeSelf == true) m_DesertBackground.SetActive(false);
        if (m_UniverseBackground.activeSelf == true) m_UniverseBackground.SetActive(false);
        if (m_SnowBackground.activeSelf == true) m_SnowBackground.SetActive(false);

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
