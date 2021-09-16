using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMirror : MonoBehaviour
{
    public LineRenderer beamRenderer;

    List<Vector3> beamIndices = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        beamIndices.Add(beamRenderer.transform.parent.position);
    }


    // Update is called once per frame
    void Update()
    {
        beamIndices.Clear();
        beamIndices.Add(beamRenderer.transform.parent.position);
        CastBeam(beamRenderer.transform.position, transform.root.forward, beamRenderer);
    }

    void CastBeam(Vector3 pos, Vector3 dir, LineRenderer beam)
    {
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;
        Debug.DrawLine(pos, pos + (dir * 100), Color.red);
        if ((beamIndices.Count < 1000))
        {
            if (Physics.Raycast(ray, out hit, 30, 1))
            {
                if (!beamIndices.Contains(hit.point))
                {

                    CheckHit(hit, dir);
                }
            }
            else
            {
                beamIndices.Add(ray.GetPoint(30));
                UpdateBeam();
            }
        }
        else
        {
            beamIndices.Add(ray.GetPoint(30));
            UpdateBeam();
        }
    }


    private void CheckHit(RaycastHit hitInfo, Vector3 dir)
    {
        if (hitInfo.transform.tag == "MM")
        {
            beamIndices.Add(hitInfo.point);
            CastBeam(hitInfo.point, Vector3.Reflect(dir, hitInfo.normal), beamRenderer);
            

        }
        else
        {
            beamIndices.Add(hitInfo.point);
            UpdateBeam();
            Collider[] col = Physics.OverlapBox(hitInfo.point, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity);
            foreach (var item in col)
            {
                if (item.tag == "Lightable")
                {
                    item.GetComponent<Scone>().isActivated = false;
                }
                if (item.tag == "Meltable")
                {
                    item.GetComponent<WaterWheel>().isFrozen = true;
                }
            }

        }
    }

    void UpdateBeam()
    {
        int count = 0;
        beamRenderer.positionCount = beamIndices.Count;
        foreach (var item in beamIndices)
        {
            beamRenderer.SetPosition(count, item);
            count++;
        }
    }

    private void OnDrawGizmos()
    {
        foreach (var item in beamIndices)
        {
            Gizmos.DrawCube(item, Vector3.one);
        }
    }
}


