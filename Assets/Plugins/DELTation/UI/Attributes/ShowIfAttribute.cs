using System;
using JetBrains.Annotations;
using UnityEngine;

namespace DELTation.UI.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ShowIfAttribute : PropertyAttribute, IConditionShowAttribute
    {
        public string MemberName { get; }

        public ShowIfAttribute([NotNull] string memberName) =>
            MemberName = memberName ?? throw new ArgumentNullException(nameof(memberName));
    }
}