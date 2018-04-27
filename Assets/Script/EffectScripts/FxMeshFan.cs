#region
/*--------------------------------------------------------------------------------
//
// Copyright (C) 2017 netcosmos.com
// 
// 文件名 ： FxMeshFan
// 文件名功能描述:
//
// 创建者: 王骏(wangjun)
// 时间： (9/11/2017 8:47:25 PM)
//
// 修改人:
// 修改时间：
// 修改说明：
//
// 修改人:
// 修改时间：
// 修改说明：
//
// 版本: V1.0.0
//
//---------------------------------------------------------------------------------*/
#endregion


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EffectScripts
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class FxMeshFan : MonoBehaviour
    {
        public float radius = 2;
        public float angleDegree = 100;
        public int segments = 10;
        public int angleDegreePrecision = 1000;
        public int radiusPrecision = 1000;

        private MeshFilter meshFilter;

        //private SectorMeshCreator creator = new SectorMeshCreator();

        private Mesh mMesh;
        [ExecuteInEditMode]
        private void Awake()
        {

        }



        private class SectorMeshCreator
        {
            private float radius;
            private float angleDegree;
            private int segments;

            private Mesh cacheMesh;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="radius"></param>
            /// <param name="angleDegree"></param>
            /// <param name="segments"></param>
            /// <param name="angleDegreePrecision"></param>
            /// <param name="radiusPrecision"></param>
            /// <returns></returns>
            public Mesh CreateMesh(float radius, float angleDegree, int segments, int angleDegreePrecision, int radiusPrecision)
            {
                if (checkDiff(radius, angleDegree, segments, angleDegreePrecision, radiusPrecision))
                {
                    //Mesh newMesh = Create(radius, angleDegree, segments, angleDegreePrecision, radiusPrecision);
                    //if (newMesh != null)
                    //{
                    //    cacheMesh = newMesh;
                    //    this.radius = radius;
                    //    this.angleDegree = angleDegree;
                    //    this.segments = segments;
                    //}

                }
                return cacheMesh;

            }
            /**
            private Mesh Create(float radius, float angleDegree, int segments)

            {
                if(segments == 0)
                {
                    segments = 1;
#if UNITY_EDITOR
                    Debug.Log("segments must be larger than zero.");
#endif
                }

                Mesh mesh = new Mesh();
                Vector3[] vertices = new Vector3[3 + segments - 1];
                vertices[0] = new Vector3(0, 0, 0);

                float angle = Mathf.Deg2Rad * (90 + angleDegree / 2);
                float currAngle = angle / 2;

                //currAngle = Math


            }

    **/

            private bool checkDiff(float radius, float angleDegree, int segments, int angleDegreePrecision, int radiusPrecision)
            {
                return segments != this.segments || ((int)((angleDegree - this.angleDegree) * angleDegreePrecision) != 0 )
                    || (int)((radius - this.radius) * radiusPrecision) != 0;
            }
        }

    }
}
