using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private Rigidbody2D m_RB;
    [SerializeField] private float m_JumpForce;

    private bool m_isGrounded;

    [SerializeField] private Transform m_groundCheckPoint;
    [SerializeField] private LayerMask m_whatIsGround;

    private bool m_canDoubleJump;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_RB.velocity = new Vector2(m_MoveSpeed * Input.GetAxis("Horizontal"), m_RB.velocity.y);

        m_isGrounded = Physics2D.OverlapCircle(m_groundCheckPoint.position, .2f, m_whatIsGround);

        if(m_isGrounded)
        {
            m_canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (m_isGrounded)
            {
                m_RB.velocity = new Vector2(m_RB.velocity.x, m_JumpForce);
            }
            else
            {
                if(m_canDoubleJump)
                {
                    m_RB.velocity = new Vector2(m_RB.velocity.x, m_JumpForce);
                    m_canDoubleJump = false;
                }
            }
        }
    }
}
