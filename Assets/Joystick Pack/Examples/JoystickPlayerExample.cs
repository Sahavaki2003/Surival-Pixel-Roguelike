using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed = 5f;
    public VariableJoystick variableJoystick;

    [Header("Character Visual")]
    [SerializeField] private Transform characterVisual;

    private void Update()
    {
        Vector3 direction = new Vector3(variableJoystick.Horizontal,variableJoystick.Vertical,0f);

        transform.position += direction.normalized * speed * Time.deltaTime;
        // Xoay mặt nhân vật theo trái/phải của joystick
        if (variableJoystick.Horizontal > 0.1f)
        {
            // Quay mặt sang phải
            characterVisual.localScale = new Vector3(
                Mathf.Abs(characterVisual.localScale.x),
                characterVisual.localScale.y,
                characterVisual.localScale.z
            );
        }
        else if (variableJoystick.Horizontal < -0.1f)
        {
            // Quay mặt sang trái
            characterVisual.localScale = new Vector3(
                -Mathf.Abs(characterVisual.localScale.x),
                characterVisual.localScale.y,
                characterVisual.localScale.z
            );
        }
    }
}