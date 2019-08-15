using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            /*1、非离线情况下，添加数据及其关联数据*/
            //var province = new Province
            //{
            //    Name="辽宁",
            //    Population=40_000_000,
            //    Cities=new List<City>//关联属性
            //    {
            //        new City{AreaCode="012",Name="沈阳"},
            //        new City{AreaCode="013",Name="哈尔滨"},
            //    }               
            //};
            /*2、非离线情况下，在已有数据上添加关联数据*/
            //var province2 = _myContext.Provinces.Single(x => x.Name == "辽宁");
            //province2.Cities.Add(new City
            //{
            //    AreaCode = "014",
            //    Name = "泸州"
            //});
            //_myContext.Provinces.Add(province2);

            /*3、离线情况下，添加数据*/
            //var city = new City
            //{
            //    ProvinceId = 1,
            //    AreaCode = "018",
            //    Name = "葫芦岛"
            //};
            //_myContext.Cities.Add(city);
            //_myContext.SaveChanges();

            /*4、预加载*/
            //var provinces = _myContext.Provinces.Include(x => x.Cities).ToList();

            /*5、查询映射*/
            //var provinces = _myContext.Provinces.Select(x => new
            //{
            //    x.Name,
            //    x.ProvinceId,
            //    Cities=x.Cities.Any(y=>y.Name=="沈阳")
            //}).ToList<dynamic>();

            /*6、修改关联数据,在线版本*/
            //var provinceInfo = _myContext.Provinces
            //    .Include(x => x.Cities)
            //    .First(x => x.Cities.Any());
            //var city = provinceInfo.Cities[0];
            //city.Name += "updatedagain";
            //_myContext.SaveChanges();

            /*7、离线版本*/
            var provinceInfo = _myContext.Provinces
                .Include(x => x.Cities)
                .First(x => x.Cities.Any());
            var city = provinceInfo.Cities[0];
            city.Name += "updatedagain";
            //_transientContext.Cities.Update(city);
            _transientContext.Entry(city).State = EntityState.Modified;
            _transientContext.SaveChanges();
            return View();
        }
    }
}
