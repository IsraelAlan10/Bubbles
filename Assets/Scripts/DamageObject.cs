using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) {
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamage();
        }
    }
}
