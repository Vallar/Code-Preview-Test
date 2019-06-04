using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpdateText : MonoBehaviour
{
    [Header("Event Setup")]
    [SerializeField] private GameEvent treatDropped;
    [SerializeField] private GameEvent treatDelivered;
    [Space]
    [Header("Messages")]
    [SerializeField] private string treatDroppedMessage;
    [SerializeField] private string treatDeliveredMessage;
    [Space]
    [Header("GUI Setup")]
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TMPro.TextMeshProUGUI statusMessage;
    private WaitForSeconds waitTime = new WaitForSeconds(2);

    private void OnEnable()
    {
        treatDropped.gameEvent.AddListener(DisplayTreatDroppedMessage);
        treatDelivered.gameEvent.AddListener(DisplayTreatDeliveredMessage);
    }

    private void DisplayTreatDroppedMessage()
    {
        StartCoroutine(ShowMessage(treatDroppedMessage));
    }

    private void DisplayTreatDeliveredMessage()
    {
        StartCoroutine(ShowMessage(treatDeliveredMessage));
    }

    private IEnumerator ShowMessage(string _message)
    {
        statusMessage.text = _message;
        messagePanel.SetActive(true);

        yield return waitTime;

        messagePanel.SetActive(false);
    }

    private void OnDisable()
    {
        treatDropped.gameEvent.RemoveListener(DisplayTreatDroppedMessage);
        treatDelivered.gameEvent.RemoveListener(DisplayTreatDeliveredMessage);
    }
}
