using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class sign : MonoBehaviour
{
    public GameObject dialogBubble;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool playerInRange;


    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && playerInRange)
        {
            if (dialogBubble.activeInHierarchy)
            {
                dialogBubble.SetActive(false);
            }
            else
            {
                dialogBubble.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBubble.SetActive(false);
        }
    }
}

