using System;
using UnityEngine;
using VNCreator;

namespace Test_GD.Scripts
{
	public class VNManager : MonoBehaviour
	{
		public static VNManager Instance;

		[SerializeField] private VNCreator_DisplayUI _displayUI;
		[SerializeField] private VNCreator_EndScreen _endScreen;

		public event Action OnDialogComplete;

		private void Awake()
		{
			Instance = this;
			_endScreen.OnComplete += HandleDialogComplete;
		}

		private void OnDestroy()
		{
			_endScreen.OnComplete -= HandleDialogComplete;
		}

		public void StartDialog(StoryObject storyObject)
		{
			_displayUI.story = storyObject;
			_displayUI.gameObject.SetActive(true);
		}

		public void HandleDialogComplete()
		{
			OnDialogComplete?.Invoke();
		}
	}
}