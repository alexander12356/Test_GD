using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VNCreator
{
    public class VNCreator_EndScreen : MonoBehaviour
    {
        public Button mainMenuButton;
        [Scene]
        public string mainMenu;

        public event Action OnComplete;

        void Start()
        {
            mainMenuButton.onClick.AddListener(MainMenu);
        }

        void MainMenu()
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            OnComplete?.Invoke();
        }
    }
}
