using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private int score = 100;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player" && spriteRenderer.enabled)
        {
            GameEvents.AddScore(score);
            spriteRenderer.enabled = false;
            audioSource.Play();
            Invoke(nameof(Die), audioSource.clip.length);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
