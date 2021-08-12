using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    public GameObject m_obstacleContainer;
    public GameObject Poll;
    public GameObject Wall;

    private List<GameObject> m_PollList = new List<GameObject>();
    private List<GameObject> m_WallList = new List<GameObject>();

    private int m_rowNum;
    private int m_columnNum;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Generate(int rowNum, int columnNum)
    {
        m_PollList.Clear();
        m_WallList.Clear();

        m_rowNum = rowNum;
        m_columnNum = columnNum;

        // Adjust floor
        var floor = GameObject.FindGameObjectWithTag("Floor").transform;
        floor.localScale = new Vector3(m_columnNum, 0.1f, m_rowNum);
        floor.position = new Vector3(floor.localScale.x / 2, 0, floor.localScale.z / 2);

        libMaze.Generate(m_rowNum, m_columnNum);

        CreatePolls();
        CreateOuterWalls();
        CreateInnerWalls();
    }

    private void CreatePolls()
    {
        for (int r = 0; r <= m_rowNum; ++r) {
            for (int c = 0; c <= m_columnNum; ++c) {
                m_PollList.Add(
                    Instantiate(
                        Poll,
                        new Vector3(c, 0.5f, r),
                        Quaternion.identity,
                        m_obstacleContainer.transform));
            }
        }
    }

    private void CreateOuterWalls()
    {
        for (int c = 0; c < m_columnNum; ++c) {
            float basePos = c + 0.5f;
            // top
            m_WallList.Add(
                Instantiate(
                    Wall,
                    new Vector3(basePos, 0.5f, 0),
                    Quaternion.Euler(0, 90, 0),
                    m_obstacleContainer.transform));
            // bottom
            m_WallList.Add(
                Instantiate(
                    Wall,
                    new Vector3(basePos, 0.5f, m_rowNum),
                    Quaternion.Euler(0, 90, 0),
                    m_obstacleContainer.transform));
        }
        for (int r = 0; r < m_rowNum; ++r) {
            float basePos = r + 0.5f;
            // right
            m_WallList.Add(
                Instantiate(
                    Wall,
                    new Vector3(m_columnNum, 0.5f, basePos),
                    Quaternion.identity,
                    m_obstacleContainer.transform));
            // left
            m_WallList.Add(
                Instantiate(
                    Wall,
                    new Vector3(0, 0.5f, basePos),
                    Quaternion.identity,
                    m_obstacleContainer.transform));
        }
    }

    private void CreateInnerWalls()
    {
        for (int r = 0; r < m_rowNum; ++r) {
            for (int c = 0; c < m_columnNum; ++c) {
                float x = c + 0.5f;
                float z = r + 0.5f;

                // top
                if (r != 0 && libMaze.ExistTopWall(r, c)) {
                    m_WallList.Add(
                        Instantiate(
                            Wall,
                            new Vector3(x, 0.5f, z - 0.5f),
                            Quaternion.Euler(0, 90, 0),
                            m_obstacleContainer.transform));
                }

                // left
                if (c != 0 && libMaze.ExistLeftWall(r, c)) {
                    m_WallList.Add(
                        Instantiate(
                            Wall,
                            new Vector3(x - 0.5f, 0.5f, z),
                            Quaternion.identity,
                            m_obstacleContainer.transform));
                }
            }
        }
    }
}
