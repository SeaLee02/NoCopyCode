using LiModular.Lib.Module.AspNetCore.AOP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Module.Admin.Web.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Sys")]
    [Description("测试接口")]
    [Authorize]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [TransactionInterceptor]
        [Description("查询")]
        public async Task Query([FromQuery] QueryModel model)
        {
            Console.WriteLine("dwdwd");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("添加")]
        public async Task Add(AddModel model)
        {

        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Description("修改")]
        public async Task Edit([BindRequired] Guid id)
        {
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Description("更新")]
        public async Task Update(UpdateModel model)
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Description("删除")]
        public async Task Delete([BindRequired] Guid id)
        {

        }
    }

    /// <summary>
    /// 查询Model
    /// </summary>
    [Description("查询Model")]
    public class QueryModel
    {
        [Description("名称")]
        public string Name { get; set; }

    }

    /// <summary>
    /// 查询Model
    /// </summary>
    [Description("添加Model")]
    public class AddModel
    {
        [Description("添加名称")]
        public string Name { get; set; }
    }

    public class UpdateModel
    {

    }



}
