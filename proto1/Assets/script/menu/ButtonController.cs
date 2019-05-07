using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void LoadLvl(int index)
    {
        SceneManager.LoadScene(index);
    }


}
