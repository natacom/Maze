using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private float m_t = 0;
    private float m_dy = 0.0f;
    private float m_y;

    // Start is called before the first frame update
    void Start()
    {
        m_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        m_t += Time.deltaTime;

        m_dy = Mathf.Sin(m_t) * 0.1f;
        transform.position = new Vector3(
            transform.position.x, m_y + m_dy, transform.position.z);
    }
}
