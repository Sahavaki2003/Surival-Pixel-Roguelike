using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]private GameObject UIManager;
    void OnEnable()
    {
        Player.PlayerDie += ShowUIGameOver;
    }
    private void OnDestroy()
    {
        Player.PlayerDie -= ShowUIGameOver;
    }
    private void ShowUIGameOver()
    {
        UIManager.SetActive(true);
        Debug.Log("Ui đã được bật");
    }
}
