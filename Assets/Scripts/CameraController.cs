using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private Transform m_farBackGround;
    [SerializeField] private Transform m_middleBackGround;

    //private float m_lastXPos;

    [SerializeField] private float m_minHeight, m_maxHeight;

    private Vector2 m_lastPos;

    // Start is called before the first frame update
    void Start()
    {
        //m_lastXPos = transform.position.x;
        m_lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(m_target.position.x, transform.position.y, transform.position.z);

        //float clampedY = Mathf.Clamp(transform.position.y, m_minHeight, m_maxHeight);
        //transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        transform.position = new Vector3(m_target.position.x, Mathf.Clamp(m_target.position.y, m_minHeight, m_maxHeight), transform.position.z);

        //float amountToMoveX = transform.position.x - m_lastXPos;

        Vector2 amountToMove = new Vector2(transform.position.x - m_lastPos.x, transform.position.y - m_lastPos.y);

        m_farBackGround.position = m_farBackGround.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        m_middleBackGround.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;
        //m_lastXPos = transform.position.x;
        m_lastPos = transform.position;
    }
}
