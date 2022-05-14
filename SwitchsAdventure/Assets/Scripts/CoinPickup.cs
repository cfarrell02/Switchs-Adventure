using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUp;
    private void OnTriggerEnter2D()
    {
        AudioSource.PlayClipAtPoint(coinPickUp, Camera.main.transform.position);
        Destroy(gameObject);
        FindObjectOfType<GameSession>().AddToScore(10);
    }
}
