using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using VNCreator;

namespace Test_GD.Scripts
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance;

		[SerializeField, Scene] private string _dialogScene;
		[SerializeField] private PlayerInput _playerInput;

		private void Awake()
		{
			Instance = this;
		}

		public void StartDialog(StoryObject storyObject)
		{
			StartCoroutine(StartDialogCoroutine(storyObject));
			return;

			IEnumerator StartDialogCoroutine(StoryObject lStoryObject)
			{
				var op = SceneManager.LoadSceneAsync(_dialogScene, LoadSceneMode.Additive);
				yield return new WaitUntil(() => op.isDone);
				SceneManager.SetActiveScene(SceneManager.GetSceneByPath(_dialogScene));
				VNManager.Instance.StartDialog(lStoryObject);

				_playerInput.DeactivateInput();
				VNManager.Instance.OnDialogComplete += () => { _playerInput.ActivateInput(); };
			}
		}
	}
}