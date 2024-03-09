using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int NumOfHearts;

    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    private void Awake()
    {
        GameEvents.OnHealthChange += UpdateHealth;

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < NumOfHearts)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }
    }

    private void UpdateHealth(int health)
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < health)
            {
                Hearts[i].sprite = FullHeart;
            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }
        }
    }
}
