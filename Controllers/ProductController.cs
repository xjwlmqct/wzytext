using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.Models;

namespace webapi.Controllers
{
    public class ProductController : ApiController
    {
        static IProductRepository ipdr = new ProductRepository();


        //GET: api/Product
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>

        public UnifiedResultDate Get()//IEnumerable<Product> Get()
        {
            //return new string[] { "value1", "value2" };
            //return ipdr.GetAll();
            var v = ipdr.GetAll();
            return new UnifiedResultDate(v);
        }
        //public IEnumerable<Product> Get()
        //{
        //    //return new string[] { "value1", "value2" };
        //    return ipdr.GetAll();
        //    //var v = ipdr.GetAll();
        //    //return new UnifiedResultDate(v, ((int)HttpStatusCode.OK).ToString(), "找到数据");
        //}


        // GET: api/Product/5
        /// <summary>
        /// 返回指定Id的数据
        /// </summary>
        /// <param name="id">数据Id</param>
        /// <returns>返回指定Id的数据</returns>

        //public Product Get(int id)
        //{
        //    Product prd = ipdr.Get(id);
        //    //if (prd == null)
        //    //{
        //    //    var v = new HttpResponseMessage();
        //    //    v.StatusCode = HttpStatusCode.BadRequest;
        //    //    v.ReasonPhrase= "未找到数据。";
        //    //    //v.Content = "未报到数据。";
        //    //    throw new HttpResponseException(v);//(HttpStatusCode.NotFound);
        //    //}
        //    return prd;
        //}
        public UnifiedResultDate Get(int id)
        {
            Product prd = ipdr.Get(id);
            var v = new UnifiedResultDate(prd);
            //if (prd == null)
            //{
            //    //throw new HttpResponseException(HttpStatusCode.NotFound);
            //    v.Msg = "未找到数据";
            //    v.Code = HttpStatusCode.NotFound.ToString();
            //}
            return v;
        }

        //public HttpResponseMessage Get(int id)
        //{
        //    HttpResponseMessage hrm = new HttpResponseMessage();
        //    Product prd = ipdr.Get(id);
        //    hrm.Content = new StringContent(JsonConvert.SerializeObject(prd));
        //    if (prd == null)
        //    {
        //        //throw new HttpResponseException(HttpStatusCode.NotFound);
        //        hrm.StatusCode = HttpStatusCode.NotFound;
        //    }
        //    return hrm;
        //}

        // Get: api/Product?Category=category
        /// <summary>
        /// 获取指定类型的产品目录
        /// </summary>
        /// <param name="category">产品目录</param>
        /// <returns>返回符合条件的产品</returns>
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            var v =ipdr.GetAll().Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
            //if (v.Count() != 0)
            //    return v;
            //else
            //    return null;
            return v.Count() == 0 ? null : v;
        }

        // POST: api/Product
        public HttpResponseMessage Post(Product item)
        {
            item = ipdr.Add(item);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);
            string url = Url.Link("Default", new { id = item.Id });
            response.Headers.Location = new Uri(url);
            return response;
        }

        // PUT: api/Product/5
        public void Put(int id, Product product)
        {
            product.Id = id;
            if (!ipdr.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            Product item = ipdr.Get(id);
            if(item==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            ipdr.Remove(id);
        }
    }
}
