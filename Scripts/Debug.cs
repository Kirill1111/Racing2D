using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game2D.Scripts
{
    class Debug : MonoBehaviour
    {
        public float deltaTime = 0.0f;
        public double time;
        public double ResultTime;

        void Update()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        }

        void OnGUI()
        {
            if (Informations.isDebug)
            {
                int w = Screen.width, h = Screen.height;

                GUIStyle style = new GUIStyle();

                Rect rect = new Rect(0, 0, w, h * 2 / 100);
                style.alignment = TextAnchor.UpperLeft;
                style.fontSize = h * 2 /35;
                style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
                float msec = deltaTime * 1000.0f;
                float fps = 1.0f / deltaTime;
                string text = string.Format("{0:0.0} ms ({1:0.} fps)  ", msec, fps);
                GUI.Label(rect, text, style);
            }
        }

       /* private void OnPreRender()
        {
            time = Time.time;
        }

        private void OnPostRender()
        {
            ResultTime = Time.time - time;
        }*/
    }
}

  

