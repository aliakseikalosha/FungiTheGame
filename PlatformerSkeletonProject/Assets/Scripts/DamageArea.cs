using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            collider.gameObject.GetComponent<PlayerHealth>().GetHurt();
        }
    }
}