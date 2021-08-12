using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Field;
    public GameObject PlayerPref;
    public GameObject GoalPref;

    private GameObject m_player;
    private GameObject m_playerCamera;
    private GameObject m_goal;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Instantiate(
            PlayerPref,
            new Vector3(-4.5f, 0.6f, -4.5f),
            Quaternion.identity,
            Field.transform);
        m_goal = GameObject.Instantiate(
            GoalPref,
            new Vector3(4.5f, 0.5f, 4.5f),
            Quaternion.identity,
            Field.transform);

        m_playerCamera = m_player.GetComponentInChildren<Camera>().gameObject;

        MainCamera.SetActive(false);
        m_playerCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (MainCamera.activeInHierarchy) {
                MainCamera.SetActive(false);
                m_playerCamera.SetActive(true);
            }
            else {
                MainCamera.SetActive(true);
                m_playerCamera.SetActive(false);
            }
        }
    }
}
