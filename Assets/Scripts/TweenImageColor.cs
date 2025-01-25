using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TweenImageColor : MonoBehaviour
{

    public float blinkSpeed;//閃爍速度
    private bool isAddAlpha;//是否增加透明度
    private float timer;
    private float timeval=0.7f;//時間間隔


    private Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (isAddAlpha)
        {
            img.color += new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
            if (timer >= timeval)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
                isAddAlpha = false;
                timer = 0;
            }
        }
        else
        {
            img.color -= new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
            if (timer >= timeval)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
                isAddAlpha = true;
                timer = 0;
            }
        }
    }


}
