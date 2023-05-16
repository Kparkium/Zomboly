//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerBehaviour : MonoBehaviour
//{

//    [SerializeField] HealthBar _healthBar; //HB Script. Lets you drag an object with another script onto an object that has this class in it.


//    void Start()
//    {
        
//    }

//    void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.K))
//        {
//            PlayerTakeDmg(20);
//            Debug.Log(GameManager.gameManager._playerHealth.Health);
//        }

//        if(Input.GetKeyDown(KeyCode.L))
//        {
//            PlayerRecovery(10);
//            Debug.Log(GameManager.gameManager._playerHealth.Health);
//        }
//    }

//    //Player takes damage
//    private void PlayerTakeDmg(int dmg)
//    {
//        GameManager.gameManager._playerHealth.DamageUnit(dmg);
//        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health); //Changes the UI according to how much HP you have.
//    }

//    //Player receives healing
//    private void PlayerRecovery(int heal)
//    {
//        GameManager.gameManager._playerHealth.HealUnit(heal);
//        _healthBar.SetHealth(GameManager.gameManager._playerHealth.Health); //Changes the UI according to how much HP you have.
//    }
//}
