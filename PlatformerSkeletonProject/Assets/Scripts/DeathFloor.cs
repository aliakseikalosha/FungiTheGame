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

    private void Awake()
    {
        deathFloor.gameObject.SetActive(false);
        Debug.Log("Debug turn off", deathFloor);
    }

    private void Update()
    {
        if(minHeightToActivate < player.position.y)
        {
            hasPasMinHeight = true;
            deathFloor.gameObject.SetActive(true);
            Debug.Log("Debug turn on", deathFloor);
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
