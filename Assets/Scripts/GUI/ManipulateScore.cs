using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateScore : MonoBehaviour
{
    [SerializeField] private GameEvent treatDelivered;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private IntVariable score;

    private void OnEnable()
    {
        treatDelivered.gameEvent.AddListener(UpdateScore);
    }

    private void UpdateScore()
    {
        scoreText.text = string.Format("Score: {0}", score.value);
    }
}
