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
    [RoutePrefix("api/lenhsanxuat_thanhpham")]
    [Authorize]
    public class LenhSanXuat_ThanhPhamController : ApiControllerBase
    {
        ILenhSanXuat_ThanhPhamService _lenhSanXuat_ThanhPhamService;

        public LenhSanXuat_ThanhPhamController(ILoiService loiService, ILenhSanXuat_ThanhPhamService lenhSanXuat_ThanhPhamService) : base(loiService)
        {
            this._lenhSanXuat_ThanhPhamService = lenhSanXuat_ThanhPhamService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<LenhSanXuat_ThanhPhamViewModel> lenhSanXuat_ThanhPhamVM)
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
        //            foreach (var item in lenhSanXuat_ThanhPhamVM)
        //            {
        //                var newThongBao = new LenhSanXuat_ThanhPham();
        //                newThongBao.UpdateLenhSanXuat_ThanhPham(item);

        //                _lenhSanXuat_ThanhPhamService.Add(newThongBao);
        //                _lenhSanXuat_ThanhPhamService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, LenhSanXuat_ThanhPhamViewModel lenhSanXuat_ThanhPhamViewModel)

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

        //            var vienchucDb = _lenhSanXuat_ThanhPhamService.getID(Convert.ToInt32(lenhSanXuat_ThanhPhamViewModel.ID));

        //            vienchucDb.UpdateLenhSanXuat_ThanhPham(lenhSanXuat_ThanhPhamViewModel);
        //            _lenhSanXuat_ThanhPhamService.Update(vienchucDb);
        //            _lenhSanXuat_ThanhPhamService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<LenhSanXuat_ThanhPhamViewModel> lenhSanXuat_ThanhPhamVM)
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
                    foreach (var item in lenhSanXuat_ThanhPhamVM)
                    {
                        var newThongBao = new LenhSanXuat_ThanhPham();
                        newThongBao.UpdateLenhSanXuat_ThanhPham(item);

                        _lenhSanXuat_ThanhPhamService.Add(newThongBao);
                        _lenhSanXuat_ThanhPhamService.Save();
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


                var listCategory = _lenhSanXuat_ThanhPhamService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<LenhSanXuat_ThanhPham>,IEnumerable<LenhSanXuat_ThanhPhamViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaLenhSanXuat_ThanhPham.Length + x.MaLenhSanXuat_ThanhPham);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
         [Route("getchitietlenhsanxuatthanhpham")]
        public HttpResponseMessage getchitietlenhsanxuatthanhpham(HttpRequestMessage request, string MaLenhSanXuat)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _lenhSanXuat_ThanhPhamService.getchitietlenhsanxuatthanhpham(MaLenhSanXuat);
                //  var responseData = Mapper.Map<IEnumerable<LenhSanXuat_ThanhPham>,IEnumerable<LenhSanXuat_ThanhPhamViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaLenhSanXuat_ThanhPham.Length + x.MaLenhSanXuat_ThanhPham);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        

        public HttpResponseMessage Post(HttpRequestMessage request, LenhSanXuat_ThanhPham lenhSanXuat_ThanhPham)
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
                    _lenhSanXuat_ThanhPhamService.Add(lenhSanXuat_ThanhPham);
                    _lenhSanXuat_ThanhPhamService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, LenhSanXuat_ThanhPham lenhSanXuat_ThanhPham)
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
                    _lenhSanXuat_ThanhPhamService.Update(lenhSanXuat_ThanhPham);
                    _lenhSanXuat_ThanhPhamService.Commit();

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
                    _lenhSanXuat_ThanhPhamService.delete(id);
                    _lenhSanXuat_ThanhPhamService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
