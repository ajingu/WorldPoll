using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace HoloToolkit.Unity.InputModule
{
    public class PanelManager : MonoBehaviour
    {

        [SerializeField]
        GameObject[] choicePanels;

        [SerializeField]
        GameObject votePanel;

        public bool isVoted;

        void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => votePanel.activeInHierarchy)
                .Subscribe(_ =>
                {
                    foreach (var choicePanel in choicePanels)
                    {
                        choicePanel.SetActive(false);
                    }
                });

            this.UpdateAsObservable()
                .Where(_ => !votePanel.activeInHierarchy && !isVoted)
                .Subscribe(_ =>
                {
                    foreach (var choicePanel in choicePanels)
                    {
                        choicePanel.SetActive(true);
                    }
                });
        }
    }
}
