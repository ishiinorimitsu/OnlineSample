using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class AvataController : MonoBehaviourPunCallbacks ,IPunObservable      // MonoBehaviourPunCallbacks���p�����āAphotonView�v���p�e�B���g����悤�ɂ���
{
    private const float MaxStamina = 6f;       //const�́A���̒l���Œ肷��Ƃ����Ӗ�(�ϐ�)

    [SerializeField]
    private Image staminaBar = default;

    private float currentStamina = MaxStamina;

    void Update()
    {
        // ���g�����������I�u�W�F�N�g�����Ɉړ��������s��
        if (photonView.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

            if(input.sqrMagnitude > 0)      //��������Magnitude��Vector3�̊e�l��2�悵�đ����ă��[�g����Bsqr�������ق�������
            {
                currentStamina = Mathf.Max(0f, currentStamina - Time.deltaTime);        //�傫���ق��̒l��Ԃ��BcurrentStamina��0�ȉ��ɂȂ�Ƃ���0�̂ق���Ԃ�

                transform.Translate(6 * Time.deltaTime * input.normalized);
            }
            else
            {
                currentStamina = Mathf.Min(currentStamina + Time.deltaTime*2,MaxStamina);       //�傫���ق��̒l��Ԃ��BcurrentStamina��MaxStamina�ȉ��ɂȂ�Ƃ���MaxStamina�̂ق���Ԃ�
            }
        }

        //�X�^�~�i���Q�[�W�ɔ��f������
        staminaBar.fillAmount = currentStamina / MaxStamina;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)      //���������������������Q�[���I�u�W�F�N�g�A�������͂킩��Ȃ�
    {
        if (stream.IsWriting)       //�����i�������j�����𑗂鑤�̎�
        {
            stream.SendNext(currentStamina);
        }
        else
        {
            currentStamina = (float)stream.ReceiveNext();
        }
    }
}
