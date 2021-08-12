using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float JumpAmount;
    public float MoveAmount;
    public float RotationAmount;

    private Rigidbody m_rigid;

    public bool m_isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        m_rigid.angularVelocity = Vector3.zero;
        if (!m_isJumping) {
            m_rigid.velocity = Vector3.zero;
            // Move
            if (Input.GetKey(KeyCode.W)) {          // Forward
                m_rigid.velocity = transform.forward * MoveAmount;
            }
            else if (Input.GetKey(KeyCode.S)) {     // Back
                m_rigid.velocity = transform.forward * -MoveAmount;
            }
            if (Input.GetKey(KeyCode.D)) {          // Right
                m_rigid.velocity = transform.right * MoveAmount;
            }
            else if (Input.GetKey(KeyCode.A)) {     // Left
                m_rigid.velocity = transform.right * -MoveAmount;
            }

            // Rotate
            if (Input.GetKey(KeyCode.RightArrow)) {     // Right
                m_rigid.rotation = Quaternion.Euler(
                    m_rigid.rotation.eulerAngles.x,
                    m_rigid.rotation.eulerAngles.y + RotationAmount,
                    m_rigid.rotation.eulerAngles.z);
            }
            else if (Input.GetKey(KeyCode.LeftArrow)) { // Left
                m_rigid.rotation = Quaternion.Euler(
                    m_rigid.rotation.eulerAngles.x,
                    m_rigid.rotation.eulerAngles.y - RotationAmount,
                    m_rigid.rotation.eulerAngles.z);
            }

            // Jump
            if (Input.GetKeyDown(KeyCode.Space)) {      // Jump
                m_rigid.AddForce(Vector3.up * JumpAmount);
                m_isJumping = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor") {
            m_isJumping = false;
        }

        if (collision.transform.tag == "Finish") {
            SceneManager.LoadScene("Goal");
        }
    }
}
