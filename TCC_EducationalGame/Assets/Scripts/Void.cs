using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Void : MonoBehaviour
{
    [Header("Respawn related")]
    [SerializeField] private Vector3 respawnPoint;

    private void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health >=0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health--;
                StartCoroutine(PlayerRespawning());
                
            }

            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health < 0)
            {
                //Here comes the "Game Over"
            }
        }
    }

    IEnumerator PlayerRespawning()
    {
        yield return new WaitForSeconds(0.18f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = respawnPoint;
    }
}
