using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField]private AudioSource audioSource;
    [SerializeField] private AudioClip playerDieSound;
    void OnEnable()
    {
        Player.PlayerDie += ShowAudioGameOver;
        //Enemy.EnemyDie += ShowAudioGameOver;
    }
    private void OnDestroy()
    {
        Player.PlayerDie -= ShowAudioGameOver;
        //Enemy.EnemyDie -= ShowAudioGameOver;
    }
    private void ShowAudioGameOver()
    {
        Debug.Log("audio đã được bật");
    }
}
