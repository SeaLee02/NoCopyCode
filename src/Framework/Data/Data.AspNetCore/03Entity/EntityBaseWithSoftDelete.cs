using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AspNetCore.Entity
{
    public abstract class EntityBaseWithSoftDelete<TKey> : EntityWithSoftDelete<TKey>
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime")]
        public virtual DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        [Column("CreateId")]
        public virtual Guid CreateId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("ModifyTime")]
        public virtual DateTime? ModifyTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        [Column("ModifyId")]
        public virtual Guid ModifyId { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        [Column("CreateName")]
        public virtual string CreateName { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [Column("ModifyName")]
        public virtual string ModifyName { get; set; }
    }

    /// <summary>
    /// 包含软删除功能的实体基类
    /// </summary>
    public abstract class EntityBaseWithSoftDelete : EntityBaseWithSoftDelete<Guid>
    {

    }
}
