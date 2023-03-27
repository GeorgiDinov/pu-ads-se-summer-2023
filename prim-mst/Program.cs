﻿using System;
using System.Collections.Generic;

namespace prim_mst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vertex> vertexList = new List<Vertex>();
            Vertex vertexA = new Vertex("A");
            Vertex vertexB = new Vertex("B");
            Vertex vertexC = new Vertex("C");

            vertexList.Add(vertexA);
            vertexList.Add(vertexB);
            vertexList.Add(vertexC);

            vertexA.AddEdge(new Edge(1, vertexA, vertexB));
            vertexA.AddEdge(new Edge(1, vertexA, vertexC));

            vertexB.AddEdge(new Edge(10, vertexB, vertexC));
            vertexB.AddEdge(new Edge(1, vertexB, vertexA));

            vertexC.AddEdge(new Edge(1, vertexC, vertexA));
            vertexC.AddEdge(new Edge(10, vertexC, vertexB));

            PrimMST prim = new PrimMST(vertexList);
            prim.FindMST(vertexB);
        }
    }
}
