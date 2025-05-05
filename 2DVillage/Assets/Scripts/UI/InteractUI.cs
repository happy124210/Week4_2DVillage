using System;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private GameObject interactPrompt;

    private void Start()
    {
        interactPrompt.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            interactPrompt.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            interactPrompt.SetActive(false);
    }

}
