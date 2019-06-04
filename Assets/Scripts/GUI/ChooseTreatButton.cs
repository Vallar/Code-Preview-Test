using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseTreatButton : MonoBehaviour
{
    [SerializeField] private GameObject treat;
    [SerializeField] private GameObjectVariable treatChoice;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(ChooseTreat);
    }

    private void ChooseTreat()
    {
        treatChoice.value = treat;
        //SceneManager.LoadScene(1);
    }

    private void OnDisable()
    {
        button.onClick.AddListener(ChooseTreat);
    }

}
