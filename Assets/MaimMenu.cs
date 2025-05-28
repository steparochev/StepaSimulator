using UnityEngine;
using UnityEngine.SceneManagement;

public class MaimMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Debug.Log("���� ��������");
        Application.Quit();
    }
}