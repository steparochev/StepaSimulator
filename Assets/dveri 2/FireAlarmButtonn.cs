using UnityEngine;

public class FireAlarmButtonn : MonoBehaviour
{
    [Header("��������� ������")]
    public Animator buttonAnimator;
    public float cooldown = 2f; // �������� ����� ���������

    private bool isPressed = false;
    private float lastPressTime;
    private static readonly int ISBolHash = Animator.StringToHash("ISBol");

    void Update()
    {
        // ��������� ������� ������� E
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
            {
                TryPressButton();
            }
        }
    }

    void OnMouseDown() // ��� �������������� ����� ����
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
        // �������� ������� (������������� �������� � true)
        buttonAnimator.SetBool(ISBolHash, true);
        isPressed = true;
        lastPressTime = Time.time;

        Debug.Log("������ ������");
    }

    // ����� ��� �������� ������ � �������� ���������
    public void ReleaseButton()
    {
        if (!isPressed) return;

        // ���������� �������� � false
        buttonAnimator.SetBool(ISBolHash, false);
        isPressed = false;
    }
}