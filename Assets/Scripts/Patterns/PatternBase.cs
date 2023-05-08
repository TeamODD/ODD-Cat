using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cainos.PixelArtTopDown_Basic;
using Eyes;
using Bullet;

namespace Pattern
{
    public class PatternBase : MonoBehaviour
    {
        [SerializeField] public GameObject SimpleArrow;
        [SerializeField] public GameObject TwoLayerCircle;
        [SerializeField] public GameObject Triangle;
        [SerializeField] public GameObject Circle;
        [SerializeField] public GameObject MushroomY;
        [SerializeField] public GameObject MushroomR;
        [SerializeField] public GameObject Heart;


        public GameObject player;
        public GameObject uiManager;
        public GameObject bulletManager;
        public GameObject altar;

        public Player playerScript;
        public UIManager uiManagerScript;
        public BulletManager bulletManagerScript;
        public PropsAltar altarScript;

        private List<GameObject> triangleList;
        private List<GameObject> heartList;
        public readonly float[] heartSpeed = new float[34];
        public readonly float[] heartDir = new float[34];

        public void init()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            uiManager = GameObject.FindGameObjectWithTag("UIManager");
            bulletManager = GameObject.FindGameObjectWithTag("BulletManager");
            altar = GameObject.FindGameObjectWithTag("Altar");


            playerScript = player.GetComponent<Player>();
            uiManagerScript = uiManager.GetComponent<UIManager>();
            bulletManagerScript = bulletManager.GetComponent<BulletManager>();

            triangleList = new List<GameObject>();
            heartList = new List<GameObject>();
            heartDataInit();
        }

        public void updateTriangleList()
        {
            int i = 0;
            while (i < triangleList.Count)
            {
                if (triangleList[i] == null)
                    triangleList.RemoveAt(i);
                else
                    i++;
            }
        }

        public void updateHeartList()
        {
            int i = 0;
            while (i < heartList.Count)
            {
                if (heartList[i] == null)
                    heartList.RemoveAt(i);
                else
                    i++;
            }
        }

        public void setSimpleArrowSpeed(float speed)
        {
            bulletManagerScript.setSimpleArrowSpeed(speed);
        }
        public void setTwoLayerCircleSpeed(float speed)
        {
            bulletManagerScript.setTwoLayerCircleSpeed(speed);
        }

        public void setMushroomYSpeed(float speed)
        {
            bulletManagerScript.setMushroomYSpeed(speed);
        }

        public void setMushroomRSpeed(float speed)
        {
            bulletManagerScript.setMushroomRSpeed(speed);
        }


        public void setTriangleSpeed(float speed)
        {
            foreach (GameObject o in triangleList)
            {
                o.GetComponent<Triangle>().setSpeed(speed);
            }
        }

        public void multiplyTriangleSpeed(float n)
        {
            foreach (GameObject o in triangleList) 
            {
                o.GetComponent<Triangle>().multiplySpeed(n);
            }
        }

        public void multiplyHeartSpeed(float n)
        {
            foreach (GameObject o in heartList)
            {
                o.GetComponent<Heart>().multiplySpeed(n);
            }
        }

        public void createSimpleArrowBullet(Vector3 v1, Vector3 v2)
        {
            GameObject o = Instantiate(SimpleArrow) as GameObject;
            o.transform.SetParent(bulletManager.transform);
            o.transform.position = v1;
            o.GetComponent<SimpleArrow>().init(v2);
            o.SetActive(true);
        }

        public void createTwoLayerCircleBullet(Vector3 v1, Vector3 v2)
        {
            GameObject o = Instantiate(TwoLayerCircle) as GameObject;
            o.transform.SetParent(bulletManager.transform);
            o.transform.position = v1;
            o.GetComponent<TwoLayerCircle>().init(v2);
            o.SetActive(true);
        }

        public void createMushroomYBullet(Vector3 v1, Vector3 v2)
        {
            GameObject o = Instantiate(MushroomY) as GameObject;
            o.transform.SetParent(bulletManager.transform);
            o.transform.position = v1;
            o.GetComponent<MushroomY>().init(v2);
            o.SetActive(true);
        }

