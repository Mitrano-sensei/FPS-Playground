using EzySlice;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FPSPlayground
{
    public class CuttableEnemy : MonoBehaviour
    {
        #region Fields
        [SerializeField] private List<EnemyAnchor> enemyAnchors;
        [SerializeField] private Material sliceMaterial;
        [SerializeField] private float pushForce = 1f;

        #endregion    
    
        #region MonoBehaviour
        void Start()
        {
        
        }

        void Update()
        {
            if (CheckIsCut())
                CutSelf();
        }
        #endregion

        private bool CheckIsCut()
        {
            return enemyAnchors.All(x => x.IsActive);
        }

        private void CutSelf()
        {
            var playerPosition = ReferencesManager.Instance.PlayerController.transform.position + Vector3.up;

            var firstCutPlanePoints = new List<Vector3>(3) { playerPosition , enemyAnchors[0].transform.position, enemyAnchors[1].transform.position };
            var secondCutPlanePoints = new List<Vector3>(3) { playerPosition, enemyAnchors[1].transform.position, enemyAnchors[2].transform.position };

            var firstCutPlane = GetCutPlaneFromPoints(firstCutPlanePoints);
            var secondCutPlane = GetCutPlaneFromPoints(secondCutPlanePoints);

            SlicedHull slicedHull = gameObject.Slice(firstCutPlane.Point, firstCutPlane.Normal, sliceMaterial);
            var lower = slicedHull.CreateLowerHull(gameObject, sliceMaterial);
            var upper = slicedHull.CreateUpperHull(gameObject, sliceMaterial);

            SetupSlicedComponent(lower, playerPosition, Vector3.down);

            SlicedHull secondSlice = upper.Slice(secondCutPlane.Point, secondCutPlane.Normal, sliceMaterial);

            var lowerUpper = secondSlice.CreateLowerHull(upper, sliceMaterial);
            var upperUpper = secondSlice.CreateUpperHull(upper, sliceMaterial);

            SetupSlicedComponent(lowerUpper, playerPosition, Vector3.zero);
            SetupSlicedComponent(upperUpper, playerPosition, Vector3.up);

            upper.SetActive(false);
            gameObject.SetActive(false);
        }

        private CutPlane GetCutPlaneFromPoints(List<Vector3> points)
        {
            var normal = Vector3.Cross(points[1] - points[0], points[2] - points[0]).normalized;
            return new CutPlane(points[0], normal);
        }

        private void SetupSlicedComponent(GameObject slicedComponent, Vector3 playerPosition, Vector3 additionalForce)
        {
            var rb = slicedComponent.AddComponent<Rigidbody>();
            rb.AddForce(pushForce * ((rb.transform.position - playerPosition) + additionalForce), ForceMode.Impulse);
            // rb.AddTorque(UnityEngine.Random.insideUnitSphere * 10);
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            
            slicedComponent.AddComponent<MeshCollider>().convex = true;
        }
    
        private class CutPlane
        {
            public Vector3 Point { get; set; }
            public Vector3 Normal { get; set; }

            public CutPlane(Vector3 point, Vector3 normal)
            {
                Point = point;
                Normal = normal;
            }
        }   
    }

    
}
