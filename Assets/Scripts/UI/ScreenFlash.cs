using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Golf
{
    public class ScreenFlash : MonoBehaviour
    {
        public static ScreenFlash Instance;

        private Image img;

        private void Awake()
        {
            Instance = this;
            img = GetComponent<Image>();
            img.color = new Color(1f, 0f, 0f, 0f);
        }

        public void Flash(float duration = 0.3f)
        {
            StartCoroutine(FlashRoutine(duration));
        }

        private IEnumerator FlashRoutine(float duration)
        {
            img.color = new Color(1f, 0f, 0f, 0.55f); 
            yield return new WaitForSeconds(duration);
            img.color = new Color(1f, 0f, 0f, 0f); 
        }

        public void ResetFlash() => img.color = new Color(1f, 0f, 0f, 0f);

    }
}
