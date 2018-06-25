﻿using System;
using System.Collections.Generic;
using UnityEditor.Graphing;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace GeoTetra.GTGenericGraph
{
    [Serializable]
    public class BooleanGenericSlot : GenericSlot, IMaterialSlotHasValue<bool>
    {
        [SerializeField]
        private bool m_Value;

        [SerializeField]
        private bool m_DefaultValue;

        public BooleanGenericSlot()
        {}

        public BooleanGenericSlot(
            int slotId,
            string displayName,
            string shaderOutputName,
            SlotType slotType,
            bool value,
            bool hidden = false)
            : base(slotId, displayName, shaderOutputName, slotType, hidden)
        {
            m_DefaultValue = value;
            m_Value = value;
        }

        public override VisualElement InstantiateControl()
        {
            return new BooleanGenericSlotControlView(this);
        }

        public bool defaultValue { get { return m_DefaultValue; } }

        public bool value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        protected override string ConcreteSlotValueAsVariable(AbstractMaterialNode.OutputPrecision precision)
        {
            return (value ? 1 : 0).ToString();
        }

        public override void AddDefaultProperty(PropertyCollector properties, GenerationMode generationMode)
        {
            if (!generationMode.IsPreview())
                return;

            var matOwner = owner as AbstractMaterialNode;
            if (matOwner == null)
                throw new Exception(string.Format("Slot {0} either has no owner, or the owner is not a {1}", this, typeof(AbstractMaterialNode)));

            var property = new BooleanShaderProperty()
            {
                overrideReferenceName = matOwner.GetVariableNameForSlot(id),
                generatePropertyBlock = false,
                value = value
            };
            properties.AddShaderProperty(property);
        }

        public override SlotValueType valueType { get { return SlotValueType.Boolean; } }
        public override ConcreteSlotValueType concreteValueType { get { return ConcreteSlotValueType.Boolean; } }

        public override void GetPreviewProperties(List<PreviewProperty> properties, string name)
        {
            var pp = new PreviewProperty(PropertyType.Boolean)
            {
                name = name,
                booleanValue = value
            };
            properties.Add(pp);
        }

        public override void CopyValuesFrom(GenericSlot foundSlot)
        {
            var slot = foundSlot as BooleanGenericSlot;
            if (slot != null)
                value = slot.value;
        }
    }
}