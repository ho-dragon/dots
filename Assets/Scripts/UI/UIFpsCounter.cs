using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIFpsCounter : MonoBehaviour
{
    [FormerlySerializedAs("Text")] public Text text;
    float frames = 0.0f;
    float timeElap = 0.0f;
    float frameTime = 0.0f;
    float totalTime = 0.0f;
    Color colorWarnning = new Color(213f/255, 100f/255, 0f);

    void Update()
    {
        if (Application.isPlaying == false)
        {
            return;
        }

        frames++;
        timeElap += Time.unscaledDeltaTime;
        totalTime += Time.unscaledDeltaTime;

        if (timeElap > 1.0f)
        {
            frameTime = timeElap / (float) frames;
            timeElap -= 1.0f;
            UpdateText();
            frames = 0.0f;
        }
    }

    void UpdateText()
    {
        if (frames <= 20)
        {
            text.color = Color.red;
        }
        else if (frames <= 30)
        {
            text.color = colorWarnning;
        }
        else if (frames <= 40)
        {
            text.color = Color.yellow;
        }
        else
        {
            text.color = Color.green;
        }
        text.text = string.Format("FPS : {0}, FrameTime : {1:F2} ms, PlayTime : {2:F1}", frames, frameTime * 1000.0f, totalTime);
    }
}
