using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Domain.NToN;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web
{
    public class HomeController : Controller
    {
        private readonly MyContext _myContext;
        private readonly MyContext _transientContext;

        public HomeController(MyContext myContext,MyContext transientContext)
        {
            this._myContext = myContext;
            this._transientContext = transientContext;
        }
        public IActionResult Index()
        {
            /*1、添加*/
            /*var province = new Province()
            {
                Name="北京",
                Population=2_000_000
            };
            var province2 = new Province()
            {
                Name = "上海",
                Population = 2_500_000
            };
            var company = new Company()
            {
                Name = "pisi",
                EstablishTime = new DateTime(1978, 1, 1),
                LegalPerson="lr"
                
           
            };
            //_myContext.Provinces.AddRange(province);
            _myContext.AddRange(province, province2, company);
            _myContext.SaveChanges();*/
            /*2、简单查询*/
            //var province = _myContext.Provinces.Where(x => x.Name == "北京").ToList();//lambda
            //var province2 = (from p in _myContext.Provinces where p.Name == "北京" select p).ToList();//linq

            /*3、过滤查询及linq方法*/
            //var param = "北京";
            //var province = _myContext.Provinces.Where(x => x.Name == param).FirstOrDefault();//linq方法
            //var provinceByFind = _myContext.Provinces.Find(3);//非linq方法查询
            //var provinceByEFFunction = _myContext.Provinces.Where(x => EF.Functions.Like(x.Name, "%Bei%")).ToList();//相当于 name like '%Bei%'，EFCore新方法
            //var provinceByEFFunction2 = _myContext.Provinces.LastOrDefault(x => EF.Functions.Like(x.Name, "%Bei%"));//LastOrDefault需要配合OrderBy使用否则容易出现性能问题

            /*4、修改*/
            //var province = _myContext.Provinces.FirstOrDefault();
            //if(province!=null)
            //{
            //    province.Population += 100;
            //    _myContext.Provinces.Add(new Province
            //    {
            //        Name="四川",
            //        Population=1_000_000_000
            //    });
            //    _myContext.SaveChanges();
            //}

            /*5、修改离线对象，即非context追踪对象*/
            //var province = _myContext.Provinces.FirstOrDefault();
            //_transientContext.Provinces.Update(province);//将追踪对象状态置为修改状态
            //_transientContext.SaveChanges();


            /*6、删除*/
            var province = _myContext.Provinces.FirstOrDefault();
            _myContext.Provinces.Remove(province);
            _myContext.SaveChanges();
            return View();
        }
    }
}
