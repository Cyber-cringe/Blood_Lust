using UnityEngine;
using System.Collections;

namespace Pathfinding
{
    /// <summary>
    /// Sets the destination of an AI to the position of a specified object.
    /// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
    /// This component will then make the AI move towards the <see cref="target"/> set on this component.
    ///
    /// See: <see cref="Pathfinding.IAstarAI.destination"/>
    ///
    /// [Open online documentation to see images]
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class AIDEst : VersionedMonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>
        public Transform target;
        public Transform firepoint;
        public GameObject bulletPrefab;
        public Transform RotationEnemies;


        public float fireTime = 0f;

        IAstarAI ai;
        public float rotateSpeed = 0.9f;
        

        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            // Update the destination right before searching for a path as well.
            // This is enough in theory, but this script will also update the destination every
            // frame as the destination is used for debugging and may be used for other things by other
            // scripts as well. So it makes sense that it is up to date every frame.
            if (ai != null) ai.onSearchPath += Update;
        }

        void OnDisable()
        {
            if (ai != null) ai.onSearchPath -= Update;
        }

        /// <summary>Updates the AI's destination every frame</summary>
        void Update()
        {
            
            if ((target != null) && (Vector2.Distance(target.position, transform.position) <= 30))
            {
                Shoot();
                if ((Vector2.Distance(target.position, transform.position) >= 10))
                {
                    ai.destination = target.position;
                  // Shoot();
                }
                else
                ai.destination = transform.position;
                Vector2 targetDirection = target.position - transform.position;
                float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
                Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
                RotationEnemies.rotation = Quaternion.Slerp(RotationEnemies.rotation, q, rotateSpeed);
                //transform.rotation = target.rotation;
                
                //Shoot();
            }
            else
                ai.destination = transform.position;
                //transform.position
        }
     public void Shoot()
        {
            float fireRate = 0.5f;
            Debug.Log(fireRate);

            if (fireTime <= 0)
            {
                Debug.Log(fireTime);
                Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                fireTime = fireRate;
            }
            else
            {
                fireTime -= Time.deltaTime;
            }

        }
    }
}
