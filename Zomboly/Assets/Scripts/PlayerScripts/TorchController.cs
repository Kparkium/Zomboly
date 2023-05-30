using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public GameObject Torch;
    public bool isOn;

    public void Start()
    {
        isOn = false;
        Torch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn)
            {
                isOn = false;
            }
            else
            {
                isOn = true;
            }
            Torch.SetActive(isOn);
        }
    }
}
