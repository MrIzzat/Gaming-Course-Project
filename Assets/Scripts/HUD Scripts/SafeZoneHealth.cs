using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeZoneHealth : MonoBehaviour
{
    public Image fill;
    public Slider safeZoneHealth;

    public int damagePerEnemy=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (safeZoneHealth.value <= 30)
        {
            fill.color = new Color(180, 0, 0);

        }
    }

    public void updateHealth()
    {
        safeZoneHealth.value -= damagePerEnemy;
    }


}
