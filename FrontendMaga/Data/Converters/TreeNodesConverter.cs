using System.Collections.Generic;
using FrontendMaga.Data.DataModels;
using System.Windows.Forms;

namespace FrontendMaga.Data.Converters
{
    class TreeNodesConverter 
    {
        private Dictionary<int, List<ApparatusModel>> _dictionary = new Dictionary<int, List<ApparatusModel>>();
        public List<TreeNode> GetNodes(List<ApparatusModel> obj)
        {
            var nodes = new List<TreeNode>();
            foreach(var item in obj)
            {
                List<ApparatusModel> list;
                _dictionary.TryGetValue((int)item.parent_ap_id, out list);
                if(list == null)
                {
                    list = new List<ApparatusModel>();
                    list.Add(item);
                    _dictionary.Add((int)item.parent_ap_id, list);
                }
                else
                {
                    list.Add(item);
                }
            }
            List<ApparatusModel> roots;
            _dictionary.TryGetValue(0,out roots);
            int i = 0;
            foreach(var item in roots)
            {
                nodes.Add(new TreeNode { Text = item.full_name,Tag = item });
                AddChild(item.ap_id, nodes[i]);
                i++;
            }

            return nodes;
             
        }

        private void AddChild(int parentID, TreeNode node)
        {
            List<ApparatusModel> roots;
            _dictionary.TryGetValue(parentID, out roots);
            if(roots != null)
            {
                int i = 0;
                foreach(var item in roots)
                {
                    node.Nodes.Add(item.full_name);
                    node.Nodes[i].Tag = item;
                    AddChild(item.ap_id, node.Nodes[i]);
                    i++;
                }
            }

        }

    }
}
