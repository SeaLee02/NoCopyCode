using System;

namespace LiModular.Lib.Auth.Web.Attributes
{
    /// <summary>
    /// 禁用审计功能
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class DisableAuditingAttribute : Attribute
    {
    }
}
