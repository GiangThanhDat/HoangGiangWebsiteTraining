using AutoMapper;
using Newtonsoft.Json.Linq;
using Platform.Model;
using Platform.Service;
using Platform.Web.infratructure.core;
using Platform.Web.infratructure.extensions;
using Platform.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Platform.Web.Infrastructure.Core;

namespace Platform.Web.Api
{
    [RoutePrefix("api/lenhsanxuat_nvl")]
    [Authorize]
    public class LenhSanXuat_NVLController : ApiControllerBase
    {
        ILenhSanXuat_NVLService _lenhSanXuat_NVLService;

        public LenhSanXuat_NVLController(ILoiService loiService, ILenhSanXuat_NVLService lenhSanXuat_NVLService) : base(loiService)
        {
            this._lenhSanXuat_NVLService = lenhSanXuat_NVLService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<LenhSanXuat_NVLViewModel> lenhSanXuat_NVLVM)
        //{


        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            foreach (var item in lenhSanXuat_NVLVM)
        //            {
        //                var newThongBao = new LenhSanXuat_NVL();
        //                newThongBao.UpdateLenhSanXuat_NVL(item);

        //                _lenhSanXuat_NVLService.Add(newThongBao);
        //                _lenhSanXuat_NVLService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}


        //[Route("update")]
        //[HttpPut]
        //[AllowAnonymous]
        //public HttpResponseMessage update(HttpRequestMessage request, LenhSanXuat_NVLViewModel lenhSanXuat_NVLViewModel)

        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {

        //            var vienchucDb = _lenhSanXuat_NVLService.getID(Convert.ToInt32(lenhSanXuat_NVLViewModel.ID));

        //            vienchucDb.UpdateLenhSanXuat_NVL(lenhSanXuat_NVLViewModel);
        //            _lenhSanXuat_NVLService.Update(vienchucDb);
        //            _lenhSanXuat_NVLService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<LenhSanXuat_NVLViewModel> lenhSanXuat_NVLVM)
        {


            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    foreach (var item in lenhSanXuat_NVLVM)
                    {
                        var newThongBao = new LenhSanXuat_NVL();
                        newThongBao.UpdateLenhSanXuat_NVL(item);

                        _lenhSanXuat_NVLService.Add(newThongBao);
                        _lenhSanXuat_NVLService.Save();
                    }
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _lenhSanXuat_NVLService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<LenhSanXuat_NVL>,IEnumerable<LenhSanXuat_NVLViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaLenhSanXuat_NVL.Length + x.MaLenhSanXuat_NVL);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getlenhsanxuatNVL")]
        public HttpResponseMessage getlenhsanxuatNVL(HttpRequestMessage request, string MaLenhSanXuat)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _lenhSanXuat_NVLService.getlenhsanxuatNVL(MaLenhSanXuat);
                //  var responseData = Mapper.Map<IEnumerable<LenhSanXuat_NVL>,IEnumerable<LenhSanXuat_NVLViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaLenhSanXuat_NVL.Length + x.MaLenhSanXuat_NVL);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        

        public HttpResponseMessage Post(HttpRequestMessage request, LenhSanXuat_NVL lenhSanXuat_NVL)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _lenhSanXuat_NVLService.Add(lenhSanXuat_NVL);
                    _lenhSanXuat_NVLService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, LenhSanXuat_NVL lenhSanXuat_NVL)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _lenhSanXuat_NVLService.Update(lenhSanXuat_NVL);
                    _lenhSanXuat_NVLService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _lenhSanXuat_NVLService.delete(id);
                    _lenhSanXuat_NVLService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
