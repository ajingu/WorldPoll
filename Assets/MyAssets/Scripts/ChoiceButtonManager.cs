using System;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule.Tests;

namespace HoloToolkit.Unity.InputModule {
    public class ChoiceButtonManager : MonoBehaviour, IInputClickHandler
    {
        [SerializeField]
        Text choiceText;

        [SerializeField]
        TextMesh answerText;

        [SerializeField]
        TestButton button;

        private string fixedPhrase = "Your choice is <color='red'>{0}</color>.";

        public void OnInputClicked(InputClickedEventData eventData) {
            button.Selected = false;
            button.Focused = false; 
            answerText.text = String.Format(fixedPhrase, choiceText.text);
            AnswerManager.currentAnswer = choiceText.text;
            eventData.Use();
        }
    }
}

