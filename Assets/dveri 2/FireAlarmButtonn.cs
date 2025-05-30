using UnityEngine;

public class FireAlarmButtonn : MonoBehaviour
{
    [Header("Настройки кнопки")]
    public Animator buttonAnimator;
    public float cooldown = 2f; // Задержка между нажатиями

    private bool isPressed = false;
    private float lastPressTime;
    private static readonly int ISBolHash = Animator.StringToHash("ISBol");

    void Update()
    {
        // Обработка нажатия клавиши E
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
            {
                TryPressButton();
            }
        }
    }

    void OnMouseDown() // Для взаимодействия через клик
    {
        TryPressButton();
    }

    public void TryPressButton()
    {
        if (isPressed || Time.time - lastPressTime < cooldown) return;

        PressButton();
    }

    void PressButton()
    {
        // Анимация нажатия (устанавливаем параметр в true)
        buttonAnimator.SetBool(ISBolHash, true);
        isPressed = true;
        lastPressTime = Time.time;

        Debug.Log("Кнопка нажата");
    }

    // Метод для возврата кнопки в исходное состояние
    public void ReleaseButton()
    {
        if (!isPressed) return;

        // Возвращаем параметр в false
        buttonAnimator.SetBool(ISBolHash, false);
        isPressed = false;
    }
}