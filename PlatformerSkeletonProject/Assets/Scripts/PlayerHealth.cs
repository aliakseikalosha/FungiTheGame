using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    private bool isInvincible = false;
    [SerializeField] private AudioClip getHurt;
    [SerializeField] private AudioSource audioSource;

    IEnumerator GetInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(3);
        isInvincible = false;
    }

    public void GetHurt()
    {
        if (isInvincible)
        {
            return;
        }
        health--;
        GameEvents.UpdateHealth(health);
        StartCoroutine(GetInvincible());
        audioSource.PlayOneShot(getHurt);

        if (health == 0)
        {
            GameEvents.PlayerDie();
        }
    }
}
