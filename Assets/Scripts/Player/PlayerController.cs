using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField][Range(1f, 10f)] private float dashSpeed = 4;
    [SerializeField][Range(100.0f, 1000.0f)] private float rotSpeed = 600.0f;
    [SerializeField] private float rotTime;
    private bool canRot = true;
    [SerializeField] private float dashTime;
    private bool canDash = true;
    private bool isDash = true;

    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        isDash = true;
        canDash = true;
        canRot = true;
        rigid2D.velocity = transform.up * 4f;
        rigid2D.gravityScale = 0.3f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) Rotation();
        if (Input.GetKeyDown(KeyCode.J)) Dash();
        if (isDash) transform.up = rigid2D.velocity;
    }

    public void Rotation()
    {
        if (canRot && enabled)
        {
            canRot = false;
            StartCoroutine(RotCoolTime());
            isDash = false;
            rigid2D.angularVelocity = rotSpeed;
        }
    }

    public void Dash()
    {
        if (canDash && enabled)
        {
            canDash = false;
            StartCoroutine(DashCoolTime());
            rigid2D.velocity = transform.up * dashSpeed;
            rigid2D.angularVelocity = 0f;
            isDash = true;
        }
    }

    IEnumerator RotCoolTime()
    {
        yield return new WaitForSeconds(rotTime);
        canRot = true;
    }
    IEnumerator DashCoolTime()
    {
        yield return new WaitForSeconds(dashTime);
        canDash = true;
    }
}
