using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDebugger : MonoBehaviour
{
    [SerializeField] Card card;

    private void Start()
    {
        Debug.Log(card.cardName);
        Debug.Log(card.lifePoints);
        Debug.Log(card.damages);
    }
}
