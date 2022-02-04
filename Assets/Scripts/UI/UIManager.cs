using System;
using UnityEngine;

namespace UI
{
    public class UIManager : Singleton<UIManager>
    {
        public static event Action OnPauseButtonClicked;
        public static event Action OnResumeButtonClicked;
        public static event Action OnTapToRestartButtonClicked;
        public static event Action OnTapToContinueButtonClicked;

        [SerializeField] private GameObject pauseButton;
        [SerializeField] private GameObject resumeButton;
        [SerializeField] private GameObject tapToRestartUI;
        [SerializeField] private GameObject tapToContinueUI;
        
        private void OnEnable()
        {
            pauseButton.SetActive(false);
            resumeButton.SetActive(false);
            tapToRestartUI.SetActive(false);
            tapToContinueUI.SetActive(false);
        }

        public void ShowFailScreen()
        {
            pauseButton.SetActive(false);
            resumeButton.SetActive(false);
            tapToRestartUI.SetActive(true);
        }

        public void HandlePauseButtonClick()
        {
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);

            OnPauseButtonClicked?.Invoke();
        }

        public void HandleResumeButtonClick()
        {
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);

            OnResumeButtonClicked?.Invoke();
        }

        public void HandleTapToContinueClick()
        {
            tapToContinueUI.SetActive(false);
            
            OnTapToContinueButtonClicked?.Invoke();
        }

        public void HandleTapToRestartClick()
        {
            tapToRestartUI.SetActive(false);
            
            OnTapToRestartButtonClicked?.Invoke();
        }
    }
}
