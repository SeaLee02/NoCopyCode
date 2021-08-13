using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiModular.Lib.Auth.Web.Attributes;

namespace LiModular.Lib.Auth.Web
{
    /// <summary>
    /// 抽象接口基类
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Auditing]
    public abstract class ControllersAbstract : ControllerBase
    {

        public ControllersAbstract()
        {

        }
    }
}
