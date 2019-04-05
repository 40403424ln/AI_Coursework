using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Coursework
{
    class PathFinder
    {
        List<Node> visited = new List<Node>();
        List<Node> toVisit = new List<Node>();
        List<Node> path = new List<Node>();

        Dictionary<Node, Node> ParentMap = new Dictionary<Node, Node>();
        Dictionary<Node, double> gScore = new Dictionary<Node, double>();
        Dictionary<Node, double> fScore = new Dictionary<Node, double>();

        List<Node> temp = new List<Node>();

        //Node currentNode;
        Node startNode;
        Node endNode;

        public PathFinder(List<Node> nodes)
        {            
            startNode = nodes.First();            
            endNode = nodes.Last();
            toVisit.Add(startNode);

            gScore[startNode] = 0;
            fScore[startNode] = calcDistance(endNode, startNode);
        }        


        public double calcDistance(Node toNode, Node fromNode)
        {
            return Math.Sqrt(((fromNode.x - toNode.x) * (fromNode.x - toNode.x)) + ((fromNode.y - toNode.y) * (fromNode.y - toNode.y)));
        }

        public List<Node> buildPath(Dictionary<Node, Node> dNode, Node currentNode)
        {
            List<Node> totalPath = new List<Node>();
            totalPath.Add(currentNode);
            while(dNode.Keys.Contains(currentNode))
            {
                currentNode = dNode[currentNode];
                totalPath.Add(currentNode);
            }
            return totalPath;
        }

        public List<Node> calcPath()
        {
            while (toVisit.Count() != 0)
            {
                Node currentNode = null;

                double curentLowest = double.PositiveInfinity;
                foreach(Node node in toVisit)
                {
                    if (fScore[node] < curentLowest)
                    {
                        curentLowest = fScore[node];
                        currentNode = node;
                    }
                }

                if (currentNode == endNode)
                {

                    return buildPath(ParentMap, currentNode);

                }

                toVisit.Remove(currentNode);
                visited.Add(currentNode);

                foreach(Node node in currentNode.connectedNodes)
                {
                    if (visited.Contains(node))
                    {
                        continue;
                    }

                    double neighbourScore = gScore[currentNode] + calcDistance(node, currentNode);
                    if (!toVisit.Contains(node))
                    {
                        toVisit.Add(node);
                    }
                    else if (neighbourScore >= gScore[node])
                        continue;

                    ParentMap[node] = currentNode;
                    gScore[node] = neighbourScore;
                    fScore[node] = gScore[node] + calcDistance(endNode, node);
                }
            }

            return null;
        }

        private Node removeVisited(Node node)
        {
            temp = new List<Node>();
            foreach(Node n in node.connectedNodes)
            {
                foreach(Node n2 in visited)
                {
                    if(n.id == n2.id)
                    {
                        temp.Add(n);
                    }
                }
            }

            return node;
        }       

    }
}
