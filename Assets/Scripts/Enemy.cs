using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float waitForDelay = 3f;
    [SerializeField] float destoryTime = 30f;

    MeshRenderer m_Renderer;
    Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        m_Renderer.enabled = false;
        m_Rigidbody.useGravity = false;
    }

    private void Update()
    {
        if(tag == "Enemy")
        {
            if(GameManager.instance.playTime > waitForDelay)
            {
                m_Renderer.enabled = true;
                m_Rigidbody.useGravity = true;
            }
        }

        if(GameManager.instance.playTime > destoryTime)
        {
            Destroy(gameObject);
        }
    }
}
