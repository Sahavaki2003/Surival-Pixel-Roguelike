
// using UnityEngine;

// public class InstantiateTest : MonoBehaviour
// {
//     [SerializeField] private GameObject prefab;
//     [SerializeField] private float speed = 5f;
//     [SerializeField] private float spawnInterval = 0.5f;

//     private float timer;

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {

//             timer += Time.deltaTime;

//             if (timer >= spawnInterval)
//             {
//                 Instantiate(prefab, transform.position, Quaternion.identity);
//                 timer = 0f;
//             }
//         }
//     }
// }
