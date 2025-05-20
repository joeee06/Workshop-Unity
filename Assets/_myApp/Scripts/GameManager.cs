using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeCounter = 10f; // Time count variable
    public ItemData targetItem;
    public int targetAmout = 5;

    public TMP_Text timeCountText; // Text to display the time count
    public Image targetItemIcon;
    public TMP_Text targetCurrentAmountText;

    public bool isPlayerWin = false; // Variable to check if the player has won

    public GameObject winPanel;
    public GameObject losePanel;

    private void Start()
    {
        targetItemIcon.sprite = targetItem.itemIcon; // Set the target item icon
    }

    private void Awake()
    {
       if(Instance == null)
        {
            Instance = this;            
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public InventoryPanel inventoryPanel;

    public void OpenInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.OnOpen();                    // Call the OnOpen method to populate the inventory panel with items
        Cursor.visible = true;                      // When Opening the inventory, make the cursor visible
        Cursor.lockState = CursorLockMode.None;     // When Opening the inventory, unlock the cursor

        Time.timeScale = 0f;                        // Pause the game when opening the inventory
    }

    public void CloseInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(false);
        Cursor.visible = false;                     // When closing the inventory, hide the cursor
        Cursor.lockState = CursorLockMode.Locked;   // When closing the inventory, lock the cursor

        Time.timeScale = 1f;                        // Resume the game when closing the inventory
    }

    private void Update()
    {
        if (isPlayerWin)
        {
            return;
        }
        Cursor.visible = false;                     // When closing the inventory, hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        if (timeCounter > 0f)
        {
            timeCounter -= Time.deltaTime;
            timeCountText.text = timeCounter.ToString(); // Update the time count text
            targetCurrentAmountText.text = "x" + (targetAmout - InventoryManager.instance.GetItemAmout(targetItem)).ToString(); // Update the target item amount text

            if (InventoryManager.instance.GetItemAmout(targetItem) >= targetAmout)
            {
                Debug.Log("You win!"); // Display a message when the target item amount is reached
                isPlayerWin = true; // Set the win condition to true
                winPanel.SetActive(true);
                Cursor.visible = true;                      // When Opening the inventory, make the cursor visible
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            losePanel.SetActive(true);
            Cursor.visible = true;                      // When Opening the inventory, make the cursor visible
            Cursor.lockState = CursorLockMode.None;     // When Opening the inventory, unlock the cursor

        }
    }
}
