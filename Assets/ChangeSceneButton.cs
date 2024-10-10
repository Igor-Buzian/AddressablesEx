using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.ResourceProviders;

public class ChangeSceneButton : MonoBehaviour
{
    public Button changeSceneButton; // ������ �� ���� ������
    public AssetReference nextSceneReference; // ������ �� ��������� ���������� �����

    private AsyncOperationHandle<SceneInstance> sceneLoadHandle;

    private void Start()
    {
        // ����������� ���������� ������� ������
        changeSceneButton.onClick.AddListener(LoadNextScene);
    }

    private void LoadNextScene()
    {
        // ���������, ��� ���������� ����� ��� �� �����
        if (sceneLoadHandle.IsValid())
        {
            Addressables.Release(sceneLoadHandle);
        }
        nextSceneReference.LoadSceneAsync();
    }
}
