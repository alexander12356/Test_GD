using System.Collections;
using Test_GD.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using VNCreator;

public class StartDialogTrigger : MonoBehaviour
{
	[SerializeField] private bool _isOnceTriggered = false;
	[SerializeField] private StoryObject _storyObject;

	private bool _isTriggered;

	private void OnTriggerEnter(Collider other)
	{
		if (!_isTriggered)
		{
			_isTriggered = true;
			GameManager.Instance.StartDialog(_storyObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!_isOnceTriggered)
		{
			_isTriggered = false;
		}
	}
}