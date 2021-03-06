﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GeoTetra.GTLogicGraph
{
	[Serializable]
	public class LogicGraphData 
	{		
		[SerializeField]
		private List<SerializedNode> _serializedInputNodes = new List<SerializedNode>();
		
		[SerializeField]
		private List<SerializedNode> _serializedOutputNodes = new List<SerializedNode>();
		
		[SerializeField]
		private List<SerializedNode> _serializedNodes = new List<SerializedNode>();
		
		[SerializeField]
		private List<SerializedEdge> _serializedEdges = new List<SerializedEdge>();
		
		public List<SerializedEdge> SerializedEdges
		{
			get { return _serializedEdges; }
		}

		public List<SerializedNode> SerializedNodes
		{
			get { return _serializedNodes; }
		}

		public List<SerializedNode> SerializedInputNodes
		{
			get { return _serializedInputNodes; }
		}

		public List<SerializedNode> SerializedOutputNodes
		{
			get { return _serializedOutputNodes; }
		}
	}

	[Serializable]
	public class SerializedNode
	{
		public string NodeType;
		public string JSON;
	}
	
	[Serializable]
	public class SerializedEdge
	{
		public string SourceNodeGuid;
		public string SourceMemberName;
		public string TargetNodeGuid;
		public string TargetMemberName;
	}
}