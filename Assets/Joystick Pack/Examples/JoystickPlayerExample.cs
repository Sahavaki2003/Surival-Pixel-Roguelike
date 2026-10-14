using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed = 5f;
    public VariableJoystick variableJoystick;

    private void Update()
    {
        Vector3 direction = new Vector3(
            variableJoystick.Horizontal,
            variableJoystick.Vertical,
            0f
        );

        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}