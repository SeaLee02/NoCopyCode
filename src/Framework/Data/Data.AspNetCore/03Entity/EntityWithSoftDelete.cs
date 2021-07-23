using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AspNetCore.Entity
{
    /// <summary>
    /// 包含指定类型主键的软删除实体
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TDeletedByKey">删除人主键类型</typeparam>
    public abstract class EntityWithSoftDelete<TKey> : Entity<TKey>
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("IsDelete")]
        public virtual bool IsDelete { get; set; } = false;

        /// <summary>
        /// 删除时间
        /// </summary>
        [Column("DeleteTime")]
        public virtual DateTime? DeleteTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 删除人
        /// </summary>
        [NotMapped]
        public virtual string DeleteName { get; set; }

    }

    /// <summary>
    /// 主键类型GUID的软删除实体
    /// </summary>
    public abstract class EntityWithSoftDelete : EntityWithSoftDelete<Guid>
    {

    }
}
