using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _timeText;
    private float _time = 0;

    private void Start()
    {
        StartCoroutine("StartTimeCounter");
    }

    private IEnumerator StartTimeCounter()
    {
        var waitTime = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return waitTime;
            _time += 0.1f;
            _timeText.text = "Time : " + _time.ToString("F1");
        }
    }

    public float GetScore()
    {
        return _time;
    }

}
