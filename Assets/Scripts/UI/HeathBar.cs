using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public Goblin_Heath goblin_heath;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = goblin_heath.health; 
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = goblin_heath.health;
    }
}
