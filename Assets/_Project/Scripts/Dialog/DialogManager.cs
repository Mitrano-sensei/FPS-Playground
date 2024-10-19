using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Utilities;

namespace FPSPlayground
{
    public class DialogManager : Singleton<DialogManager>
    {
        [SerializeField] private MMF_Player showDialogFeedbacks;
        [SerializeField] private TextMeshProUGUI dialogText;

        private DialogObject _currentDialog;
        private int _currentSentenceIndex;

        #region UI
        private void ShowDialogUI()
        {
            showDialogFeedbacks.SetDirectionTopToBottom();
            showDialogFeedbacks.PlayFeedbacks();
        }

        private void HideDialogUI()
        {
            showDialogFeedbacks.SetDirectionBottomToTop();
            showDialogFeedbacks.PlayFeedbacks();
        }

        private void SetDialogText(string text)
        {
            dialogText.text = text;
        }
        #endregion

        public void OnNPCInteraction(DialogObject dialog)
        {
            if (_currentDialog == null)
            {
                StartDialog(dialog);
            }
            else
            {
                NextSentence();
            }

        }

        private void StartDialog(DialogObject dialog)
        {
            _currentDialog = dialog;
            _currentSentenceIndex = 0;

            ShowDialogUI();
            ShowSentence(_currentSentenceIndex);
        }

        private void NextSentence()
        {
            _currentSentenceIndex++;
            if (_currentSentenceIndex < _currentDialog.Sentences.Length)
            {
                ShowSentence(_currentSentenceIndex);
            }
            else
            {
                EndDialog();
            }
        }

        private void ShowSentence(int index)
        {
            SetDialogText(_currentDialog.Sentences[index]);
        }

        public void EndDialog()
        {
            HideDialogUI();
            _currentDialog = null;
            _currentSentenceIndex = 0;
        }
    }


}
