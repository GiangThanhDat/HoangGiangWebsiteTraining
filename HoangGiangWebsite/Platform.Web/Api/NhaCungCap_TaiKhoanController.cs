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
    [RoutePrefix("api/nhacungcap-taikhoan")]
    [Authorize]
    public class NhaCungCap_TaiKhoanController : ApiControllerBase
    {
        INhaCungCap_TaiKhoanService _nhaCungCap_TaiKhoanService;

        public NhaCungCap_TaiKhoanController(ILoiService loiService, INhaCungCap_TaiKhoanService nhaCungCap_TaiKhoanService) : base(loiService)
        {
            this._nhaCungCap_TaiKhoanService = nhaCungCap_TaiKhoanService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<NhaCungCap_TaiKhoanViewModel> nhaCungCap_TaiKhoanVM)
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
        //            foreach (var item in nhaCungCap_TaiKhoanVM)
        //            {
        //                var newThongBao = new NhaCungCap_TaiKhoan();
        //                newThongBao.UpdateNhaCungCap_TaiKhoan(item);

        //                _nhaCungCap_TaiKhoanService.Add(newThongBao);
        //                _nhaCungCap_TaiKhoanService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, NhaCungCap_TaiKhoanViewModel nhaCungCap_TaiKhoanViewModel)

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

        //            var vienchucDb = _nhaCungCap_TaiKhoanService.getID(Convert.ToInt32(nhaCungCap_TaiKhoanViewModel.ID));

        //            vienchucDb.UpdateNhaCungCap_TaiKhoan(nhaCungCap_TaiKhoanViewModel);
        //            _nhaCungCap_TaiKhoanService.Update(vienchucDb);
        //            _nhaCungCap_TaiKhoanService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<NhaCungCap_TaiKhoanViewModel> nhaCungCap_TaiKhoanVM)
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
                    foreach (var item in nhaCungCap_TaiKhoanVM)
                    {
                        var newThongBao = new NhaCungCap_TaiKhoan();
                        newThongBao.UpdateNhaCungCap_TaiKhoan(item);

                        _nhaCungCap_TaiKhoanService.Add(newThongBao);
                        _nhaCungCap_TaiKhoanService.Save();
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


                var listCategory = _nhaCungCap_TaiKhoanService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<NhaCungCap_TaiKhoan>,IEnumerable<NhaCungCap_TaiKhoanViewModel>>(listCategory);
                //var b = listCategory.OrderBy(x => x.MaNhaCungCap_TaiKhoan.Length + x.MaNhaCungCap_TaiKhoan);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


      

        public HttpResponseMessage Post(HttpRequestMessage request, NhaCungCap_TaiKhoan nhaCungCap_TaiKhoan)
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
                    _nhaCungCap_TaiKhoanService.Add(nhaCungCap_TaiKhoan);
                    _nhaCungCap_TaiKhoanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, NhaCungCap_TaiKhoan nhaCungCap_TaiKhoan)
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
                    _nhaCungCap_TaiKhoanService.Update(nhaCungCap_TaiKhoan);
                    _nhaCungCap_TaiKhoanService.Commit();

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
                    _nhaCungCap_TaiKhoanService.delete(id);
                    _nhaCungCap_TaiKhoanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
