using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.ResourceProviders;

public class ChangeSceneButton : MonoBehaviour
{
    public Button changeSceneButton; // Ссылка на вашу кнопку
    public AssetReference nextSceneReference; // Ссылка на следующую адресуемую сцену

    private AsyncOperationHandle<SceneInstance> sceneLoadHandle;

    private void Start()
    {
        // Присваиваем обработчик события кнопке
        changeSceneButton.onClick.AddListener(LoadNextScene);
    }

    private void LoadNextScene()
    {
        // Проверяем, что обработчик сцены уже не занят
        if (sceneLoadHandle.IsValid())
        {
            Addressables.Release(sceneLoadHandle);
        }
        nextSceneReference.LoadSceneAsync();
    }
}
