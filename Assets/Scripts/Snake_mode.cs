using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake_mode : MonoBehaviour
{
   public void Default_Snake()
   {
        SceneManager.LoadScene("Snake");
   }

   public void Hard_Snake()
   {
        SceneManager.LoadScene("Hard_Snake");
   }
}