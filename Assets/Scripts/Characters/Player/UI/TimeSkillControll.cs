using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TimeSkillControll : MonoBehaviour
{
    public static TimeSkillControll TimeSkillInstance;

    [field: Header("Basic Attack")]
    Image lightAttackState_Img;
    float coolDwnTime1 = 1f;
    public bool isCoolDwn1 = false;

    [field: Header("Magma Strike")]
    Image magmaStrikeState_Img;
    float coolDwnTime2 = 4f;
    public bool isCoolDwn2 = false;

    [field: Header("Electro Nova")]
    Image electroNovaState_Img;
    float coolDwnTime3 = 6f;
    public bool isCoolDwn3 = false;

    [field: Header("Celestial Tempest")]
    Image celestialTempestState_Img;
    float coolDwnTime4 = 8f;
    public bool isCoolDwn4 = false;

    [field: Header("Flaming Dragon Roar Strike")]
    Image flamingDragonRoarStrikeState_Img;
    float coolDwnTime5 = 10f;
    public bool isCoolDwn5 = false;

    // Start is called before the first frame update
    void Start()
    {
        if (TimeSkillInstance != null && TimeSkillInstance != this)
        {
            Destroy(TimeSkillInstance);
        }
        else
        {
            TimeSkillInstance = this;
        }

        lightAttackState_Img = Player.PlayerInstance.lightAttackImg;
        lightAttackState_Img.fillAmount = 0;
        Debug.Log("Kich hoat");

        magmaStrikeState_Img = Player.PlayerInstance.magmaStrikeImg;
        magmaStrikeState_Img.fillAmount = 0;

        electroNovaState_Img = Player.PlayerInstance.electroNovaImg;
        electroNovaState_Img.fillAmount = 0;

        celestialTempestState_Img = Player.PlayerInstance.celestialTempestImg;
        celestialTempestState_Img.fillAmount = 0;

        flamingDragonRoarStrikeState_Img = Player.PlayerInstance.flamingDragonRoarStrikeImg;
        flamingDragonRoarStrikeState_Img.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LightAttackStateImage();

        MagmaStrikeStateImg();

        ElectroNovaStateImg();

        CelestialTempestStateImg();

        FlamingDragonRoarStrikeStateImg();
    }

    void LightAttackStateImage()
    {
        if (lightAttackState_Img == null)
        {
            Debug.Log("Khong tim thay");
            return;
        }

        if (Player.PlayerInstance.Input.PlayerActions.LightAttack.WasPressedThisFrame() && isCoolDwn1 == false)
        {
            isCoolDwn1 = true;
            Debug.Log("dem nguoc");
            lightAttackState_Img.fillAmount = 1;
        }

        if (isCoolDwn1)
        {
            lightAttackState_Img.fillAmount -= 1 / coolDwnTime1 * Time.deltaTime;

            if (lightAttackState_Img.fillAmount <= 0)
            {
                lightAttackState_Img.fillAmount = 0;
                isCoolDwn1 = false;
            }
        }
    }

    void MagmaStrikeStateImg()
    {
        if (Player.PlayerInstance.Input.PlayerActions.Skill1.WasPressedThisFrame() && isCoolDwn2 == false)
        {
            isCoolDwn2 = true;
            magmaStrikeState_Img.fillAmount = 1;
        }

        if (isCoolDwn2)
        {
            magmaStrikeState_Img.fillAmount -= 1 / coolDwnTime2 * Time.deltaTime;

            if (magmaStrikeState_Img.fillAmount <= 0)
            {
                magmaStrikeState_Img.fillAmount = 0;
                isCoolDwn2 = false;
            }
        }
    }

    void ElectroNovaStateImg()
    {
        if (Player.PlayerInstance.Input.PlayerActions.Skill2.WasPressedThisFrame() && isCoolDwn3 == false)
        {
            isCoolDwn3 = true;
            electroNovaState_Img.fillAmount = 1;
        }

        if (isCoolDwn3)
        {
            electroNovaState_Img.fillAmount -= 1 / coolDwnTime3 * Time.deltaTime;

            if (electroNovaState_Img.fillAmount <= 0)
            {
                electroNovaState_Img.fillAmount = 0;
                isCoolDwn3 = false;
            }
        }
    }

    void CelestialTempestStateImg()
    {
        if (Player.PlayerInstance.Input.PlayerActions.Skill3.WasPressedThisFrame() && isCoolDwn4 == false)
        {
            isCoolDwn4 = true;
            celestialTempestState_Img.fillAmount = 1;
        }

        if (isCoolDwn4)
        {
            celestialTempestState_Img.fillAmount -= 1 / coolDwnTime4 * Time.deltaTime;

            if (celestialTempestState_Img.fillAmount <= 0)
            {
                celestialTempestState_Img.fillAmount = 0;
                isCoolDwn4 = false;
            }
        }
    }

    void FlamingDragonRoarStrikeStateImg()
    {
        if (Player.PlayerInstance.Input.PlayerActions.Skill4.WasPressedThisFrame() && isCoolDwn5 == false)
        {
            isCoolDwn5 = true;
            flamingDragonRoarStrikeState_Img.fillAmount = 1;
        }

        if (isCoolDwn5)
        {
            flamingDragonRoarStrikeState_Img.fillAmount -= 1 / coolDwnTime5 * Time.deltaTime;

            if (flamingDragonRoarStrikeState_Img.fillAmount <= 0)
            {
                flamingDragonRoarStrikeState_Img.fillAmount = 0;
                isCoolDwn5 = false;
            }
        }
    }
}
