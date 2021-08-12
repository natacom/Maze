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

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FieldGenerator>().Generate(m_rowNum, m_columnNum);

        // Add player
        Instantiate(
            PlayerPref,
            new Vector3(0.5f, 0.6f, 0.5f),
            Quaternion.identity,
            Field.transform);

        // Add goal
        Instantiate(
            GoalPref,
            new Vector3(m_columnNum - 0.5f, 0.5f, m_rowNum - 0.5f),
            Quaternion.identity,
            Field.transform);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
