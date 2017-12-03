using UnityEngine;



namespace HoloToolkit.Unity.InputModule
{
    public class VoteButtonManager : MonoBehaviour, IInputClickHandler
    {

        [SerializeField]
        PositionDeterminer positionDeterminer;

        [SerializeField]
        GameObject polledUI;

        [SerializeField]
        GameObject notPolledUI;

        [SerializeField]
        PanelManager panelManager;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            positionDeterminer.Arrange(MaterialManager.GetMaterial(AnswerManager.currentAnswer));
            panelManager.isVoted = true;
            notPolledUI.SetActive(false);
            polledUI.SetActive(true);
            RatioManager.UpdateRatio(AnswerManager.currentAnswer);
            eventData.Use();
        }
    }
}
