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

    // Start is called before the first frame update
    void Start()
    {
        libMaze.Generate(10, 10);

        CreatePolls();
        CreateOuterWalls();
        CreateInnerWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatePolls()
    {
        for (int r = -5; r <= 5; ++r) {
            for (int c = -5; c <= 5; ++c) {
                m_PollList.Add(
                    GameObject.Instantiate(
                        Poll,
                        new Vector3(r, 0.5f, c),
                        Quaternion.identity,
                        m_obstacleContainer.transform));
            }
        }
    }

    private void CreateOuterWalls()
    {
        for (int n = 0; n < 10; ++n) {
            float basePos = -4.5f + n;
            // top
            m_WallList.Add(
                GameObject.Instantiate(
                    Wall,
                    new Vector3(basePos, 0.5f, -5),
                    Quaternion.Euler(0, 90, 0),
                    m_obstacleContainer.transform));
            // right
            m_WallList.Add(
                GameObject.Instantiate(
                    Wall,
                    new Vector3(5, 0.5f, basePos),
                    Quaternion.identity,
                    m_obstacleContainer.transform));
            // bottom
            m_WallList.Add(
                GameObject.Instantiate(
                    Wall,
                    new Vector3(basePos, 0.5f, 5),
                    Quaternion.Euler(0, 90, 0),
                    m_obstacleContainer.transform));
            // left
            m_WallList.Add(
                GameObject.Instantiate(
                    Wall,
                    new Vector3(-5, 0.5f, basePos),
                    Quaternion.identity,
                    m_obstacleContainer.transform));
        }
    }

    private void CreateInnerWalls()
    {
        for (int r = 0; r < 10; ++r) {
            for (int c = 0; c < 10; ++c) {
                float x = -4.5f + c;
                float z = -4.5f + r;

                // top
                if (r != 0 && libMaze.ExistTopWall(r, c)) {
                    m_WallList.Add(
                        GameObject.Instantiate(
                            Wall,
                            new Vector3(x, 0.5f, z - 0.5f),
                            Quaternion.Euler(0, 90, 0),
                            m_obstacleContainer.transform));
                }

                // left
                if (c != 0 && libMaze.ExistLeftWall(r, c)) {
                    m_WallList.Add(
                        GameObject.Instantiate(
                            Wall,
                            new Vector3(x - 0.5f, 0.5f, z),
                            Quaternion.identity,
                            m_obstacleContainer.transform));
                }
            }
        }
    }
}
