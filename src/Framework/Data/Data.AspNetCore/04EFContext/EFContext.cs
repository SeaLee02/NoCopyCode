using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AspNetCore.EFContext
{
    /// <summary>
    /// 上下文
    /// </summary>
    public class EFContext : DbContext
    {
        
        public EFContext(DbContextOptions options) : base(options)
        {

        }
    }
}
