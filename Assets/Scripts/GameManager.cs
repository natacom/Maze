using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Field;
    public GameObject PlayerPref;
    public GameObject GoalPref;

    public int m_rowNum = 10;
    public int m_columnNum = 10;

    private GameObject m_player;
    private GameObject m_playerCamera;
    private GameObject m_goal;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FieldGenerator>().Generate(m_rowNum, m_columnNum);

        // Adjust floor
        var floor = GameObject.FindGameObjectWithTag("Floor").transform;
        floor.localScale = new Vector3(m_columnNum, 0.1f, m_rowNum);
        floor.position = new Vector3(floor.localScale.x / 2, 0, floor.localScale.z / 2);

        m_player = Instantiate(
            PlayerPref,
            new Vector3(0.5f, 0.6f, 0.5f),
            Quaternion.identity,
            Field.transform);
        m_goal = Instantiate(
            GoalPref,
            new Vector3(m_columnNum - 0.5f, 0.5f, m_rowNum - 0.5f),
            Quaternion.identity,
            Field.transform);

        m_playerCamera = m_player.GetComponentInChildren<Camera>().gameObject;

        //m_playerCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
