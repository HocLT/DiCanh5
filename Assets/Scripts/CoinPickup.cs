using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField]
    int pointsForCoinPickup = 10;

    bool coinCollected = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !coinCollected)
        {
            coinCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            Destroy(gameObject);
        }
    }
}
