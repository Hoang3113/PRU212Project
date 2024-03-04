using UnityEngine;
using UnityEngine.UI;

public class CoinsCollector : MonoBehaviour
{
    public static CoinsCollector intance;
    public Text coinsText;
    public int coins = 0;

    private void Awake()
    {
        intance = this;
    }
    private void Start()
    {
        coinsText.text= coins.ToString();
    }
    public void UpdateCoints(int v)
    {
        coins += v;
        coinsText.text = coins.ToString();
    }
    public void CoinsUpdate(int amount = 0)
    {
        coins = amount;
    }
}
