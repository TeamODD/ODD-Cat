using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
        private Color targetColor;

        void Start()
        {
            setDisable();
        }

        /*private void OnTriggerEnter2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 1);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 0);
        }*/

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }

        public void setEnable()
        {
            StartCoroutine(runEnabled());
        }

        public IEnumerator runEnabled()
        {
            targetColor = new Color(1, 1, 1, 1);

            yield return new WaitForSeconds(0.6f);
            targetColor = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.3f);
            targetColor = new Color(1, 1, 1, 1);

            yield return new WaitForSeconds(0.6f);
            targetColor = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.3f);
            targetColor = new Color(1, 1, 1, 1);
        }

        public void setDisable()
        {
            targetColor = new Color(1, 1, 1, 0);
        }
    }
}
