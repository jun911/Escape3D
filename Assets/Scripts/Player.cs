using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float rotationSpeed = 10f;
    public float hitScore = 0f;

    Animator animator;
    State state;

    enum State
    {
        IDLE,
        MOVE,
        ATTACK,
        DEAD
    }


    private void Awake()
    {
        animator = GetComponent<Animator>();
        state = State.IDLE;
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.IDLE:
                UpdateMove();
                break;
            case State.MOVE:
                UpdateMove();
                break;
            default:
                break;
        }
    }

    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = 0f;
        float z = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(x, y, z);

        float vecMagnitude = vec.magnitude;

        // 이동
        transform.position = transform.position + (vec * speed * Time.fixedDeltaTime);

        // 회전
        if (vecMagnitude > 0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(vec), Time.deltaTime * rotationSpeed);
        }

        // 애니메이션 변경
        animator.SetFloat("Speed", vecMagnitude);

        state = State.MOVE;
    }
}
