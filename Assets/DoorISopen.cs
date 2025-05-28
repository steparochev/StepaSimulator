using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorISopen : MonoBehaviour
{
    [Header("��������� �����")]
    public Animator doorAnimator;
    public string boolParameter = "IsOpen"; // �������� � ���������
    public float openDistance = 3f; // ��������� ������������

    [Header("����")]
    public Transform player; // ������ �� ������
    private bool playerNearby = false;

    void Start()
    {
        if (doorAnimator == null)
            doorAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        // ��������� ��������� �� ������
        float distance = Vector3.Distance(transform.position, player.position);
        bool shouldOpen = distance <= openDistance;

        // ���� ��������� ����������
        if (shouldOpen != playerNearby)
        {
            playerNearby = shouldOpen;
            doorAnimator.SetBool(boolParameter, shouldOpen);

            // �����������: ���� ��������/��������
            Debug.Log(playerNearby ? "����� �����������" : "����� �����������");
        }
    }

    // ������������ ���� ������������ � ���������
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, openDistance);
    }
}