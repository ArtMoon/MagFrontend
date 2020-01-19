using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrontendMaga.Interfaces;
using FrontendMaga.Data.DataModels;
using System.Windows.Forms;

namespace FrontendMaga.Data.Converters
{
    class TreeNodesConverter 
    {
        public List<TreeNode> ConvertTo(List<ApparatusModel> obj)
        {
            obj.OrderBy((n) => n.Parent_id);
            var rootNodes = new List<TreeNode>();
            var enterNodes = obj;
            var levels = new Dictionary<int, List<ApparatusModel>>();
            int lvlIndex = 0;
            while (obj.Count > 0)
            {
                var roots = new List<ApparatusModel>();
                for (int i = 0; i < obj.Count; i++)
                {
                    for (int j = 0; j < enterNodes.Count; j++)
                    {
                        if (obj[i].Parent_id == enterNodes[j].Id_Ap)
                        {
                            break;
                        }

                        if (j == enterNodes.Count - 1)
                        {
                            roots.Add(obj[i]);
                        }

                    }
                }
                var list = new List<ApparatusModel>();

                foreach (ApparatusModel m in roots)
                {
                    list.Add((ApparatusModel)m.Clone());
                    obj.Remove(m);
                }
                lvlIndex++;
                levels.Add(lvlIndex, list);

            }

            var nodes = new List<TreeNode>();
            var root = new List<ApparatusModel>();
            levels.TryGetValue(1, out root);
            var childs = new List<ApparatusModel>();
            levels.TryGetValue(2, out childs);
            for (int i = 0; i < root.Count; i++)
            {
                nodes.Add(new TreeNode(root[i].App_name));
                for (int j = 0; j < childs.Count; j++)
                {
                    if (childs[j].Parent_id == root[i].Id_Ap)
                    {
                        nodes[i].Nodes.Add(new TreeNode(childs[j].App_name));
                    }
                }

            }
            //_tmpApparatus = childs;
            //_tmpApparatus.AddRange(root);

            return nodes;
        }
    }
}
