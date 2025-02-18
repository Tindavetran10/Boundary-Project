using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if object has tag "Player" then ignore
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ignored Player");
            return;
        }

        // Check if object has tag "enemy" then perform action
        if (other.CompareTag("enemy"))
        {
            Debug.Log("Hit Enemy!");
            // Perform action when colliding with "enemy"
            HandleEnemyCollision(other.gameObject);
        }
    }

    private void HandleEnemyCollision(GameObject enemy)
    {
        Destroy(enemy);
    }
}