        public void createMushroomRBullet(Vector3 v1, Vector3 v2)
        {
            GameObject o = Instantiate(MushroomR) as GameObject;
            o.transform.SetParent(bulletManager.transform);
            o.transform.position = v1;
            o.GetComponent<MushroomR>().init(v2);
            o.SetActive(true);
        }

        public void createTriangleBullet(Vector3 v1, Vector3 v2, float speed)
        {
            GameObject o = Instantiate(Triangle) as GameObject;
            o.transform.SetParent(bulletManager.transform);
            o.transform.position = v1;
            o.GetComponent<Triangle>().init(v2, speed);
            o.SetActive(true);
            triangleList.Add(o);
        }

        public void createHeartBullet(Vector3 v1, Vector3 v2, float speed)
        {
            GameObject o = Instantiate(Heart) as GameObject;
            o.transform.SetParent(bulletManager.transform);
            o.transform.position = v1;
            o.GetComponent<Heart>().init(v2, speed);
            o.SetActive(true);
            heartList.Add(o);
        }

        // Open Source


        private void heartDataInit()
        {
            heartSpeed[0] = 111.00f;
            heartDir[0] = 90.00f;
            heartSpeed[1] = 133.10f;
            heartDir[1] = 98.70f;
            heartSpeed[2] = 152.04f;
            heartDir[2] = 107.37f;
            heartSpeed[3] = 166.88f;
            heartDir[3] = 116.18f;
            heartSpeed[4] = 176.00f;
            heartDir[4] = 125.28f;
            heartSpeed[5] = 181.88f;
            heartDir[5] = 134.29f;
            heartSpeed[6] = 181.50f;
            heartDir[6] = 143.31f;
            heartSpeed[7] = 175.54f;
            heartDir[7] = 152.33f;
            heartSpeed[8] = 165.63f;
            heartDir[8] = 161.38f;
            heartSpeed[9] = 151.50f;
            heartDir[9] = 170.43f;
            heartSpeed[10] = 136.35f;
            heartDir[10] = 180.18f;
            heartSpeed[11] = 120.40f;
            heartDir[11] = 190.90f;
            heartSpeed[12] = 106.45f;
            heartDir[12] = 203.68f;
            heartSpeed[13] = 98.56f;
            heartDir[13] = 219.22f;
            heartSpeed[14] = 99.10f;
            heartDir[14] = 235.97f;
            heartSpeed[15] = 107.97f;
            heartDir[15] = 251.19f;
            heartSpeed[16] = 124.58f;
            heartDir[16] = 262.83f;
            heartSpeed[17] = 133.10f;
            heartDir[17] = 81.30f;
            heartSpeed[18] = 152.04f;
            heartDir[18] = 72.63f;
            heartSpeed[19] = 166.88f;
            heartDir[19] = 63.82f;
            heartSpeed[20] = 176.00f;
            heartDir[20] = 54.72f;
            heartSpeed[21] = 181.88f;
            heartDir[21] = 45.71f;
            heartSpeed[22] = 181.50f;
            heartDir[22] = 36.69f;
            heartSpeed[23] = 175.54f;
            heartDir[23] = 27.67f;
            heartSpeed[24] = 165.63f;
            heartDir[24] = 18.62f;
            heartSpeed[25] = 151.50f;
            heartDir[25] = 9.57f;
            heartSpeed[26] = 136.35f;
            heartDir[26] = 359.82f;
            heartSpeed[27] = 120.40f;
            heartDir[27] = 349.10f;
            heartSpeed[28] = 106.45f;
            heartDir[28] = 336.32f;
            heartSpeed[29] = 98.56f;
            heartDir[29] = 320.78f;
            heartSpeed[30] = 99.10f;
            heartDir[30] = 304.03f;
            heartSpeed[31] = 107.97f;
            heartDir[31] = 288.81f;
            heartSpeed[32] = 124.58f;
            heartDir[32] = 277.17f;
            heartSpeed[33] = 147.85f;
            heartDir[33] = 270.05f;
        }
    }
}