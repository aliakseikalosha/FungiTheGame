using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFloor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform deathFloor;
    [SerializeField] private float minHeightToActivate;
    [SerializeField] private float speed = 1.0f;
    private bool hasPasMinHeight;

    private void Update()
    {
        if(minHeightToActivate < player.position.y)
        {
            hasPasMinHeight = true;
        }
        if (hasPasMinHeight)
        {
            deathFloor.position += Vector3.up * speed * Time.deltaTime;

            if (deathFloor.position.y > player.position.y)
            {
                GameEvents.PlayerDie();
            }
        }
    }
}
