using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameManager gameManager; // Tham chiếu đến GameManager

    private GameObject selectedObject;

    private void Start()
    {
        // Khôi phục đối tượng được chọn nếu có
        if (selectedObject != null)
        {
            selectedObject.GetComponent<Button>().Select();
        }
    }

    // Gọi hàm này khi một đối tượng được chọn
    public void OnObjectSelected(GameObject selectedObject)
    {
        this.selectedObject = selectedObject;
    }

    // Gọi hàm này khi chuyển từ Level1 về MainMenu
    public void OnBackToMainMenu()
    {
        // Cập nhật tham chiếu đến GameManager khi quay lại MainMenu
        gameManager = FindObjectOfType<GameManager>();
    }
}