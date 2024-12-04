using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
        public float beatTempo;
        public bool hasStarted;

        private void Start()
        {
                beatTempo = beatTempo / 60;
        }

        void Update()
        {
                if (!hasStarted)
                {
                        // if (Input.anyKeyDown)
                        // {
                        //         hasStarted = true;
                        // }
                }
                else
                {
                        transform.position -= new Vector3(0f, beatTempo * Time.time, 0f);
                }
        }
}