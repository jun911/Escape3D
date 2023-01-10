using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    Enemy enemy;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                
                if(gameObject.tag == "Wall")
                {
                    Debug.Log("Wall hit!");
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                }

                if(gameObject.tag == "Enemy")
                {
                    gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    gameObject.tag = "Hit";
                    GameManager.instance.player.hitScore++;
                }

                if (gameObject.tag == "EnemyApproachSpawn")
                {
                    gameObject.tag = "Enemy";
                }

                break;
            case "Enemy":
                if (gameObject.tag == "Wall")
                {
                    Destroy(collision.gameObject);
                }

                break;
            default:
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":

                if (gameObject.tag == "Wall")
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                }


                break;
            default:
                break;
        }
    }
}
