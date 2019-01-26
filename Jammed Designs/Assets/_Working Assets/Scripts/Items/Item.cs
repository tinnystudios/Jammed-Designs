using UnityEngine;

namespace JammedDesigns.Model
{
    public class Item : MonoBehaviour
    {
        public GridNode ConnectedNode;

        public void Init(GridNode node)
        {
            ConnectedNode = node;
        }

        private void OnDestroy()
        {
            if (ConnectedNode != null)
            {
                ConnectedNode.SetUsabilitity(true);
            }
        }
    }
}
