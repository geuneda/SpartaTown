using UnityEngine;
using UnityEngine.SceneManagement;

public class SpartaTownCharacterSeleteSystem : MonoBehaviour
{
    public void StartMainScene(int index)
    {
        GameManager.Instance.SetselectedCharacterIndex(index);
        SceneManager.LoadScene("MainScene");
    }
}