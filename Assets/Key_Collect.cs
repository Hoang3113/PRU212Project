using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Key_Collect : MonoBehaviour
{
    public Text KeyText;
    private string keySaveKey = "SavedKey"; // Khóa lưu trữ số key trong PlayerPrefs

    void Start()
    {
        // Reset số key và trạng thái của các rương chest về trạng thái ban đầu mỗi khi game bắt đầu
        ResetGame();
    }

    private void UpdateKeyText()
    {
        KeyText.text = GetKey().ToString();
    }

    public int GetKey()
    {
        return PlayerPrefs.GetInt(keySaveKey, 0); // Lấy giá trị số key từ PlayerPrefs
    }

    public void SetKey(int value)
    {
        PlayerPrefs.SetInt(keySaveKey, value); // Lưu giá trị số key vào PlayerPrefs
        UpdateKeyText(); // Cập nhật hiển thị số key
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            string chestName = collision.gameObject.name; // Lấy tên của chest
            string chestKey = chestName + "Opened"; // Tạo khóa lưu trữ trạng thái của chest

            if (!PlayerPrefs.HasKey(chestKey)) // Kiểm tra xem chest đã được mở chưa
            {
                int currentKey = GetKey(); // Lấy giá trị hiện tại của số key
                SetKey(currentKey + 1); 
                PlayerPrefs.SetInt(chestKey, 1); 
            }
        }
    }

    public void ResetGame()
    {
       
    }
}
