using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFps
{
    public class BFristTrigger : MonoBehaviour
    {

        public GameObject Player;
        public GameObject arrow;

        private float delayTime = 1f;

        public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence = "Looks like a weapon on that table.";

        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(ArrowDelay());
        }
        IEnumerator ArrowDelay()
        {
            Player.SetActive(false);

            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            yield return new WaitForSeconds(2f);

            arrow.SetActive(true);

            yield return new WaitForSeconds(delayTime);

            textBox.text = "";
            textBox.gameObject.SetActive(false);
           
            Player.SetActive(true);
            transform.GetComponent<BoxCollider>().enabled = false;   
        }
    }

}
