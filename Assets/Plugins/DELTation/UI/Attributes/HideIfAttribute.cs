using System;
using JetBrains.Annotations;
using UnityEngine;

namespace DELTation.UI.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class HideIfAttribute : PropertyAttribute, IConditionShowAttribute
    {
        public string MemberName { get; }

        public HideIfAttribute([NotNull] string memberName) =>
            MemberName = memberName ?? throw new ArgumentNullException(nameof(memberName));
    }
}