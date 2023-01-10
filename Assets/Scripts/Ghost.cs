using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;

    private void FixedUpdate()
    {
        Vector3 dir = GameManager.instance.player.transform.position - transform.position;

        transform.position = transform.position + dir * speed * Time.fixedDeltaTime;

        float vecMagnitude = dir.magnitude;

        // È¸Àü
        if (vecMagnitude > 0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10f);
        }
    }
}
