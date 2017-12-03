using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    public class CancelButtonManager : MonoBehaviour, IInputClickHandler
    {
        [SerializeField]
        GameObject[] choiceDescriptions;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            foreach (var choiceDescription in choiceDescriptions)
            {
                choiceDescription.SetActive(true);
            }

            eventData.Use();
        }
    }
}